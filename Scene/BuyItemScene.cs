using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class BuyItemScene : Scene
    {
        List<Item> ShopItem_list = new List<Item>();
        enum InputDir { Up, Down, Enter }
        InputDir Input_Key;
        (int, int) CursurPosition;
        public int ItemIndex;
        public bool Entertrue;

        public BuyItemScene(Running running) : base(running)
        {
            ShopItem_list.Add(new SmallPotion());
            ShopItem_list.Add(new BigPotion());
            ShopItem_list.Add(new PowerPotion());
            
        }
        public void Init()
        {
            CursurPosition = (68, 2);
            ItemIndex = 0;
            Entertrue = false;
        }

        public override void Render()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();


            sb.Append("___________________________________________________________________________");
            Console.WriteLine(sb);
            foreach (Item item in ShopItem_list)
            {
                Console.WriteLine(UI.GetInstance.Item_UI(item));
            }


        }

        public override void Update()
        {
            Init();
            Render();
            CursurRender(CursurPosition);
            while (!Entertrue)
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
            int MaxPos_Y = 3 * ShopItem_list.Count;
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
                    if (Player.GetInstance.GetMoney > ShopItem_list[ItemIndex].GetPrize)
                    {
                        Player.GetInstance.GetMoney -= ShopItem_list[ItemIndex].GetPrize;
                        Player.GetInstance.GetItem(ShopItem_list[ItemIndex].DeepCopy(ShopItem_list[ItemIndex]));
                        Console.WriteLine(UI.GetInstance.LogMessage(UI.GetInstance.BUYITEM));
                        Thread.Sleep(800);
                    }
                    else
                    {
                        Console.WriteLine(UI.GetInstance.LogMessage(UI.GetInstance.NotEnoughMoney));
                        Thread.Sleep(800);
                    }
                    Entertrue = true;
                    break;
            }

            //Exception
            if (CursurPosition.Item2 < 2)
            {
                CursurPosition.Item2 = PrevCursurY;
                ItemIndex = PrevItemIndex;
            }
            else if (CursurPosition.Item2 > MaxPos_Y)
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



