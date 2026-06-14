using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class RoomManager
{
    private Dictionary<RoomID, RoomRunning> rooms = new Dictionary<RoomID, RoomRunning>();
    public void RegisterRoom(RoomRunning room)
    {
        rooms[room.ID] = room;
    }
    public RoomRunning GetRoom(RoomID id)
    {
        if (rooms.TryGetValue(id, out var room))
        {
            return room;
        }
        else
        {
            Debug.LogError($"Room with ID {id.Floor}-{id.Index} not found.");
            return null;
        }
    }
    public List<RoomRunning> GetAllRoom()
    {
        List<RoomRunning> roomRunnings = new List<RoomRunning>();
        foreach(var room in rooms.Values)
        {
            roomRunnings.Add(room);
        }
        return roomRunnings;
    }
}