using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command.Management
{
    public class StartCookingCommand : Command
    {
        public Recipe Recipe;
        public StartCookingCommand(Recipe recipe)
        {
            Recipe = recipe;
            ConsumeActionPoint = false;
            CommandType = CommandType.Cooking;
            TargetType = TargetType.System;
        }
    }
}