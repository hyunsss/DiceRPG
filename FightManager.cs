using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class FightManager : SingleTon<FightManager>
    {
        enum RandomMonster { Flowey, GreatDog, Wimson, Jery }
        Monster monster = null;

        public void Player_InArea(Player player)
        {
            CreateRandomMonster(out monster);
            Renderer();
            Fight(monster, player);
        }

        private static void CreateRandomMonster(out Monster monster)
        {

            Random rand = new Random();
            int respawn = rand.Next(0, 3);

            switch (respawn)
            {
                case (int)RandomMonster.Flowey:
                    monster = new Flowey();
                    break;
                case (int)RandomMonster.GreatDog:
                    monster = new GreatDog();
                    break;
                case (int)RandomMonster.Wimson:
                    monster = new Wimson();
                    break;
                case (int)RandomMonster.Jery:
                    monster = new Jery();
                    break;
                default:
                    Console.WriteLine("CreateRandomMonster(). Default Exception");
                    monster = null;
                    break;
            }
        }

        private void Fight(Monster monster, Player player)
        {
            bool PlayerAttackTrue = true;
            bool HasDie = false;
            while (!HasDie)
            {

                //플레이어 공격 턴
                if (PlayerAttackTrue)
                {
                    string answer = Console.ReadLine();

                    switch (answer)
                    {
                        case "1":
                            //공격하기
                            player.Attack(monster);
                            Thread.Sleep(200);
                            Renderer();
                            break;
                        case "2":
                            //아이템 사용
                            break;
                        case "3":
                            //도망가기
                            player.GetIsFight = false;
                            return;
                        default:
                            continue;
                    }
                    PlayerAttackTrue = false;
                }
                //몬스터 공격 턴
                else
                {
                    monster.Attack(player);
                    Renderer();
                    PlayerAttackTrue = true;
                }

                if (monster.GetHp <= 0)
                {
                    System.Console.WriteLine("몬스터를 쓰러트렸습니다!! ");
                    player.GetIsFight = false;
                    HasDie = true;
                }
                else if (player.GetPlayerHp <= 0)
                {
                    System.Console.WriteLine("플레이어가 쓰러졌습니다....");
                    player.GetIsFight = false;
                    HasDie = true;
                    //Todo 게임 종료 함수
                }
            }

        }


        private void Renderer()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            monster.Sprite.SpriteRender();
            Console.WriteLine("\n\n\n");
            System.Console.WriteLine(Monster_Status());
            Console.WriteLine("\t 1. 공격하기  \t   2. 아이템 사용  \t 3. 도망가기");
            Console.WriteLine(User_Status());


        }

        private StringBuilder Monster_Status() {
            StringBuilder Monster_UI = new StringBuilder();

            Monster_UI.AppendFormat("___________________________________________________________________________\n");
            Monster_UI.AppendFormat("|                                                                         |\n");
            Monster_UI.AppendFormat("|  몬스터 : {0}   체력 {1} / {2}   데미지 : {3}                               |\n", monster.GetName, monster.GetHp, monster.GetFullHp, monster.GetDamage );
            Monster_UI.AppendFormat("|_________________________________________________________________________|\n");


            return Monster_UI;
        }

        private StringBuilder User_Status()
        {
            StringBuilder Player_UI = new StringBuilder();
            DiceNumber dicenumber = new DiceNumber();
            int num = SettingDiceNumber();

            Player_UI.AppendFormat("___________________________________________________________________________\n");
            Player_UI.AppendFormat("|{0}|                                                       |\n", dicenumber.Dice[num,0]);
            Player_UI.AppendFormat("|{0}|  1 확률 : {1}     2 확률 : {2}      3 확률 : {3}       |\n", dicenumber.Dice[num,1],1,1,1);
            Player_UI.AppendFormat("|{0}|_______________________________________________________|\n", dicenumber.Dice[num,2]);
            Player_UI.AppendFormat("|{0}|                                                       |\n", dicenumber.Dice[num,3]);
            Player_UI.AppendFormat("|{0}|  4 확률 : {1}     5 확률 : {2}      6 확률 : {3}       |\n", dicenumber.Dice[num,4],1,1,1);
            Player_UI.AppendFormat("|{0}|_______________________________________________________|\n", dicenumber.Dice[num,5]);
            Player_UI.AppendFormat("|{0}|                                                       |\n", dicenumber.Dice[num,6]);
            Player_UI.AppendFormat("|{0}|  주사위 능력 : {1}                                     |\n", dicenumber.Dice[num,7], 1);
            Player_UI.AppendFormat("|_________________|_______________________________________________________|\n");
            Player_UI.AppendFormat("|                  |                                                      |\n");
            Player_UI.AppendFormat("| 체력 : {0} / {1} |  일반 데미지 : {2}  스킬 데미지 :                     |\n", Player.GetInstance().GetPlayerHp, Player.GetInstance().GetPlayerFullHp, Player.GetInstance().GetPlayerDamage);
            Player_UI.AppendFormat("|__________________|______________________________________________________|\n");
            return Player_UI;

        }

        private static int SettingDiceNumber()
        {
            Random rand = new Random();
            int Num = rand.Next(1, 6);

            return Num;
        }
    }
}
