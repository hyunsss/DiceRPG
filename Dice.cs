using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{


    public class Dice : SingleTon<Dice>
    {
        List<Skill> DiceSkills = new List<Skill>();
        public int[] DiceNumberPer = new int[1200]; 
        public double[] DicePer = new double[6];   //다이스 확률 계산

        public void Update()
        {
            
        }

        public int ReloadDice()
        {
            Random rand = new Random();
            int num = rand.Next(0, 1199);


            return DiceNumberPer[num];
        }

        public void DicePercent()
        {
            int num = 1;
            for(int i = 0; i < DiceNumberPer.Length; i++)
            {
                DiceNumberPer[i] = num;
                if(i != 0 && i % 200 == 0)
                {
                    num++;
                }
            }
        }

        public void NewDicePer(int DiceNum, int Percent) {
            
            for(int i = 0; i < 5; i++) {
                int temp = Percent / 5;
                int num = 1;
                for(int DiceIndex = 0; DiceIndex < DiceNumberPer.Length; DiceIndex++ ) {
                    if(num == DiceNum) {
                        break;
                    }
                    if(temp != 0 && DiceNumberPer[DiceIndex] == num) {
                        temp--;
                        DiceNumberPer[DiceIndex] = DiceNum;
                    }
                }
                num++;
            }
        }
        
        public void DiceCurculate() {
            
            for(int i = 1; i <= 6; i++) {
                double temp = 0;
                
                for (int DiceIndex = 0; DiceIndex < DiceNumberPer.Length; DiceIndex++) {
                    if(DiceNumberPer[DiceIndex] == i) {
                        temp++;
                    }
                }

                DicePer[i - 1] = Math.Round((temp / 1200) * 100);
            }
        }

        public double DiceLoad(int DiceIndex) {
            return DicePer[DiceIndex - 1];
        }
        
    }

    public class Skill
    {

    }


}
