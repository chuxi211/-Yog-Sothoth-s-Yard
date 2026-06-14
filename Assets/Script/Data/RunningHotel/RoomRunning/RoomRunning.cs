using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoomState;
using System;
using Data.ConfigureHotel;
using System.Linq;
namespace Data.RunningHotel
{
    public class RoomRunning
    {
        public RoomStateMachine roomStateMachine { get; private set; }

        public RoomID ID { get; private set; }
        public RoomType RoomType { get; private set; }

        public RoomActor roomActor { get; private set; }
        public Dictionary<Type,object> Components { get; private set; }=new Dictionary<Type,object>();
        public RoomRunning(RoomLevelConfig Config)
        {
            this.roomStateMachine = new RoomStateMachine(this);
            this.ID = Config.ID;
            this.RoomType = Config.RoomType;
        }

        public void BindActor(RoomActor roomActor)
        {
            this.roomActor = roomActor;
        }
        public void AddComponent<T>(T component)where T:class
        {
            Components[typeof(T)] = component;
        }
        public T GetComponent<T>()where T:class
        {
            foreach (var component in Components.Values)
            {
                if (component is T result)
                    return result;
            }

            return null;
        }
        public List<T> GetComponents<T>() where T : class
        {
            List<T> results = new();

            foreach (var component in Components.Values)
            {
                if (component is T result)
                    results.Add(result);
            }

            return results;
        }
    }
}
namespace Data
{
    [Serializable]
    public struct RoomID:IEquatable<RoomID>
    {
        public int Floor;
        public int Index;
        public RoomID(int floor, int index)
        {
            this.Floor = floor;
            this.Index = index;
        }

        public bool Equals(RoomID other)
        {
            return Floor == other.Floor && Index == other.Index;
        }
        public override bool Equals(object obj)
        {
            return obj is RoomID other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Floor, Index);
        }
    }
}