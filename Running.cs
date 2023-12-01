using DiceRPG;

public class Running
{

    public FightScene fightManager;

    public InventoryScene inventoryScene;

    public Player player;
    public ShopScene shopScene;
    public SkillReinForceScene skillInventoryScene;
    public BuyItemScene buyItemScene;
    public MapScene map;


    public void Init()
    {
        //콘솔 윈도우 사이즈
        Console.SetWindowSize(75, 54);
        Data.Init();
        Data.Level1();

        buyItemScene = new BuyItemScene(this);
        fightManager = new FightScene(this);
        inventoryScene = new InventoryScene(this);
        skillInventoryScene = new SkillReinForceScene(this);
        shopScene = new ShopScene(this);
        map = new MapScene(this);

        player = Player.GetInstance;
        player.GetRunning(this);
        fightManager.GetRunning(this);
        shopScene.GetRunning(this);


        Dice.GetInstance.Init();
        Dice.GetInstance.DicePercent();
    //    Dice.GetInstance.NewDicePer(5, 60);
        Dice.GetInstance.DiceCurculate();

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