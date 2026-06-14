using Data.ConfigureHotel;
using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentFactory
{
    private Dictionary<Data.RoomType, IComponentBuilder> ComponentTypeDict = new Dictionary<Data.RoomType,IComponentBuilder>();
    public void Register(Data.RoomType roomType, IComponentBuilder componentBuilder)
    {
        ComponentTypeDict[roomType] = componentBuilder;
    }
    public void AttachComponent(RoomRunning roomRunning,RoomLevelConfig levelConfig)
    {
        if(ComponentTypeDict.TryGetValue(roomRunning.RoomType,out var component))
        {
            component.BuildComponent(roomRunning,levelConfig);
            Debug.Log(roomRunning.ID.Floor.ToString()+"-"+roomRunning.ID.Index.ToString()
                + "has add component:" + component.GetType().ToString());
        }
    }
}