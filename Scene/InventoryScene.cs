﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class InventoryScene : Scene
    {
        enum InputDir { Up, Down, Enter }
        InputDir Input_Key;
        (int, int) CursurPosition;
        public int ItemIndex;
        public bool Usetrue;
        public InventoryScene(Running running) : base(running)
        {
        }

        public void Init()
        {
            CursurPosition = (68, 2);
            ItemIndex = 0;
            Usetrue = false;
        }

        public override void Render()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            if (Player.GetInstance.Player_Items.Count != 0)
            {
                sb.Append("___________________________________________________________________________");
                Console.WriteLine(sb);
                foreach (Item item in Player.GetInstance.Player_Items)
                {
                    Console.WriteLine(UI.GetInstance.Item_UI(item));
                }
            }
            else
            {
                sb.Append("\n\n 아이템이 존재하지 않습니다 !!! Enter눌러 나가기");
                Console.WriteLine(sb);
            }


        }


        public override void Update()
        {
            Init();
            Render();
            CursurRender(CursurPosition);
            while (!Usetrue)
            {

                Input();
                Render();
                ItemDirection();
            }

            return;
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

        private void ItemDirection()
        {
            int MaxPos_Y = 3 * Player.GetInstance.Player_Items.Count;
            int PrevCursurY = CursurPosition.Item2;
            int PrevItemIndex = ItemIndex;



            switch (Input_Key)
            {
                case InputDir.Up:
                    CursurPosition.Item2 -= 3;
                    ItemIndex--;
                    break;
                case InputDir.Down:
                    CursurPosition.Item2 += 3;
                    ItemIndex++;
                    break;
                case InputDir.Enter:
                    if(Player.GetInstance.Player_Items.Count != 0)
                    {
                    Player.GetInstance.Player_Items[ItemIndex].Use();
                    }
                    Usetrue = true;
                    break;
            }

            //Exception
            if (CursurPosition.Item2 < 2)
            {
                CursurPosition.Item2 = PrevCursurY;
                ItemIndex = PrevItemIndex;
            } else if (CursurPosition.Item2 > MaxPos_Y)
            {
                CursurPosition.Item2 = PrevCursurY;
                ItemIndex = PrevItemIndex;
            }


            CursurRender(CursurPosition);
        }

        private void CursurRender((int, int) CursurPos)
        {
            Console.SetCursorPosition(CursurPos.Item1, CursurPos.Item2);
            Console.WriteLine("<-");
        }
    }
}
