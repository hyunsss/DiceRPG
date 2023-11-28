using System.Runtime.CompilerServices;
using System;
public class Map
{
    public List<char[,]> MapList = new List<char[,]>();
    Player player;
    private int MapIndex = 0;

    char[,] BasicMap =
    {
    {'#','#','#','#','#'},
    {'#',' ',' ',' ','#'},
    {'#',' ',' ',' ','#'},
    {'#',' ',' ','#','#'},
    {'#',' ',' ','#','#'},
    {'#',' ',' ',' ','#'},
    {'#','#','#','#','#'}

  };


    void Init()
    {
        MapList.Add(BasicMap);
    }

    public void Update()
    {
        Init();
        Renderer();
    }


    void Renderer()
    {

        System.Console.Clear();
        for (int y = 0; y < BasicMap.GetLength(0); y++)
        {
            for (int x = 0; x < BasicMap.GetLength(1); x++)
            {
                System.Console.Write(BasicMap[y, x]);
            }
            System.Console.WriteLine();
        }

        Console.SetCursorPosition(player.GetPlayerPosX, player.GetPlayerPosY);
        Console.WriteLine("P");

    }

    public int GetMapIndex
    {
        get { return MapIndex; } set { MapIndex = value; }
    }

    public void GetPlayer(Player player)
    {
        this.player = player;
    }

















}