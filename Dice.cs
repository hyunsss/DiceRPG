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

        public void Init()
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
            for (int i = 0; i < DiceNumberPer.Length; i++)
            {
                DiceNumberPer[i] = num;
                if (i != 0 && i % 20 == 0)
                {
                    num++;
                }
            }
        }

        public void NewDicePer(int DiceNum, int Percent)
        {
            int num = 1;
            for (int i = 0; i < 6; i++)
            {
                int temp = Percent / 5;

                for (int Index = 0; Index < DiceNumberPer.Length; Index++)
                {
                    if (temp != 0)
                    {
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

        public void DiceCurculate()
        {

            for (int i = 1; i <= 6; i++)
            {
                double temp = 0;

                for (int DiceIndex = 0; DiceIndex < DiceNumberPer.Length; DiceIndex++)
                {
                    if (DiceNumberPer[DiceIndex] == i)
                    {
                        temp++;
                    }
                }

                DicePer[i - 1] = Math.Round((temp / 120) * 100);
            }
        }

        public double DiceLoad(int DiceIndex)
        {
            return DicePer[DiceIndex - 1];
        }

    }

    public abstract class Skill
    {
        protected string name;
        protected int Damage;
        protected int ReinforcePrize;
        protected int RecorveryHP;
        protected int level;
        protected Monster monster = Data.MonsterInPos(Player.GetInstance.pos);

        public int GetDamage { get { return Damage; } set { Damage = value; } }
        public string GetName { get { return this.name; } }
        public int GetReinforcePrize { get { return ReinforcePrize; } set { ReinforcePrize = value; } }
        public int Getlevel { get { return level; } }

        //강타
        //몬스터 기절 (한 턴 쉬기)
        //회복
        //일반 스텟 강화
        //몬스터 공격 약화
        //처치시 돈 두배
        public abstract string Summary();
        public abstract void Use();
        public abstract void SkillReinForce();
    }

    public class Bang : Skill
    {
        public Bang()
        {
            level = 1;
            name = "강타";
            Damage = 80;
            
            ReinforcePrize = 300;
        }

        public override void SkillReinForce()
        {
            Console.WriteLine("스킬을 강화합니다. 데미지가 50만큼 올랐습니다.");
            level++;
            Damage += 50;
            ReinforcePrize += 500;
        }

        public override string Summary()
        {
            return $"몬스터에게 {Damage}만큼의 데미지를 가합니다.";
        }

        public override void Use()
        {
            Player.GetInstance.GetPlayerSkillDamage = Damage;
            Player.GetInstance.SkillAttack(Data.MonsterInPos(Player.GetInstance.pos));
        }
    }

    public class Faint : Skill
    {
        public Faint()
        {
            level = 0;
            name = "기절";
        }

        public override void SkillReinForce()
        {
            Console.WriteLine("이 스킬은 강화 할 수 없습니다.");
        }

        public override string Summary()
        {
            return "몬스터에게 기절을 부여합니다.";
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
            level = 1;
            name = "회복";
            RecorveryHP = 30;
            
            ReinforcePrize = 300;
        }
        public override string Summary()
        {
            return $"플레이어의 체력을 {RecorveryHP} 회복합니다.";
        }

        public override void SkillReinForce()
        {
            Console.WriteLine("스킬을 강화합니다. 회복력이 10만큼 올랐습니다.");
            level++;
            RecorveryHP += 10;
            ReinforcePrize += 500;
        }

        public override void Use()
        {
            Player.GetInstance.GetPlayerHp += RecorveryHP;
        }
    }


    public class NormalStronger : Skill
    {
        int PlusDamage;
        int PlusFullHp;
        int PlusHp;
        public NormalStronger()
        {
            level = 1;
            PlusDamage = 100;
            PlusFullHp = 100;
            PlusHp = 100;
            ReinforcePrize = 300;
            name = "일반 강화";
        }

        public override string Summary()
        {
            return $"플레이어의 일반 스텟을 {PlusDamage}씩 강화합니다.";
        }

        public override void SkillReinForce()
        {
            Console.WriteLine("스킬을 강화합니다. 능력치가 전체적으로 상승합니다.");
            level++;
            ReinforcePrize += 500;
            PlusDamage += 30;
            PlusFullHp += 30;
            PlusHp += 30;
        }

        public override void Use()
        {
            Player.GetInstance.GetPlayerHp += PlusHp;
            Player.GetInstance.GetPlayerFullHp += PlusFullHp;
            Player.GetInstance.GetPlayerDamage += PlusDamage;
        }
    }

    public class MonsterWeek : Skill
    {
        public MonsterWeek()
        {
            level = 0;
            name = "약화";
            
        }

        public override void SkillReinForce()
        {
            Console.WriteLine("이 스킬은 강화 할 수 없습니다.");
        }

        public override string Summary()
        {
            return "몬스터에게 약화를 부여합니다.";
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
            level = 1;
            name = "현상금";
            ReinforcePrize = 2000;
        }

        public override void SkillReinForce()
        {
            Console.WriteLine("스킬을 강화합니다. 능력치가 전체적으로 상승합니다.");
            ReinforcePrize += 2000;
            level++;
            //Todo 몬스터 처치시 골드 3배
        }

        public override string Summary()
        {
            return "이 턴에 몬스터가 죽을 시 돈을 두배로 떨굽니다.";
        }

        public override void Use()
        {
            monster.GetBurf[(int)Monster.MonsterBurf.IsGetMoneyX2] = true;
            //Todo 몬스터 처치시 골드 2배
        }
    }



}
