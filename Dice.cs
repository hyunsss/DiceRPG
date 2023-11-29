using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class Dice
    {
        List<Skill> DiceSkills = new List<Skill>();
        int[] DiceNumberPer = new int[1200]; // 다이스 확률 분포
        float[] DicePer = new float[6];   //다이스 확률 계산



        private void DicePercent()
        {
            int num = 1;
            for(int i = 1; i <= DiceNumberPer.Length; i++)
            {
                DicePer[i] = num;
                if(i - 1 != 0 && i % 200 == 0 && num <= 7)
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
        
        private void DiceCurculate() {
            int temp = 0;
            for(int i = 0; i < 6; i++) {
                for(int DiceIndex = 0; DiceIndex < DiceNumberPer.Length; DiceIndex++) {
                    if(DiceNumberPer[DiceIndex] == i) {
                        temp++;
                    }
                }

                DicePer[i] = (temp / DiceNumberPer.Length) * 100;
            }
        }

        public float DiceRoad(int DiceIndex) {
            return DicePer[DiceIndex - 1];
        }
        
    }

    public class Skill
    {

    }
}
