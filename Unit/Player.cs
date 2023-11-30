using DiceRPG;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks.Dataflow;

public class Player : SingleTon<Player>
{
    enum MoveDir { Up, Down, Left, Right, None }
    
    private int FullHp;
    private int Hp;
    private int Damage;
    public Position pos;
    private bool IsFight = false;
    public List<Skill> Player_Skills = new List<Skill>();
    public List<Item> Player_Items = new List<Item>(); 
    MoveDir Move_Key;

    ConsoleKeyInfo info;
    ConsoleKey key;


    public Player()
    {
        FullHp = 100;
        Hp = 100;
        Damage = 10;
        pos.x = 1;
        pos.y = 1;
        
    }
  
    public int GetPlayerHp { get { return Hp; } set { Hp = value; } }
    public int GetPlayerFullHp { get { return FullHp; } set { } }
    public int GetPlayerDamage { get { return Damage; } set { } }
    public bool GetIsFight { get { return IsFight; } set { IsFight = value; } }


    public void TestItemAdd()
    {
        Player_Items.Add(new Potion("큰 회복 물약", 50));
        Player_Items.Add(new Potion("작은 회복 물약", 30));
        Player_Items.Add(new Potion("작은 회복 물약", 30));
        Player_Items.Add(new Potion("작은 회복 물약", 30));
        Player_Items.Add(new Potion("작은 회복 물약", 30));
    }
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
        }

        NextPositionBlock(PrevPos);
    }

    private void NextPositionBlock(Position PrevPos)
    {
        if (Data.map[pos.y, pos.x] == (char)Map.MapDir.Block)
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
        Console.WriteLine("플레이어가 공격합니다!");

    }




}
