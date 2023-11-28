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

        }
        //https://passwordkim.tistory.com/21
        public static void CreateRandomMonster(out Monster monster)
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
    }
}
