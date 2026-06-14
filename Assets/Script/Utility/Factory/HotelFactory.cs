using Data.ConfigureHotel;
using Data.Economy;
using Data.RunningHotel;
using RoomState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelFactory
{
    private RoomManager roomManager;
    private ComponentFactory ComponentFactory;
    private Inventory Inventory;
    private Economy Economy;
    public HotelFactory(RoomManager roomManager, ComponentFactory componentFactory, Inventory inventory,Economy economy)
    {
        this.roomManager = roomManager;
        ComponentFactory = componentFactory;
        this.Inventory = inventory;
        this.Economy = economy;
    }
    public HotelRunning CreatHotel(HotelLevelConfigTable Config)
    {
        return new HotelRunning(Config);
    }
    public GameObject CreatLayer(LayerSlotConfig info,Transform parent)
    {
        var go = GameObject.Instantiate(info.Prefab, parent);
        go.transform.localPosition = info.Position;
        go.transform.localRotation = Quaternion.identity;
        return go;
    }
    public RoomRunning CreatRoom(RoomSlotConfig slotinfo,RoomLevelConfig LevelInfo,NPCFactory npcfactory, NPCDataBase npcDataBase,CommandInvoker invoker,Dictionary<int,RoomLevelConfig> levelConfigs, GameObject parent)
    {
        GameObject go = GameObject.Instantiate(LevelInfo.Prefab, parent.transform);
        go.transform.localPosition = slotinfo.Position;
        go.transform.localRotation = Quaternion.identity;
        //运行时对象
        RoomRunning room = new RoomRunning(LevelInfo);
        var runningstate = new RunningState(room.roomStateMachine, room,invoker);
        var levelevaluationstate=new LevelEvaluationState(room.roomStateMachine,room,levelConfigs,Inventory,Economy);
        room.roomStateMachine.RegisterState(runningstate);
        room.roomStateMachine.RegisterState(levelevaluationstate);
        room.roomStateMachine.ChangeState<RunningState>();
        //实体对象
        RoomActor roomActor = go.GetComponent<RoomActor>();
        if (!roomActor)
        {
            roomActor = go.AddComponent<RoomActor>();
        }
        //
        roomActor.Init(room);
        //绑定
        room.BindActor(roomActor);
        Debug.Log($"{roomActor.roomRunning.ID.Floor}-{roomActor.roomRunning.ID.Index}");
        ComponentFactory.AttachComponent(room,LevelInfo);

        //手动指定所有Room添加Prefab组件
        var prefabcmpbld = new PrefabComponentBuilder();
        prefabcmpbld.BuildComponent(room,LevelInfo);
        roomManager.RegisterRoom(room);
        return room;
    }
}