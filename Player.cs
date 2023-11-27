using System.Threading.Tasks.Dataflow;

public class Player
{
    enum MoveDir { Up, Down, Left, Right, None }
    private int FullHp;
    private int Hp;
    private int Damage;
    private int PlayerPosX;
    private int PlayerPosY;
    private List<Skill> Player_Skills = new List<Skill>();
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
                PlayerPosY++;
                break;

        }



    }


}

class Skill
{

}