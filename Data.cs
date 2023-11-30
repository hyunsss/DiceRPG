using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public static class Data
    {
        public static char[,] map;
        public static List<Monster> monsters;

        public static void Init()
        {
            monsters = new List<Monster>();
        }


        public static bool ObjectInPos(Position pos)
        {
            return MonsterInPos == null;
        }
        public static Monster MonsterInPos(Position pos)
        {
            foreach(Monster monster in monsters)
            {
                if(monster.pos.x == pos.x && monster.pos.y == pos.y)
                {
                    return monster;
                }
            }

            return null;
        }

        public static void BasicMap()
        {
            map = new char[,]
            {
            {'#','#','#','#','#'},
            {'#',' ',' ',' ','#'},
            {'#',' ',' ',' ','#'},
            {'#',' ',' ','#','#'},
            {'#',' ',' ','#','#'},
            {'#',' ',' ',' ','#'},
            {'#','#','#','#','#'}
            };

            Monster jery1 = new Jery();
            jery1.pos = new Position(3,2);
            monsters.Add(jery1);

            Monster wimson1 = new Wimson();
            wimson1.pos = new Position(2,5);
            monsters.Add(wimson1);

            Monster greatdog1 = new GreatDog();
            greatdog1.pos = new Position(2, 3);
            monsters.Add(greatdog1);
        }
    }
}
