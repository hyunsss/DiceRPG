using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class Dice
    {
        List<Skill> DiceSkills = new List<Skill>();


        public void DicePercent()
        {
            int[] DicePer = new int[1000];

            int num = 1;
            for(int i = 1; i <= DicePer.Length; i++)
            {
                i = num;
                if(i - 1 != 0 && i % 200 == 0)
                {
                    num++;
                }
            }

        }
    }

    public class Skill
    {

    }
}
