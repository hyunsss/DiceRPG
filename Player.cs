using System.Threading.Tasks.Dataflow;

class Player {
    enum MoveDir {Up, Down, Left, Right, None}
    private int FullHp;
    private int Hp;
    private int Damage;
    private List<Skill> Player_Skills = new List<Skill>();
    MoveDir Move_Key;

    ConsoleKeyInfo info;
    ConsoleKey key;


    public Player() {
        FullHp = 100;
        Hp = 100;
        Damage = 10;
    }

    public void input() {
        info = Console.ReadKey();
        key = info.Key;

        switch(key) {
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

    public void Update() {

    }



}

class Skill {

}