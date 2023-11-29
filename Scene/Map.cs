using System.Runtime.CompilerServices;
using System;
using DiceRPG;

public class Map : Scene
{
    enum MapIndexDir { BasicMap }
    public List<char[,]> MapList = new List<char[,]>();
    Player player = Player.GetInstance;
    private int MapIndex = 0;

    char[,] BasicMap =
    {
    {'#','#','#','#','#'},
    {'#',' ',' ',' ','#'},
    {'#',' ',' ','M','#'},
    {'#',' ',' ','#','#'},
    {'#',' ',' ','#','#'},
    {'#',' ',' ',' ','#'},
    {'#','#','#','#','#'}

  };

    public Map(Running running) : base(running)
    {
    }

    public int GetMapIndex
    {
        get { return MapIndex; }
        set { MapIndex = value; }
    }

    void Init()
    {
        MapList.Add(BasicMap);
    }

    public override void Update()
    {
        Init();
        Render();
    }

    public override void Render()
    {
        PrintMap();
    }

    private void PrintMap()
    {
        System.Console.Clear();
        for (int y = 0; y < MapList[MapIndex].GetLength(0); y++)
        {
            for (int x = 0; x < MapList[MapIndex].GetLength(1); x++)
            {
                System.Console.Write(MapList[MapIndex][y, x]);
            }
            System.Console.WriteLine();
        }

        Console.SetCursorPosition(player.GetPlayerPosX, player.GetPlayerPosY);
        Console.WriteLine("P");
    }

    


















}