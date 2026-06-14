using Data.ConfigureHotel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
namespace Data.RunningHotel
{
    public class RestaurantComponent:IRoomLevelComponent
    {
        public Inventory inventory { get; private set; }
        public NPCFactory npcFactory { get; private set; }
        public NPCDataBase npcDataBase { get; private set; }
        public ItemDataBase itemDataBase { get; private set; }
        public int Coin { get; private set; } = 0;
        public int CoinBuffer { get; private set; } = 0;
        public List<NPCRunning> NPCs = new();
        public List<SellingSlotInfo> SellingSlotInfos { get; private set; } = new();

        public int Level { get; private set; }

        public const int MaxSellingNum = 5;
        public void BindNPCFactory(NPCFactory npcFactory)
        {
            this.npcFactory= npcFactory;
        }
        public void BindNPCDataBase(NPCDataBase npcDataBase)
        {
            this.npcDataBase = npcDataBase;
        }
        public void BindItemDataBase(ItemDataBase itemDataBase)
        {
            this.itemDataBase = itemDataBase;
        }
        public void BindInventory(Inventory inventory)
        {
            this.inventory = inventory;
        }
        public void ApplyLevel(RoomLevelConfig roomLevelConfig)
        {
            Level= roomLevelConfig.Level;
        }

        public void Upgrade(RoomLevelConfig roomLevelConfig)
        {
            Level = roomLevelConfig.Level;
        }
        public List<ItemRunning> GetSellingCandidate()
        {
            return inventory.GetAllItems().Values.Where(x => x.Item.Type == ItemType.SellingFood).ToList();
        }
        public void SetMenu(List<SellingSlotInfo> slots)
        {
            SellingSlotInfos.Clear();

            foreach (var slot in slots)
            {
                SellingSlotInfos.Add(slot.Clone());
                inventory.ChangeItemCount(slot.FoodID,-slot.CurrentCount);
            }
        }
        public void SellFood()
        {
            int remainCustomers = NPCs.Count;
            foreach(var slotinfo in SellingSlotInfos)
            {
                if (remainCustomers <= 0) { break; }
                if (slotinfo.CurrentCount <= 0) { continue; }
                int sellNum = Mathf.Min(slotinfo.CurrentCount, remainCustomers);
                slotinfo.CurrentCount -= sellNum;
                CoinBuffer += itemDataBase.GetConfigureInfo(slotinfo.FoodID).Price * sellNum;
                remainCustomers -= sellNum;
            }
        }

    }
}
public class SellingSlotInfo
{
    public string FoodID;
    public int CurrentCount;
    //暂定为50,原则上，由于这个东西也有等级，也需要配置表和Loader
    public int MaxCount=50;
    public bool isEmpty=>string.IsNullOrEmpty(FoodID);
    public SellingSlotInfo(string foodID, int count)
    {
        FoodID = foodID;
        CurrentCount = count;
    }
    public SellingSlotInfo Clone()
    {
        var copy =new SellingSlotInfo(FoodID, CurrentCount);
        copy.MaxCount = MaxCount;
        return copy;
    }
    public void Clear()
    {
        FoodID=null;
        CurrentCount=0;
    }
}