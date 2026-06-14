using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDetailPageClick : MonoBehaviour, IRoomClick
{
    private RoomActor RoomActor;
    private void Awake()
    {
        RoomActor = GetComponentInParent<RoomActor>();
    }
    public void Click()
    {
        RoomActor.DetailPage.Hide();
    }
}
