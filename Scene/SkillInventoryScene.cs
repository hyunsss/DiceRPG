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
            CursurPosition = (68, 2);
            SkillIndex = 0;
            Checktrue = false;

            
        }
        public override void Render()
        {
            Console.Clear();
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
            int MaxPos_Y = 3 * Dice.GetInstance.GetSkill.Length;
            int PrevCursurY = CursurPosition.Item2;
            int PrevSkillIndex = SkillIndex;



            switch (Input_Key)
            {
                case InputDir.Up:
                    CursurPosition.Item2 -= 3;
                    SkillIndex--;
                    break;
                case InputDir.Down:
                    CursurPosition.Item2 += 3;
                    SkillIndex++;
                    break;
                case InputDir.Enter:
                    //Todo : BuySkillScene에서 원하는 스킬을 고른 후 여기서는 
                    //다이스 스킬의 원하는 인덱스에서 바꿔주는 역할 
                    if (Player.GetInstance.GetMoney > Dice.GetInstance.GetSkill[SkillIndex].GetReinforcePrize)
                    {
                        Player.GetInstance.GetMoney -= Dice.GetInstance.GetSkill[SkillIndex].GetReinforcePrize;
                        Dice.GetInstance.GetSkill[SkillIndex].SkillReinForce();
                    }
                    else
                    {
                        Console.WriteLine("\n\n플레이어의 돈이 부족합니다!! ");
                        Thread.Sleep(800);
                    }
                    Checktrue = true;
                    break;
            }

            //Exception
            if (CursurPosition.Item2 < 2)
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
    }
}
