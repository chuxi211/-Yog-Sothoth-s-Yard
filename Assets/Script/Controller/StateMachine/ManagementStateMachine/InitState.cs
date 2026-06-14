using Data.RunningHotel;
using System.Linq;
using UnityEngine;

namespace ManagementState
{
    public class InitState : ManagementState
    {
        private ItemList ItemList;
        private SellingFoodList SellingFoodList;
        private FoodInventoryList FoodInventoryList;
        private MenuEditorList MenuEditorList;
        private RecipeList RecipeList;
        private RecipeDetailContainer RecipeDetailContainer;
        private ToFloorButton toFloorButton;
        private OpenCleanPanelButton openCleanButton;
        private CollectCoinButton collectCoinButton;
        private UpgradeClick upgradeClick;
        private Transform HotelParent;
        public InitState(ManagementStateMachine managementStateMachine) : base(managementStateMachine)
        {
        }

        public override void Enter()
        {
            PlayerInit();
            LoadConfig();
            CreateHotel();
            UIInit();
            StateMachine.ChangeState<RunningState>();
            Debug.Log(StateMachine.managementContext.Economy.Cleanliness);
        }
        private void UIInit()
        {
            Debug.Log("UIInit");
            var toFloorButtons = GameObject.FindObjectsByType<ToFloorButton>(FindObjectsSortMode.None);
            for (int i = 0; i < toFloorButtons.Length; i++)
            {
                toFloorButtons[i].Init(StateMachine.managementContext.Invoker);
            }
            var cleanButtons=GameObject.FindObjectsByType<CleanButton>(FindObjectsSortMode.None);
            for (int i = 0; i < cleanButtons.Length; i++)
            {
                cleanButtons[i].Init(StateMachine.managementContext.Invoker);
            }
            var exploreButtons = GameObject.FindObjectsByType<StartForestExploreButton>(FindObjectsSortMode.None);
            for(int i = 0; i < exploreButtons.Length; i++)
            {
                exploreButtons[i].Init(StateMachine.managementContext.Invoker);
            }
            var massacreButton=GameObject.FindObjectsByType<MassacreButton>(FindObjectsSortMode.None);
            massacreButton[0].Init(StateMachine.managementContext.Invoker);
            ItemList = GameObject.Find("ItemList").GetComponent<ItemList>();
            ItemList.Init(StateMachine.managementContext.Inventory);

            SellingFoodList =GameObject.FindObjectsByType<SellingFoodList>(FindObjectsSortMode.None)[0];
            SellingFoodList.BindRestaurant(StateMachine.managementContext.roomManager.GetRoom(new Data.RoomID(1,6)).GetComponent<RestaurantComponent>());
            SellingFoodList.BindPrefabLoader(StateMachine.managementContext.PrefabLoader);
            SellingFoodList.Init();

            FoodInventoryList=GameObject.FindObjectsByType<FoodInventoryList>(FindObjectsSortMode.None)[0];
            FoodInventoryList.BindRestaurant(StateMachine.managementContext.roomManager.GetRoom(new Data.RoomID(1, 6)).GetComponent<RestaurantComponent>());
            FoodInventoryList.BindPrefabLoader(StateMachine.managementContext.PrefabLoader);
            FoodInventoryList.Init();
            
            MenuEditorList=GameObject.FindObjectsByType<MenuEditorList>(FindObjectsSortMode.None)[0];
            MenuEditorList.BindRestaurant(StateMachine.managementContext.roomManager.GetRoom(new Data.RoomID(1, 6)).GetComponent<RestaurantComponent>());
            MenuEditorList.BindPrefabLoader(StateMachine.managementContext.PrefabLoader);
            MenuEditorList.BindCommandInvoker(StateMachine.managementContext.Invoker);
            MenuEditorList.Init();

            RecipeList=GameObject.FindObjectsByType<RecipeList>(FindObjectsSortMode.None)[0];
            RecipeList.BindPrefabLoader(StateMachine.managementContext.PrefabLoader);
            RecipeList.BindRecipeDataBase(StateMachine.managementContext.RecipeDataBase);
            RecipeList.Init();

            RecipeDetailContainer = GameObject.FindObjectsByType<RecipeDetailContainer>(FindObjectsSortMode.None)[0];
            RecipeDetailContainer.BindInvoker(StateMachine.managementContext.Invoker);
        }
        private void PlayerInit()
        {
            StateMachine.managementContext.animationPlayers = GameObject.FindObjectsByType<AnimationPlayer>(FindObjectsSortMode.None).ToList();
            for (int i = 0; i < StateMachine.managementContext.animationPlayers.Count; i++)
            {
                StateMachine.managementContext.animationPlayers[i].BindAnimSystem(StateMachine.managementContext. animationSystem);
                StateMachine.managementContext.animationPlayers[i].Registe();
            }
            Debug.Log($"AnimationPlayer.Count:{StateMachine.managementContext.animationPlayers.Count}");
        }
        private void LoadConfig()
        {
            Debug.Log("LoadConfig");
            StateMachine.managementContext.hotelslotinfos = StateMachine.managementContext.slotloader.LoadAll("ConfigureInfo/HotelSlotConfig");
            StateMachine.managementContext.roomlevelinfos = StateMachine.managementContext.levelloader.LoadAll("ConfigureInfo/RoomLevelConfig");
            StateMachine.managementContext.SlotInfos = StateMachine.managementContext.hotelslotinfos.SelectMany(floor => floor.Rooms).ToDictionary(room => room.ID);
            StateMachine.managementContext.LevelInfos = StateMachine.managementContext.
                roomlevelinfos.GroupBy(room => room.ID).
                ToDictionary(group => group.Key, group => group.ToDictionary(config => config.Level, config => config));
        }
        private void CreateHotel()
        {
            Debug.Log("CreatHotel");
            HotelParent = GameObject.Find("Hotel").transform;
            //默认0级
            StateMachine.managementContext.hotelRunning = StateMachine.managementContext.factory.CreatHotel
                                        (StateMachine.managementContext.HotelLevelDataBase.GetConfigInfo(0));
            Debug.Log($"HotelLevel:{StateMachine.managementContext.hotelRunning.CurrentLevel}");
            //实例解锁的楼层，未解锁的楼层不实例化
            for (int i = 0; i < StateMachine.managementContext.hotelRunning.UnlockedFloor; i++)
            {
                StateMachine.managementContext.layerslotinfos.Add(StateMachine.managementContext.hotelslotinfos[i].Layer);
                GameObject Floor = StateMachine.managementContext.factory.CreatLayer(StateMachine.managementContext.hotelslotinfos[i].Layer, HotelParent);
                foreach (var roomSlot in StateMachine.managementContext.hotelslotinfos[i].Rooms)
                {
                    StateMachine.managementContext.roomslotinfos.Add(roomSlot);
                    Debug.Log(roomSlot.ID.Floor);
                    Debug.Log(roomSlot.ID.Index);
                    if (!StateMachine.managementContext.LevelInfos.TryGetValue(roomSlot.ID, out var roomLevelConfig))
                    {
                        continue;
                    }
                    //默认0级
                    //我承认直接写死不太好
                    if (!roomLevelConfig.TryGetValue(0, out var roomLevel))
                    {
                        continue;
                    }
                    RoomRunning Room = StateMachine.managementContext.factory.CreatRoom
                                        (roomSlot, roomLevel, StateMachine.managementContext.npcFactroy,
                                        StateMachine.managementContext.NPCDataBase, StateMachine.managementContext.Invoker,
                                        StateMachine.managementContext.LevelInfos[roomSlot.ID],
                                        Floor);
                    collectCoinButton = Room.roomActor.GetComponentInChildren<CollectCoinButton>();
                    if (collectCoinButton == null)
                    {
                        Debug.Log("Current Room dont have CollectCoinButton");
                    }
                    else
                    {
                        collectCoinButton.Init(StateMachine.managementContext.Invoker);
                    }
                    upgradeClick=Room.roomActor.GetComponentInChildren<UpgradeClick>();
                    if (upgradeClick == null)
                    {
                        Debug.LogError("Upgrade is null in RoomID:" + Room.ID.Floor.ToString() + "-" + Room.ID.Index.ToString());
                    }
                    else
                    {
                        upgradeClick.Init(StateMachine.managementContext.Invoker);
                    }

                }
            }
        }
    }
    
}