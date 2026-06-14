using Data.ConfigureHotel;
using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PrefabComponent : IRoomLevelComponent
{
    public GameObject Prefab { get; private set; }
    public int Level { get; private set; }
    private RoomActor Actor;
    public PrefabComponent(RoomActor actor)
    {
        Actor = actor;
    }

    public void ApplyLevel(RoomLevelConfig roomLevelConfig)
    {
        Level = roomLevelConfig.Level;
        Prefab = roomLevelConfig.Prefab;
    }

    public void Upgrade(RoomLevelConfig roomLevelConfig)
    {
        Level=roomLevelConfig.Level;
        Prefab = roomLevelConfig.Prefab;
        ReplaceView(Prefab);
    }
    private void ReplaceView(GameObject Prefab)
    {
        Transform oldVisual = Actor.transform.Find("Visual");
        if (oldVisual != null)
        {
            GameObject.Destroy(oldVisual.gameObject);
        }
        Transform prefabVisual = Prefab.transform.Find("Visual");

        if (prefabVisual == null)
        {
            Debug.LogError("Visual is missing in prefab: " + Prefab.name);
            return;
        }

        GameObject newVisual = GameObject.Instantiate(prefabVisual.gameObject,Actor.transform);

        newVisual.name = "Visual";
        newVisual.transform.localPosition = prefabVisual.localPosition;
        newVisual.transform.localRotation = prefabVisual.localRotation;
        newVisual.transform.localScale = prefabVisual.localScale;
    }
}