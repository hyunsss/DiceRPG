using DiceRPG;

public class Running
{

    Player player;
    FightManager fightManager;
    InventoryScene inventoryScene;
    Map map;


    private void Init()
    {
        //콘솔 윈도우 사이즈
        Console.SetWindowSize(75, 48);

        Data.Init();

        player = Player.GetInstance;
        fightManager = new FightManager(this);
        inventoryScene = new InventoryScene(this);
        fightManager.GetInventoryScene(inventoryScene);
        map = new Map(this);
        Dice.GetInstance.DiceCurculate();
        Data.Level1();
        
    }

    public void Run()
    {
        Init();
        player.TestItemAdd();
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