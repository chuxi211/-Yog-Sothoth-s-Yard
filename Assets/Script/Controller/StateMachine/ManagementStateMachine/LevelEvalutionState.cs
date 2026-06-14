using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ManagementState
{
    public class LevelEvalutionState : ManagementState
    {
        public LevelEvalutionState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
            
        }
        public override void Enter()
        {
            if(CanUpgrade())
            {
                Upgrade();
                //这里只实例新的
                StateMachine.managementContext.layerslotinfos.Add(StateMachine.managementContext.hotelslotinfos[StateMachine.managementContext.hotelRunning.UnlockedFloor-1].Layer);
                GameObject Floor= StateMachine.managementContext.factory.CreatLayer(StateMachine.managementContext.hotelslotinfos[StateMachine.managementContext.hotelRunning.UnlockedFloor-1].Layer, GameObject.Find("Hotel").transform);
                foreach(var roomSlot in StateMachine.managementContext.hotelslotinfos[StateMachine.managementContext.hotelRunning.UnlockedFloor - 1].Rooms)
                {
                    StateMachine.managementContext.roomslotinfos.Add(roomSlot);
                    Debug.Log("RoomID:"+ roomSlot.ID.Floor + "-" + roomSlot.ID.Index);
                    if (!StateMachine.managementContext.LevelInfos.TryGetValue(roomSlot.ID, out var roomLevelConfig))
                    {
                        continue;
                    }
                    if(!roomLevelConfig.TryGetValue(0, out var roomLevel))
                    {
                        continue;
                    }
                    RoomRunning Room = StateMachine.managementContext.factory.CreatRoom
                                        (roomSlot, roomLevel, StateMachine.managementContext.npcFactroy, 
                                        StateMachine.managementContext.NPCDataBase, StateMachine.managementContext.Invoker,
                                        StateMachine.managementContext.LevelInfos[roomSlot.ID],
                                        Floor);
                    CollectCoinButton collectCoinButton = Room.roomActor.GetComponent<CollectCoinButton>();
                    if (collectCoinButton == null)
                    {
                        Debug.Log("Current Room dont have CollectCoinButton");
                    }
                    else
                    {
                        collectCoinButton.Init(StateMachine.managementContext.Invoker);
                    }
                    UpgradeClick upgradeClick = Room.roomActor.GetComponentInChildren<UpgradeClick>();
                    if (upgradeClick == null)
                    {
                        Debug.LogError("Upgrade is null in RoomID:" + Room.ID.Floor.ToString() + "-" + Room.ID.Index.ToString());
                    }
                    else
                    {
                        upgradeClick.Init(StateMachine.managementContext.Invoker);
                    }
                }
            }
            StateMachine.PopState();
        }
        private bool CanUpgrade()
        {
            if (StateMachine.managementContext == null)
            {
                Debug.LogError("managementContext is null");
            }
            if (StateMachine.managementContext.Economy.Cleanliness >= StateMachine.managementContext.hotelRunning?.CleanlinessGoal
                && StateMachine.managementContext.Economy.AllCoin >=StateMachine.managementContext.hotelRunning.CoinGoal)
            {
                Debug.Log("Can LevelUp");
                return true;
            }
            Debug.Log("Can not Level Up");    
            return false;
        }
        private void Upgrade()
        {
            HotelLevelConfigTable temp = StateMachine.managementContext.HotelLevelDataBase.GetConfigInfo
                                        (StateMachine.managementContext.hotelRunning.CurrentLevel + 1);
            StateMachine.managementContext.hotelRunning.LevelUp(temp);
        }
    }
}