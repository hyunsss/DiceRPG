using DiceRPG;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks.Dataflow;

public class Player : SingleTon<Player>
{
    enum MoveDir { Up, Down, Left, Right, Shop, None }

    Running running;

    private int Money;
    private int FullHp;
    private int Hp;
    private int Damage;
    private bool IsFight = false;
    private int SkillDamage;

    //public List<Skill> Player_Skills = new List<Skill>();
    public List<Item> Player_Items = new List<Item>(); 
    public Position pos;


    MoveDir Move_Key;
    ConsoleKeyInfo info;
    ConsoleKey key;


    public Player()
    {
        Money = 1000;
        FullHp = 100;
        Hp = 100;
        Damage = 10;
        pos.x = 1;
        pos.y = 1;
    }
  
    public void GetItem(Item item)
    {
        Player_Items.Add(item);
        Console.WriteLine("{0}을 구매했습니다!!", item.GetName );
    }

    public int GetMoney { get { return Money; } set { Money = value; } }
    public int GetPlayerHp { get { return Hp; } set { Hp = value; } }
    public int GetPlayerFullHp { get { return FullHp; } set { FullHp = value; } }
    public int GetPlayerDamage { get { return Damage; } set { Damage = value; } }
    public int GetPlayerSkillDamage { get { return SkillDamage; } set { SkillDamage = value; } }
    public bool GetIsFight { get { return IsFight; } set { IsFight = value; } }

    public void Init()
    {
    }

    public void Update()
    {
        Init();
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
            case ConsoleKey.Q:
                Move_Key = MoveDir.Shop;
                break;
            default:
                Move_Key = MoveDir.None;
                break;
        }
    }

    private void Move()
    {
        Position PrevPos = pos;
        
        switch (Move_Key)
        {
            case MoveDir.Up:
                pos.y--;
                break;
            case MoveDir.Down:
                pos.y++;
                break;
            case MoveDir.Left:
                pos.x--;
                break;
            case MoveDir.Right:
                pos.x++;
                break;
            case MoveDir.Shop:
                running.shopScene.Update();
                break;
        }

        NextPositionBlock(PrevPos);
    }

    private void NextPositionBlock(Position PrevPos)
    {
        if (Data.map[pos.y, pos.x] == (char)MapScene.MapDir.Block)
        {
            pos.y = PrevPos.y;
            pos.x = PrevPos.x;
        }
        else if (Data.MonsterInPos(pos) != null)
        {
/*            pos.y = PrevPos.y;
            pos.x = PrevPos.x;*/
            IsFight = true;
        }
    }

    public void Attack(Monster monster)
    {
        monster.GetHp -= Damage;
        Console.WriteLine(UI.GetInstance.LogMessage(UI.GetInstance.ATTACKPLAYER));

    }

    public void SkillAttack(Monster monster)
    {
        monster.GetHp -= SkillDamage;
        Console.WriteLine(UI.GetInstance.LogMessage(UI.GetInstance.USESKILLPLAYER));
    }

    public void GetRunning(Running running)
    {
        this.running = running;
    }


}
