using Data.ConfigureHotel;
using Data.Economy;
using Data.RunningHotel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using System.Linq;

public class ManagementContext
{
    //SlotConfigLoader
    public HotelSlotConfigLoader slotloader { get; private set; }
    public RoomLevelConfigLoader levelloader { get; private set; }

    //PrefabLoader
    public PrefabLoader PrefabLoader { get; private set; }
    //LevelEvaluationLoader
    public LevelEvaluationLoader evaluationLoader { get; private set; }

    //RecipeLoader
    public RecipeLoader RecipeLoader { get; private set; }
    //LevelConfigInfo
    public Dictionary<RoomID, Dictionary<int, RoomLevelConfig>> LevelInfos;
    //SlotConfigInfo
    public Dictionary<RoomID, RoomSlotConfig> SlotInfos;
    public List<HotelSlotConfig> hotelslotinfos;
    public List<LayerSlotConfig> layerslotinfos;
    public List<RoomSlotConfig> roomslotinfos;
    public List<RoomLevelConfig> roomlevelinfos;
    //Factories
    public HotelFactory factory;
    public NPCFactory npcFactroy;
    public ComponentFactory componentFactory;
    //Manager
    public RoomManager roomManager;
    //CommandInvoker , Validator and Dispatcher
    public CommandDispatcher dispatcher;
    public CommandInvoker Invoker;
    public CommandValidator validator;

    //CommandValidators
    public MassacreValidator massacreValidator;
    //Management Data:Economy  GameTime  Inventory
    public Economy Economy;
    public Data.Time.Time GameTime;
    public Inventory Inventory;
    //DataBase:Level,Item,NPC,Recipe
    public HotelLevelDataBase HotelLevelDataBase;
    public ItemDataBase ItemDataBase;
    public NPCDataBase NPCDataBase;
    public ForestExploreDataBase FExploreDataBase;
    public RecipeDataBase RecipeDataBase;

    //Components
    public GuestComponentBuilder guestComponentBuilder;
    public RestaurantComponentBuilder restaurantComponentBuilder;
    //Explore
    public ForestExploreSystem ForestExploreSystem;

    public HotelRunning hotelRunning;
    //Animation Register and Player
    public AnimationSystem animationSystem;
    public List<AnimationPlayer> animationPlayers;
    //Crafter
    public Crafter Crafter;
    public ManagementContext()
    {
        slotloader = new();
        levelloader = new();
        PrefabLoader = new();
        evaluationLoader = new();
        RecipeLoader = new();
        LevelInfos = new();
        SlotInfos = new();
        LevelInfos = null;
        SlotInfos = null;
        hotelslotinfos = new();
        layerslotinfos = new();
        roomslotinfos = new();
        roomlevelinfos = new();
        GameTime = new();
        HotelLevelDataBase = new();
        ItemDataBase = new();
        NPCDataBase= new();
        FExploreDataBase = new();
        RecipeDataBase = new(RecipeLoader);
        roomManager = new RoomManager();
        componentFactory = new ComponentFactory();
        npcFactroy = new NPCFactory();
        Economy = new();
        Inventory = new Inventory(ItemDataBase);
        ForestExploreSystem = new ForestExploreSystem(Inventory, FExploreDataBase);

        Crafter = new Crafter(Inventory, RecipeDataBase);
        dispatcher = new CommandDispatcher(roomManager, GameTime,ForestExploreSystem,Economy,Inventory,Crafter);
        validator = new CommandValidator();
        Invoker = new(dispatcher,validator);
        factory = new HotelFactory(roomManager, componentFactory,Inventory,Economy);
        animationSystem =GameObject.FindFirstObjectByType<AnimationSystem>();

        guestComponentBuilder = new GuestComponentBuilder(npcFactroy, NPCDataBase);
        restaurantComponentBuilder = new RestaurantComponentBuilder(NPCDataBase,ItemDataBase,npcFactroy,Inventory);
        componentFactory.Register(Data.RoomType.GuestRoom, guestComponentBuilder);
        componentFactory.Register(Data.RoomType.Restaurant, restaurantComponentBuilder);
        //Register CommandValidator
        massacreValidator = new MassacreValidator(GameTime);
        validator.Register(massacreValidator);
    }
}
