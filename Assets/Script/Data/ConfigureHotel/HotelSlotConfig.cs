using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    namespace ConfigureHotel
    {
        [CreateAssetMenu(fileName = "LayerConfigureInfo", menuName = "ConfigureHotel/LayerConfigureInfo")]
        public class HotelSlotConfig:ScriptableObject
        {
            public LayerSlotConfig Layer;
            public List<RoomSlotConfig> Rooms;
        }
    }
}