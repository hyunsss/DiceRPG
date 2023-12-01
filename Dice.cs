using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiceRPG
{


    public class Dice : SingleTon<Dice>
    {
        List<Skill> DiceSkills = new List<Skill>();
        public int[] DiceNumberPer = new int[120]; 
        public double[] DicePer = new double[6];   //다이스 확률 계산
        Skill[] Dice_Skills = new Skill[6];
        public Skill[] GetSkill { get { return Dice_Skills; } set { GetSkill = value; } }

        public Dice()
        {
            Dice_Skills[0] = new Bang();
            Dice_Skills[1] = new Bang();
            Dice_Skills[2] = new Bang();
            Dice_Skills[3] = new RecoveryHP();
            Dice_Skills[4] = new RecoveryHP();
            Dice_Skills[5] = new RecoveryHP();
        }

        public int ReloadDice()
        {
            Random rand = new Random();
            int num = rand.Next(0, 119);


            return DiceNumberPer[num] - 1;
        }

        public void DicePercent()
        {
            int num = 1;
            for(int i = 0; i < DiceNumberPer.Length; i++)
            {
                DiceNumberPer[i] = num;
                if(i != 0 && i % 20 == 0)
                {
                    num++;
                }
            }
        }

        public void NewDicePer(int DiceNum, int Percent) {
            int num = 1;
            for (int i = 0; i < 6; i++) {
                int temp = Percent / 5;
               
                for(int Index = 0; Index < DiceNumberPer.Length; Index++)
                {
                    if(temp != 0) {
                        if (num == DiceNum)
                        {
                            break;
                        }
                        else if (DiceNumberPer[Index] == num)
                        {
                            DiceNumberPer[Index] = DiceNum;
                            temp--;
                        }
                    }
                    else
                    {
                        break;
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

                DicePer[i - 1] = Math.Round((temp / 120) * 100);
            }
        }

        public double DiceLoad(int DiceIndex) {
            return DicePer[DiceIndex - 1];
        }
        
    }

    public abstract class Skill
    {
        protected int Damage;
        protected int RecorveryHP;
        protected Monster monster = Data.MonsterInPos(Player.GetInstance.pos);
        protected string Skill_Summary = "";


        public Skill()
        {
            this.Damage = 0;
            this.RecorveryHP = 30;
        }

        public int GetDamage { get { return this.Damage; } set { Damage = value; } }
        public string GetSummary { get { return this.Skill_Summary; } }

        //강타
        //몬스터 기절 (한 턴 쉬기)
        //회복
        //일반 스텟 강화
        //몬스터 공격 약화
        //처치시 돈 두배
        public abstract void Use();

    }

    public class Bang : Skill
    {
        public Bang()
        {
            Skill_Summary = $"몬스터에게 {this.Damage}만큼의 데미지를 가합니다.";
        }
        public override void Use()
        {
            Player.GetInstance.GetPlayerSkillDamage = Damage;
        }
    }

    public class Faint : Skill
    {
        public Faint()
        {
            Skill_Summary = "몬스터에게 기절을 부여합니다.";
        }
        public override void Use()
        {
            monster.GetBurf[(int)Monster.MonsterBurf.IsFaint] = true;
        }
    }

    public class RecoveryHP : Skill
    {
        public RecoveryHP()
        {
            Skill_Summary = $"플레이어의 체력을 {this.RecorveryHP} 회복합니다.";

        }
        public override void Use()
        {
            Player.GetInstance.GetPlayerHp += RecorveryHP;
        }
    }


    public class NormalStronger : Skill
    {
        public NormalStronger()
        {
            Skill_Summary = "플레이어의 일반 스텟을 강화합니다.";
        }
        public override void Use()
        {
            Player.GetInstance.GetPlayerHp += 100;
            Player.GetInstance.GetPlayerFullHp += 100;
            Player.GetInstance.GetPlayerDamage += 50;
        }
    }

    public class MonsterWeek : Skill
    {
        public MonsterWeek()
        {
            Skill_Summary = "몬스터에게 약화를 부여합니다.";
        }
        public override void Use()
        {
            monster.GetBurf[(int)Monster.MonsterBurf.IsWeek] = true;
        }
    }

    public class GetMoneyMultiply : Skill
    {
        public GetMoneyMultiply()
        {
            Skill_Summary = "이 턴에 몬스터가 죽을 시 돈을 두배로 떨굽니다.";
        }
        public override void Use()
        {
            monster.GetBurf[(int)Monster.MonsterBurf.IsGetMoneyX2] = true;
        }
    }



}
