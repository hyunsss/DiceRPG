using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class BuyDicePercentScene : Scene
    {
        enum InputDir { Up, Down, Enter }
        InputDir Input_Key;
        (int, int) CursurPosition;
        public int DiceIndex;
        public bool Entertrue;
        public BuyDicePercentScene(Running running) : base(running)
        {
        }

        public void Init()
        {
            CursurPosition = (68, 6);
            DiceIndex = 0;
            Entertrue = false;
        }

        public override void Render()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine(UI.GetInstance.LogMessage(UI.GetInstance.DICEPERUPGRADEBEFORE));
            sb.Append("___________________________________________________________________________");
            Console.WriteLine(sb);
            int index = 0;
            foreach (double a in Dice.GetInstance.GetDicePer)
            {
                Console.WriteLine(UI.GetInstance.DicePercent_UI(index + 1, a));
                index++;
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
            int MaxPos_Y = 3 * Dice.GetInstance.GetDicePer.Length + 5;
            int PrevCursurY = CursurPosition.Item2;
            int PrevDiceIndex = DiceIndex;



            switch (Input_Key)
            {
                case InputDir.Up:
                    CursurPosition.Item2 -= 3;
                    DiceIndex--;
                    break;
                case InputDir.Down:
                    CursurPosition.Item2 += 3;
                    DiceIndex++;
                    break;
                case InputDir.Enter:
                    if (Player.GetInstance.GetMoney > 500)
                    {
                        Player.GetInstance.GetMoney -= 500;
                        Dice.GetInstance.NewDicePer(DiceIndex + 1, 5);
                        Dice.GetInstance.DiceCurculate();
                        Console.WriteLine(UI.GetInstance.LogMessage(UI.GetInstance.DICEPERUPGRADEAFTER));
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
            if (CursurPosition.Item2 < 6)
            {
                CursurPosition.Item2 = PrevCursurY;
                DiceIndex = PrevDiceIndex;
            }
            else if (CursurPosition.Item2 > MaxPos_Y)
            {
                CursurPosition.Item2 = PrevCursurY;
                DiceIndex = PrevDiceIndex;
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
