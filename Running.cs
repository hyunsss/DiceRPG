using DiceRPG;

public class Running
{

    Player player = Player.GetInstance();
    FightManager fightManager = FightManager.GetInstance();
    Map map = new Map();


    private void Init()
    {
        player.GetMap(map);
    }

    public void Run()
    {
        while (true)
        {
            Init();
            map.Update();
            player.Update();
            if(player.GetIsFight) {
                fightManager.Player_InArea(player);
            }
        }
        
    }

}