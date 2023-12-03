using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class BuySkillScene : Scene
    {
        //Todo BuySkillScene
        List<Skill> Shop_Skills = new List<Skill>();
        Running running;
        SkillInventoryScene SkillInventoryScene;
        enum InputDir { Up, Down, Enter }
        InputDir Input_Key;
        (int, int) CursurPosition;
        public int SkillIndex;
        public int DiceSkillIndex;
        public bool Checktrue;

        public BuySkillScene(Running running) : base(running)
        {
        }

        public void Init()
        {
            SkillInventoryScene = running.skillInventoryScene;
            CursurPosition = (68, 2);
            SkillIndex = 0;
            Checktrue = false;

            Shop_Skills.Add(new Bang());
            Shop_Skills.Add(new Faint());
            Shop_Skills.Add(new RecoveryHP());
            Shop_Skills.Add(new NormalStronger());
            Shop_Skills.Add(new MonsterWeek());
            Shop_Skills.Add(new GetMoneyMultiply());
        }
        public override void Render()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append("___________________________________________________________________________");
            Console.WriteLine(sb);
            foreach (Skill skill in Shop_Skills)
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
                    //Todo : SkillInventoryScene Create
                    //원하는 스킬을 고를 수 있는 탭. 스킬 가격과 플레이어 머니의 조건체크는 여기서 함.
                    if(Player.GetInstance.GetMoney > Shop_Skills[SkillIndex].GetPrize)
                    {

                    } else
                    {
                        Console.WriteLine(UI.GetInstance.NOTENOUGHMONEY());
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

        public void GetRunning(Running running)
        {
            this.running = running;
        }
    }
}
