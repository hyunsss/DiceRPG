using System.Runtime.CompilerServices;
using System;
using DiceRPG;

public class MapScene : Scene
{
    public enum MapDir { Block = '#', Monster = 'M' }
    enum MapIndexDir { BasicMap }
    public List<char[,]> MapList = new List<char[,]>();

    private int MapIndex = 0;

    

    public MapScene(Running running) : base(running)
    {
    }

    public int GetMapIndex
    {
        get { return MapIndex; }
        set { MapIndex = value; }
    }

    void Init()
    {
        
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
        for (int y = 0; y < Data.map.GetLength(0); y++)
        {
            for (int x = 0; x < Data.map.GetLength(1); x++)
            {
                System.Console.Write(Data.map[y, x]);
            }
            System.Console.WriteLine();
        }

        Console.SetCursorPosition(Player.GetInstance.pos.x, Player.GetInstance.pos.y);
        Console.WriteLine("P");

        foreach (Monster monster in Data.monsters)
        {
            Console.SetCursorPosition(monster.pos.x, monster.pos.y);
            Console.WriteLine("M");
        }
    }

    


















}