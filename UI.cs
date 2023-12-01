using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class UI : SingleTon<UI>
    {
        public int num;

        public StringBuilder Status(Monster monster)
        {
            
            StringBuilder UI_Status = new StringBuilder();
            //주사위 번호를 보이기위한 초기화
            DiceNumber dicenumber = new DiceNumber();

            UI_Status.AppendFormat("___________________________________________________________________________\n");
            UI_Status.AppendFormat("|                                                                         |\n");
            UI_Status.AppendFormat("|  몬스터 : {0}   체력 {1} / {2}   데미지 : {3}                               \n", monster.GetName, monster.GetHp, monster.GetFullHp, monster.GetDamage);
            UI_Status.AppendFormat("|_________________________________________________________________________|\n");
            UI_Status.AppendFormat("\n   1. 공격하기   2. 아이템 사용   3. 스킬 사용   4. 도망가기\n");
            UI_Status.AppendFormat("___________________________________________________________________________\n");
            UI_Status.AppendFormat("|{0}|                                                       |\n", dicenumber.Dice[num, 0]);
            UI_Status.AppendFormat("|{0}|  1 확률 : {1}%     2 확률 : {2}%      3 확률 : {3}%      \n", dicenumber.Dice[num, 1], Dice.GetInstance.DiceLoad(1), Dice.GetInstance.DiceLoad(2), Dice.GetInstance.DiceLoad(3));
            UI_Status.AppendFormat("|{0}|_______________________________________________________|\n", dicenumber.Dice[num, 2]);
            UI_Status.AppendFormat("|{0}|                                                       |\n", dicenumber.Dice[num, 3]);
            UI_Status.AppendFormat("|{0}|  4 확률 : {1}%     5 확률 : {2}%      6 확률 : {3}%      \n", dicenumber.Dice[num, 4], Dice.GetInstance.DiceLoad(4), Dice.GetInstance.DiceLoad(5), Dice.GetInstance.DiceLoad(6));
            UI_Status.AppendFormat("|{0}|_______________________________________________________|\n", dicenumber.Dice[num, 5]);
            UI_Status.AppendFormat("|{0}|                                                       |\n", dicenumber.Dice[num, 6]);
            UI_Status.AppendFormat("|{0}|  주사위 능력 : {1}                                     \n", dicenumber.Dice[num, 7], Dice.GetInstance.GetSkill[num].Summary());
            UI_Status.AppendFormat("|_________________|_______________________________________________________|\n");
            UI_Status.AppendFormat("|                                                                         |\n");
            UI_Status.AppendFormat("| 체력 : {0} / {1}    일반 데미지 : {2}  스킬 데미지 :                     \n", Player.GetInstance.GetPlayerHp, Player.GetInstance.GetPlayerFullHp, Player.GetInstance.GetPlayerDamage);
            UI_Status.AppendFormat("|_________________________________________________________________________|\n");
            return UI_Status;
        }

        public StringBuilder Item_UI(Item item)
        {
            StringBuilder Inven_UI = new StringBuilder();

            Inven_UI.AppendFormat("|                                                                         |\n");
            Inven_UI.AppendFormat("|  {0}  설명 : {1}                                                         \n",item.GetName,item.GetSummary);
            Inven_UI.AppendFormat("|_________________________________________________________________________|");

            return Inven_UI;
        }

        public StringBuilder DiceSkills_UI(Skill skills)
        {
            StringBuilder MySkills_UI = new StringBuilder();

            MySkills_UI.AppendFormat("|                                                                         |\n");
            MySkills_UI.AppendFormat("|  {0}  설명 : {1}                                                 \n",skills.GetName ,skills.Summary());
            MySkills_UI.AppendFormat("|  레벨 : {0}     강화 비용 : {1}                                   \n",skills.Getlevel ,skills.GetReinforcePrize);
            MySkills_UI.AppendFormat("|_________________________________________________________________________|");

            return MySkills_UI;
        }
        public StringBuilder Shop_UI()
        {
            StringBuilder MySkills_UI = new StringBuilder();

            MySkills_UI.AppendFormat("|                                                                         |\n");
            MySkills_UI.AppendFormat("|  1. 아이템 구매   2. 스킬 구매    현재 돈 : {0}      \n",Player.GetInstance.GetMoney);
            MySkills_UI.AppendFormat("|                                                                         |\n");
            MySkills_UI.AppendFormat("|  3. 스킬 강화     4. 주사위 확률   4. 나가기 \n", Player.GetInstance.GetMoney);
            MySkills_UI.AppendFormat("|                                                                         |\n");
            MySkills_UI.AppendFormat("|_________________________________________________________________________|");

            return MySkills_UI;
        }




    }
}
