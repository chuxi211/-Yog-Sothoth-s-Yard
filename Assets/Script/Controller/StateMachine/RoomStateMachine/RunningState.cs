using Command.Management;
using Data.RunningHotel;
using Data.Time;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomState
{
    public class RunningState : RoomState
    {
        private CommandInvoker Invoker;
        public RunningState(RoomStateMachine roomStateMachine, RoomRunning room, CommandInvoker invoker) : base(roomStateMachine, room)
        {
            Invoker = invoker;
        }

        public override void Enter()
        {
            Debug.Log($"{Room.ID.Floor}-{Room.ID.Index}");
            EventBus.Subscribe<DayNightSwitchedEvent>(OnDayNightChanged);
        }
        public override void Exit()
        {
            EventBus.UnSubscribe<DayNightSwitchedEvent>(OnDayNightChanged);
        }
        private void OnDayNightChanged(DayNightSwitchedEvent e)
        {
            if (e.Period == TimePeriod.Day)
            {
                Debug.Log("Day Update NPC");
                UpdateNPC();
                RemoveNPC();
                Debug.Log("Try to Add NPC");
                AddNPC();
                Invoker.Execute(new ChangeCleanlinessCommand(ChangeCleanlinessValue()));
            }
            else
            {
                Debug.Log("Night Update NPC");
                UpdateNPC();
                Invoker.Execute(new ChangeCleanlinessCommand(ChangeCleanlinessValue()));
                CollectItem();
                RemoveNPC();
            }
        }
        private void CollectItem()
        {
            if (Room.RoomType != Data.RoomType.GuestRoom)
            {
                return;
            }
            foreach(var item in Room.GetComponent<GuestComponent>().ItemBuffer)
            {
                Invoker.Execute(new InventoryItemChangeCommand(item, item.Count));
            }
        }
        private void AddNPC()
        {
            var guestcomp=Room.GetComponent<GuestComponent>();
            Debug.Log("Add NPC");
            if (guestcomp == null)
            {
                Debug.LogError("GuestComponent is null!");
                return;
            }
            guestcomp?.AddNPC();
        }
        private void UpdateNPC()
        {
            Debug.Log($"{Room.ID.Floor}+{Room.ID.Index}");
            Debug.Log($"{Room.roomStateMachine.roomRunning.ID.Floor}-{Room.roomStateMachine.roomRunning.ID.Index}");
            var guestcomp=Room.GetComponent<GuestComponent>();
            if (guestcomp == null)
            {
                Debug.Log($"{Room.ID.Floor}-{Room.ID.Index}.{typeof(GuestComponent) is null}");
            }
            guestcomp?.UpdateNPC();
        }
        private void RemoveNPC()
        {
            var guestcomp = Room.GetComponent<GuestComponent>();
            if (guestcomp == null)
            {
                Debug.Log($"{Room.ID.Floor}-{Room.ID.Index}.{typeof(GuestComponent) is null}");
            }
            guestcomp?.RemoveNPC();
        }
        private int ChangeCleanlinessValue()
        {
            if(Room.RoomType!=Data.RoomType.GuestRoom)
            {
                return 0;
            }
            var guestcomp=Room.GetComponent<GuestComponent>();
            int value = 0;
            if(guestcomp != null)
            {
                value= guestcomp.GetCleanlinessValue();
            }
            return value;
        }
    }
}