using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class ShopScene : Scene
    {
        SkillInventoryScene skillinventoryScene;
        BuyItemScene buyItemScene;

        public ShopScene(Running running) : base(running)
        {

        }

        public override void Render()
        {
            UI.GetInstance.Shop_UI();
        }

        public override void Update()
        {

            Render();
            Input();

        }

        private void Input()
        {
            int answer = int.Parse(Console.ReadLine());
            while(answer != 3)
            {
                switch (answer)
                {
                    case 1:
                        //Todo 아이템 구매
                        buyItemScene.Update();
                        break;
                    case 2:
                        //Todo 스킬 구매
                        break;
                    case 3:
                        //Dice Skill List 스킬 강화
                        skillinventoryScene.Update();
                        break;
                    case 4:
                        //Todo 나가기
                        break;
                    default:
                        Input();
                        break;

                }
            }
           
        }














    }
}
