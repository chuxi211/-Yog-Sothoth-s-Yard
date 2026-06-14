using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click");
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Hit: " + hit.collider.name);
                RoomActor roomActor = hit.collider.GetComponentInParent<RoomActor>();
                if (roomActor != null)
                {
                    Debug.Log("Clicked on Room: " + roomActor.roomRunning.ID.Floor+"-"+roomActor.roomRunning.ID.Index);
                    IRoomClick roomClick=hit.collider.GetComponent<IRoomClick>();
                    roomClick?.Click();
                }
            }
        }
    }
}
