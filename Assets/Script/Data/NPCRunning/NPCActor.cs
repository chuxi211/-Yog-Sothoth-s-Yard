using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCActor : MonoBehaviour
{
    public NPCRunning npc { get; private set; }
    public void Init(NPCRunning npc)
    {
        this.npc = npc;
    }
}
