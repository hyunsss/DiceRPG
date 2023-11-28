using DiceRPG;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks.Dataflow;

public class Player : SingleTon<Player>
{
    FightManager fightManager = new FightManager();
    enum MoveDir { Up, Down, Left, Right, None }
    enum MapDir { Block = '#', Monster = 'M' }
    private int FullHp;
    private int Hp;
    private int Damage;
    private int PlayerPosX;
    private int PlayerPosY;
    private int DiceNumber;
    private bool IsFight = false;
    private List<Skill> Player_Skills = new List<Skill>();
    int Mapindex;
    private Map map;
    MoveDir Move_Key;

    ConsoleKeyInfo info;
    ConsoleKey key;


    public Player()
    {
        FullHp = 100;
        Hp = 100;
        Damage = 10;
        PlayerPosX = 1;
        PlayerPosY = 1;
    }
    public int GetPlayerPosX { get { return PlayerPosX; } set { } }
    public int GetPlayerPosY { get { return PlayerPosY; } set { } }
    public int GetPlayerHp { get { return Hp; } set { Hp = value; } }
    public int GetPlayerFullHp { get { return FullHp; } set { } }
    public int GetPlayerDamage { get { return Damage; } set { } }
    public bool GetIsFight { get { return IsFight; } set { IsFight = value; } }

    public void Init()
    {
        int Mapindex = map.GetMapIndex;
    }

    public void Update()
    {
        Input();
        Move();
    }

    private void Input()
    {
        info = Console.ReadKey();
        key = info.Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                Move_Key = MoveDir.Up;
                break;
            case ConsoleKey.DownArrow:
                Move_Key = MoveDir.Down;
                break;
            case ConsoleKey.LeftArrow:
                Move_Key = MoveDir.Left;
                break;
            case ConsoleKey.RightArrow:
                Move_Key = MoveDir.Right;
                break;
            default:
                Move_Key = MoveDir.None;
                break;
        }
    }

    private void Move()
    {
        int prevPosX = PlayerPosX;
        int prevPosY = PlayerPosY;
        switch (Move_Key)
        {
            case MoveDir.Up:
                PlayerPosY--;
                break;
            case MoveDir.Down:
                PlayerPosY++;
                break;
            case MoveDir.Left:
                PlayerPosX--;
                break;
            case MoveDir.Right:
                PlayerPosX++;
                break;
        }

        NextPositionBlock(prevPosY, prevPosX);
    }

    private void NextPositionBlock(int prevPosY, int prevPosX)
    {
        if (map.MapList[Mapindex][PlayerPosY, PlayerPosX] == (char)MapDir.Block)
        {
            PlayerPosY = prevPosY;
            PlayerPosX = prevPosX;
        }
        else if (map.MapList[Mapindex][PlayerPosY, PlayerPosX] == (char)MapDir.Monster)
        {
            IsFight = true;
        }
    }

    public void Attack(Monster monster)
    {
        monster.GetHp -= Damage;
        Console.WriteLine("플레이어가 공격합니다!");
    }


    public void GetMap(Map map)
    {
        this.map = map;
    }

    



}

class Skill
{

}