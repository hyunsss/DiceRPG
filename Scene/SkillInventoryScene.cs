using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class SkillInventoryScene : Scene
    {
        enum InputDir { Up, Down, Enter }
        BuySkillScene BuySkillScene;
        Running running;
        InputDir Input_Key;
        (int, int) CursurPosition;
        public int SkillIndex;
        public int DiceSkillIndex;
        public bool Checktrue;

        public SkillInventoryScene(Running running) : base(running)
        {
        }

        public void Init()
        {
            BuySkillScene = running.buySkillScene;
            CursurPosition = (68, 10);
            SkillIndex = 0;
            Checktrue = false;

            
        }
        public override void Render()
        {
            Console.Clear();
            Console.WriteLine(UI.GetInstance.ChangeSkills_UI(BuySkillScene.Shop_Skills[BuySkillScene.SkillIndex]));
            StringBuilder sb = new StringBuilder();
            sb.Append("___________________________________________________________________________");
            Console.WriteLine(sb);
            foreach (Skill skill in Dice.GetInstance.GetSkill)
            {
                Console.WriteLine(UI.GetInstance.DiceSkills_UI(skill));
            }


        }

        public override void Update()
        {
            Init();
            Render();
            CursurRender(CursurPosition);
            while (!Checktrue)
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
            int MaxPos_Y = 4 * Dice.GetInstance.GetSkill.Length + 9;
            int PrevCursurY = CursurPosition.Item2;
            int PrevSkillIndex = SkillIndex;



            switch (Input_Key)
            {
                case InputDir.Up:
                    CursurPosition.Item2 -= 4;
                    SkillIndex--;
                    break;
                case InputDir.Down:
                    CursurPosition.Item2 += 4;
                    SkillIndex++;
                    break;
                case InputDir.Enter:
                    //Todo : BuySkillScene에서 원하는 스킬을 고른 후 여기서는 
                    //다이스 스킬의 원하는 인덱스에서 바꿔주는 역할 
                    Player.GetInstance.GetMoney -= BuySkillScene.Shop_Skills[BuySkillScene.SkillIndex].GetPrize;
                    Dice.GetInstance.GetSkill[SkillIndex] = BuySkillScene.Shop_Skills[BuySkillScene.SkillIndex];
                    Console.WriteLine(UI.GetInstance.LogMessage(UI.GetInstance.ChangeSkill)); 
                    Thread.Sleep(800);
                    Checktrue = true;
                    break;
            }

            //Exception
            if (CursurPosition.Item2 < 10)
            {
                CursurPosition.Item2 = PrevCursurY;
                SkillIndex = PrevSkillIndex;
            }
            else if (CursurPosition.Item2 > MaxPos_Y)
            {
                CursurPosition.Item2 = PrevCursurY;
                SkillIndex = PrevSkillIndex;
            }


            CursurRender(CursurPosition);
        }

        private void CursurRender((int, int) CursurPos)
        {
            Console.SetCursorPosition(CursurPos.Item1, CursurPos.Item2);
            Console.WriteLine("<-");
        }

        public void GetRunning(Running running)
        {
            this.running = running;
        }
    }
}
