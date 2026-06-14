using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    namespace ConfigureHotel
    {
        [Serializable]
        public class LayerSlotConfig
        {
            public int Layer;
            public GameObject Prefab;
            public Vector3 Position;
        }
    }
}