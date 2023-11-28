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
        Monster monster;

        private static void SetCursur(int a, int b)
        {
            Console.SetCursorPosition(a, b);
        }
        public void Player_InArea(Player player)
        {
            CreateRandomMonster(out monster);
            Renderer();
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
            System.Console.Clear();
            SetCursur(5, 0);
            System.Console.WriteLine(User_Status());
            SetCursur(4, 0);
            System.Console.WriteLine(Monster_Status());
            SetCursur(3, 0);
            monster.Sprite.SpriteRender();
        }

        private static StringBuilder Monster_Status() {
            StringBuilder Monster_UI = new StringBuilder();
            string[] UI_arr = 
            {
                "==========================================================================\n",
                "=== 몬스터 : 이름 체력 hp/fullhp 데미지 :   ================================\n",
            };


            return Monster_UI;
        }

        private static StringBuilder User_Status()
        {
            StringBuilder Player_UI = new StringBuilder();
            string[] UI_arr =
            {
                "==========================================================================\n",
                "=               == 주사위 능력  :       ===================================\n",
                "=               ==                                        ================\n",
                "=               ==                                        ================\n",
                "=               ==========================================================\n",
                "=               ==========================================================\n",
                "=               ==========================================================\n",
                "==========================================================================\n",
                "== 체력 : hp/fullhp : 일반 데미지 :  스킬 데미지 :       ===================\n",
                "==========================================================================\n"
            };
            for(int i = 0; i < UI_arr.Length; i++) {
                Player_UI.Append(i);
            }
            return Player_UI;
        }

    }
}
