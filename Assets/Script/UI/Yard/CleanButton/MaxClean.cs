using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxClean : CleanButton
{
    private void Start()
    {
        Cleanliness = 400;
        SanValue = -10;
    }
}