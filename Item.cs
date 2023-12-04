using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public abstract class Item
    {
        protected string name;
        protected int Prize;
        protected int RecoveryHp;
        protected int PlusDamage;
        protected string Item_Summary;


        public string GetName { get { return name; } private set { } }
        public int GetPrize { get { return Prize; } private set { } }
        public string GetSummary { get { return Item_Summary; } private set { } }
        public int GetRecovery { get { return RecoveryHp; } private set { } }
        public abstract void Use();
        public abstract Item DeepCopy(Item item);
    }

    public class SmallPotion : Item
    {

        public SmallPotion()
        {
            name = "작은 회복 포션";
            Prize = 500;
            RecoveryHp = 30;
            Item_Summary = $"체력을 {this.RecoveryHp}만큼 회복 시킵니다";
        }

        public override Item DeepCopy(Item item)
        {
            return new SmallPotion();
        }

        public override void Use()
        {

            Player.GetInstance.GetPlayerHp += this.RecoveryHp;

            if (Player.GetInstance.GetPlayerFullHp < Player.GetInstance.GetPlayerHp)
            {
                Player.GetInstance.GetPlayerHp = Player.GetInstance.GetPlayerFullHp;
            }

            Player.GetInstance.Player_Items.Remove(this);
        }

    }

    public class BigPotion : Item
    {

        public BigPotion()
        {
            name = "큰 회복 포션";
            Prize = 700;
            RecoveryHp = 50;
            Item_Summary = $"체력을 {this.RecoveryHp}만큼 회복 시킵니다";
        }

        public override Item DeepCopy(Item item)
        {
            return new BigPotion();
        }

        public override void Use()
        {

            Player.GetInstance.GetPlayerHp += this.RecoveryHp;

            if (Player.GetInstance.GetPlayerFullHp < Player.GetInstance.GetPlayerHp)
            {
                Player.GetInstance.GetPlayerHp = Player.GetInstance.GetPlayerFullHp;
            }

            Player.GetInstance.Player_Items.Remove(this);
        }

    }

    public class PowerPotion : Item
    {
        public PowerPotion()
        {
            name = "강인한 포션";
            Prize = 900;
            PlusDamage = 3;
            Item_Summary = $"데미지를 {this.PlusDamage}만큼 영구히 증가 시킵니다";
        }
        public override Item DeepCopy(Item item)
        {
            return new PowerPotion();
        }

        public override void Use()
        {
            Player.GetInstance.GetPlayerDamage += PlusDamage;
        }
    }


}
