using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class FightManager
    {
        enum RandomMonster { Flowey, GreatDog, Wimson, Jery }

        StringBuilder Sprite;


        private static void SetCursur(int a, int b) {
            Console.SetCursorPosition(a, b);
        }
        public void Player_InArea(Player player)
        {
            Monster monster;
            CreateRandomMonster(out monster);
            Fight(monster, player);
        }
        //https://passwordkim.tistory.com/21
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
                    //
                }
                //몬스터 공격 턴
                else
                {
                    monster.Attack();
                }

                if (monster.GetHp <= 0)
                {
                    System.Console.WriteLine("몬스터를 쓰러트렸습니다!! ");
                    HasDie = true;
                }
                else if (player.GetPlayerHp <= 0)
                {
                    System.Console.WriteLine("플레이어가 쓰러졌습니다....");
                    HasDie = true;
                    //Todo 게임 종료 함수
                }
            }

        }


        private void Renderer()
        {
            Console.Clear();



            
        }

        private static StringBuilder User_Status(Player player)
        {
            StringBuilder UI = new StringBuilder();
            string str1 = "========================================================================";
            string str2 = "=               == 주사위 능력  :       ===================================";
            string str3 = "=               ==                                        ==============";
            string str4 = "=               ==                                        ==============";
            string str5 = "=               ========================================================";
            string str6 = "=               ========================================================";
            string str7 = "=               ========================================================";
            string str8 = "========================================================================";
            string str9 = "== 체력 : hp/fullhp : 일반 데미지 :  스킬 데미지 :       ======================";
            string str10 = "========================================================================";

            return UI;
        }

    }
}
