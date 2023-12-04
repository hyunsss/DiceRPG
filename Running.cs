using DiceRPG;

public class Running
{

    public FightScene fightManager;

    public InventoryScene inventoryScene;

    public Player player;
    public ShopScene shopScene;
    public MainMenuScene mainMenuScene;
    public SkillReinForceScene skillReinForceScene;
    public BuySkillScene buySkillScene;
    public SkillInventoryScene skillInventoryScene;
    public BuyDicePercentScene buyDicePercentScene;
    public BuyItemScene buyItemScene;
    public MapScene map;


    public void Init()
    {
        //콘솔 윈도우 사이즈
        Console.SetWindowSize(75, 54);
        Data.Init();
        Data.Level1();

        buySkillScene = new BuySkillScene(this);
        buyItemScene = new BuyItemScene(this);
        fightManager = new FightScene(this);
        inventoryScene = new InventoryScene(this);
        mainMenuScene = new MainMenuScene(this);
        skillReinForceScene = new SkillReinForceScene(this);
        skillInventoryScene = new SkillInventoryScene(this);
        buyDicePercentScene = new BuyDicePercentScene(this);
        shopScene = new ShopScene(this);
        map = new MapScene(this);

        player = Player.GetInstance;
        buySkillScene.GetRunning(this);
        skillInventoryScene.GetRunning(this);
        player.GetRunning(this);
        fightManager.GetRunning(this);
        shopScene.GetRunning(this);


        Dice.GetInstance.Init();
        Dice.GetInstance.DicePercent();
    //    Dice.GetInstance.NewDicePer(5, 60);
        Dice.GetInstance.DiceCurculate();

        player.GetMoney = 99999;
    }

    public void Run()
    {
        Init();
        mainMenuScene.Update();

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