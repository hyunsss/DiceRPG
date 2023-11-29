using DiceRPG;

public class Running
{

    Player player;
    FightManager fightManager;
    Map map;


    private void Init()
    {
        //�ܼ� ������ ������
        Console.SetWindowSize(75, 48);


        player = Player.GetInstance;
        fightManager = new FightManager(this);
        
        map = new Map(this);
        player.GetMap(map);

        Dice.GetInstance.DicePercent();
        Dice.GetInstance.DiceCurculate();
    }

    public void Run()
    {
        Init();

        while (true)
        {
            map.Update();
            player.Update();
            if(player.GetIsFight) {
                fightManager.Update();
            }
        }
        
    }

}