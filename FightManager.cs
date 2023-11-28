using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class FightManager
    {
        enum RandomMonster { Flowey, GreatDog, Wimson, Jery }
        private Monster InArea;

        public void Player_InArea()
        {
            Monster monster;
            CreateRandomMonster(out monster);

        }
        //https://passwordkim.tistory.com/21
        private static void CreateRandomMonster(out Monster monster)
        {

            Random rand = new Random();
            int respawn = rand.Next(0, 3);

            switch (respawn)
            {
                case (int)RandomMonster.Flowey:
                    Console.WriteLine("플라위가 나타났습니다!");
                    monster = new Flowey();
                    break;
                case (int)RandomMonster.GreatDog:
                    Console.WriteLine("그레이트 도그가 나타났습니다!");
                    monster = new GreatDog();
                    break;
                case (int)RandomMonster.Wimson:
                    Console.WriteLine("윔선가 나타났습니다!");
                    monster = new Wimson();
                    break;
                case (int)RandomMonster.Jery:
                    Console.WriteLine("제리가 나타났습니다!");
                    monster = new Jery();
                    break;
                default:
                    Console.WriteLine("CreateRandomMonster(). Default Exception");
                    monster = new Monster();
                    break;
            }
        }

        private void Fight(Monster monster, Player player) {
            bool PlayerAttackTrue = true;
            bool HasDie = false;
            while(!HasDie) {
                
                //플레이어 공격 턴
                if(PlayerAttackTrue) {
                    //
                } 
                //몬스터 공격 턴
                else {
                    //
                }       

                if(monster.GetHp <= 0) {
                    System.Console.WriteLine("몬스터를 쓰러트렸습니다!! ");
                    HasDie = true;
                } else if(player.GetPlayerHp <= 0) {
                    System.Console.WriteLine("플레이어가 쓰러졌습니다....");
                    HasDie = true;
                    //Todo 게임 종료 함수
                }
            }

        }
    }
}
