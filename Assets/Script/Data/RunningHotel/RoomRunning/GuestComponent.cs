using Data.ConfigureHotel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.RunningHotel
{
    public class GuestComponent:IRoomLevelComponent
    {
        public int MaxNPC { get; private set; } = 0;
        public int CoinBuffer { get; private set; } = 0;
        public int Coin { get; private set; } = 0;
        public List<ItemRunning> ItemBuffer { get; private set; }=new List<ItemRunning>();
        public NPCFactory npcFactory { get; private set; }
        public NPCDataBase npcDataBase { get; private set; }
        public List<NPCRunning> NPCs { get; private set; }=new List<NPCRunning>();

        public int Level { get; private set; }
        private int PricePerGuest;
        private RoomID ID;

        public List<NPCRunning> GetDepartNPCs()
        {
            return NPCs.Where(x=>x.StayDuration<=0).ToList();
        }
        public void BindNPCFactory(NPCFactory npcfactory)
        {
            this.npcFactory = npcfactory;
        }
        public void BindNPCDataBase(NPCDataBase npcDataBase)
        {
            this.npcDataBase = npcDataBase;
        }
        public void BindRoomID(RoomID id)
        {
            ID = id;
        }
        public void ApplyLevel(RoomLevelConfig roomLevelConfig)
        {
            Level = roomLevelConfig.Level;
            PricePerGuest=roomLevelConfig.PricePerGuest;
            MaxNPC = roomLevelConfig.MaxNPC;
        }

        public void Upgrade(RoomLevelConfig roomLevelConfig)
        {
            Level = roomLevelConfig.Level;
            PricePerGuest = roomLevelConfig.PricePerGuest;
            MaxNPC= roomLevelConfig.MaxNPC;
        }
        public void AddNPC()
        {
            Debug.Log($"Try Add NPC, Level = {Level}");
            if (NPCs.Count >= MaxNPC) { return; }

            var configs = npcDataBase.GetNPCConfigByLevel(Level);

            Debug.Log($"NPC Config Count = {configs.Count}");

            for(int i = 0; i < MaxNPC - NPCs.Count; i++)
            {
                NPCs.Add(npcFactory.CreateNPC(configs[i]));
            }
        }
        public void UpdateNPC()
        {
            Debug.Log("Try UpdateNPC");
            foreach (var npc in NPCs)
            {
                npc.UpdateStayDuration();
            }
            var departNPCs = GetDepartNPCs();
            foreach (var npc in departNPCs)
            {
                AddItemBuffer(npc);
            }
            AddCoinBuffer();
        }
        public void RemoveNPC()
        {
            var departNPCs = GetDepartNPCs();
            for(int i = 0; i < departNPCs.Count; i++)
            {
                if (departNPCs[i].Actor == null)
                {
                    Debug.LogError($"departNPC:{departNPCs[i]}.Actor is null");
                }
                if (departNPCs[i].Actor.gameObject == null)
                {
                    Debug.LogError($"departNPC:{departNPCs[i].Actor}.gameObject is null");
                }
                GameObject.Destroy(departNPCs[i].Actor.gameObject);
                Debug.Log($"Destory GameObject:{departNPCs[i].Name}");
            }
            NPCs.RemoveAll(x=>x.StayDuration<=0);
        }
        public void RemoveAllNPC()
        {
            for(int i = 0;i < NPCs.Count; i++)
            {
                GameObject.Destroy(NPCs[i].Actor.gameObject);
            }
            NPCs.Clear();
        }
        public void AddCoinBuffer()
        {
            Debug.Log("NPC.Count:" + NPCs.Count);
            CoinBuffer += NPCs.Count * PricePerGuest;
            EventBus.Publish(new CoinBufferChangedEvent(ID, CoinBuffer));
            Debug.Log($"CoinBuffer :{CoinBuffer}");
        }
        public void AddItemBuffer(NPCRunning npc)
        {
            ItemBuffer = DropSystem.Generate(npc);
        }
        public int TryCollectCoin()
        {
            int Coin = CoinBuffer;
            CoinBuffer = 0;
            EventBus.Publish(new CoinBufferChangedEvent(ID,CoinBuffer));
            return Coin;
        }
        public int GetAllCoin()
        {
            int AllCoin = Coin;
            foreach (var npc in NPCs)
            {
                AllCoin += npc.Coin;
            }
            return AllCoin;
        }
        public int GetCleanlinessValue()
        {
            int CleanlinessValue = 0;
            for(int i = 0; i < NPCs.Count; i++)
            {
                CleanlinessValue += NPCs[i].CleanlinessValue;
            }
            return CleanlinessValue;
        }

    }
}