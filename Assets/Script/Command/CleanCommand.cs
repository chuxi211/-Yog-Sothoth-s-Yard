using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    namespace Management
    {
        public class CleanCommand : Command
        {
            public int Cleanliness { get;private set; }
            public int San { get; private set; }
            public CleanCommand(int cleanliness, int san)
            {
                ConsumeActionPoint = true;
                this.CommandType = CommandType.CleanRoom;
                this.TargetType = TargetType.Hotel;
                Cleanliness = cleanliness;
                San = san;
            }
        }
    }
}