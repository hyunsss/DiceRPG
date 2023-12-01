using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class ShopScene : Scene
    {
        SkillReinForceScene skillinventoryScene;
        BuyItemScene buyItemScene;
        Running running;
        bool IsExit;

        public ShopScene(Running running) : base(running)
        {

        }

        public void GetRunning(Running running)
        {
            this.running = running;
        }

        private void Init()
        {
            skillinventoryScene = running.skillInventoryScene;
            buyItemScene = running.buyItemScene;
            IsExit = false;
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine(UI.GetInstance.Shop_UI());
        }

        public override void Update()
        {
            Init();
            Render();
            Input();

        }

        private void Input()
        {
            string answer = "";
            while (!IsExit)
            {
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        //아이템 구매
                        buyItemScene.Update();
                        Render();
                        break;
                    case "2":
                        //Todo 스킬 구매

                        Render();
                        break;
                    case "3":
                        //Dice Skill List 스킬 강화
                        skillinventoryScene.Update();
                        Render();
                        break;
                    case "4":
                        //Todo 주사위 확률 강화

                        break;
                    case "5":
                        //나가기
                        IsExit = true;
                        break;
                    default:
                        Input();
                        break;

                }
            }
           
        }














    }
}
