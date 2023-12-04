using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class MainMenuScene : Scene
    {
        enum InputDir { Up, Down, Enter }
        InputDir Input_Key;
        AsciiSprite Sprite = new MainMenuSprite();
        Running running;
        private int MoveIndex;
        private Position CursurPosition;
        private bool GameStartTrue;
        public MainMenuScene(Running running) : base(running)
        {
        }
        private void Init()
        {
            GameStartTrue = false;
            MoveIndex = 0;
            CursurPosition = new Position(45, 15);
        }
        public override void Render()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Sprite.SpriteRender();
            Console.ResetColor();

            Console.SetCursorPosition(30, 15);
            Console.WriteLine("게임 시작");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("게임 종료");
        }

        public override void Update()
        {
            Init();
            Render();
            CursurRender(CursurPosition);
            while (!GameStartTrue)
            {
                Input();
                Render();
                ChoiceMenu();
                
            }
        }

        private void Input()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            ConsoleKey key = info.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Input_Key = InputDir.Up;
                    break;
                case ConsoleKey.DownArrow:
                    Input_Key = InputDir.Down;
                    break;
                case ConsoleKey.Enter:
                    Input_Key = InputDir.Enter;
                    break;
                default:
                    break;
            }
        }

        private void ChoiceMenu()
        {
            Position PrevCursur = CursurPosition;
            int MaxPosY = 16; //

            switch (Input_Key)
            {
                case InputDir.Up:
                    MoveIndex = 0;
                    CursurPosition.y--;
                    break;
                case InputDir.Down:
                    MoveIndex = 1;
                    CursurPosition.y++;
                    break;
                case InputDir.Enter:
                    if (MoveIndex == 0)
                    {
                        GameStartTrue = true;
                    }
                    else if (MoveIndex == 1)
                    {
                        Environment.Exit(0);
                    }
                    break;
                default:
                    ChoiceMenu();
                    break;
            }

            if (CursurPosition.y < 15)
            {
                CursurPosition.y = PrevCursur.y;
                MoveIndex = 0;
            }
            else if (CursurPosition.y > MaxPosY)
            {
                CursurPosition.y = PrevCursur.y;
                MoveIndex = 1;
            }


            CursurRender(CursurPosition);
        }
        private void CursurRender(Position CursurPos)
        {
            Console.SetCursorPosition(CursurPos.x, CursurPos.y);
            Console.WriteLine("<-");
        }

        public void GetRunning(Running running)
        {
            this.running = running;
        }
    }
}
