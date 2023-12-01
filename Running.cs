using DiceRPG;

public class Running
{

    public FightManager fightManager;

    public InventoryScene inventoryScene;

    public Player player;
    public ShopScene shopScene;
    public SkillReinForceScene skillInventoryScene;
    public BuyItemScene buyItemScene;

    public Map map;


    public void Init()
    {
        //콘솔 윈도우 사이즈
        Console.SetWindowSize(75, 54);

        player = Player.GetInstance;
        player.GetRunning(this);
        Data.Init();
        Dice.GetInstance.Init();
        fightManager = new FightManager(this);
        inventoryScene = new InventoryScene(this);
        shopScene = new ShopScene(this);
        skillInventoryScene = new SkillReinForceScene(this);
        buyItemScene = new BuyItemScene(this);
        shopScene.ShopSceneInit(skillInventoryScene, buyItemScene);
        fightManager.GetInventoryScene(inventoryScene);
        map = new Map(this);
        Dice.GetInstance.DicePercent();
    //    Dice.GetInstance.NewDicePer(5, 60);
        Dice.GetInstance.DiceCurculate();
        Data.Level1();
        
    }

    public void Run()
    {
        Init();

        while (true)
        {
            map.Update();
            player.Update();
            foreach (Monster monster in Data.monsters)
            {
                monster.MoveAction();
            }
            if (player.GetIsFight) {
                fightManager.Update();
            }
        }
        
    }

}