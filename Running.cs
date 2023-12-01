using DiceRPG;

public class Running
{

    Player player;
    FightManager fightManager;
    InventoryScene inventoryScene;
    Map map;


    public void Init()
    {
        //�ܼ� ������ ������
        Console.SetWindowSize(75, 54);

        Data.Init();

        player = Player.GetInstance;
        fightManager = new FightManager(this);
        inventoryScene = new InventoryScene(this);
        fightManager.GetInventoryScene(inventoryScene);
        map = new Map(this);
        Dice.GetInstance.DicePercent();
        Dice.GetInstance.NewDicePer(5, 60);
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