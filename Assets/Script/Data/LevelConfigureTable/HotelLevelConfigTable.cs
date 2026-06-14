using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="HotelLevelConfig",menuName ="ConfigureHotel/HotelLevelConfig")]
[Serializable]
public class HotelLevelConfigTable : ScriptableObject
{
    public int Level;
    public int CleanlinessGoal;
    public int AllCoinGoal;
    public int UnlockedFloor;
}