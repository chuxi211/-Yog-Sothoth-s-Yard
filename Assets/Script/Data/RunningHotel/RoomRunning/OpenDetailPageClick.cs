using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDetailPageClick : MonoBehaviour, IRoomClick
{
    private RoomActor RoomActor;
    private void Awake()
    {
        RoomActor = GetComponentInParent<RoomActor>();
    }
    public void Click()
    {
        if (RoomActor.roomRunning == null)
        {
            Debug.LogError("RoomRunning is null");
        }
        if (RoomActor.roomRunning.GetComponent<IRoomLevelComponent>() == null)
        {
            Debug.LogError("IRoomLevelComponent is null");
            return;
        }
        RoomActor.DetailPage.SetTexts(RoomActor.roomRunning.ID, RoomActor.roomRunning.GetComponent<IRoomLevelComponent>().Level);
        RoomActor.DetailPage.Show();
    }
}
