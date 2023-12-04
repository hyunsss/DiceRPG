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
            Console.SetCursorPosition(Data.MapCursurPos.x, y);
            for (int x = 0; x < Data.map.GetLength(1); x++)
            {
                System.Console.Write(Data.map[y, x]);
            }
            System.Console.WriteLine();
        }
        Console.WriteLine(UI.GetInstance.LogMessage($"방향키 이동 | Q : 상점으로 이동 | 현재 돈 : {Player.GetInstance.GetMoney}")); 

        Console.SetCursorPosition(Data.MapCursurPos.x + Player.GetInstance.pos.x, Player.GetInstance.pos.y);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("P");
        Console.ResetColor();

        foreach (Monster monster in Data.monsters)
        {
            Console.SetCursorPosition(Data.MapCursurPos.x + monster.pos.x, monster.pos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("M");
        }
        Console.ResetColor();
    }

    


















}