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
        protected string Item_Summary;


        public string GetName { get { return name; } private set { } }
        public int GetPrize { get { return Prize; } private set { } }
        public string GetSummary { get { return Item_Summary; } private set { } }
        public abstract void Use();

    }

    public class SmallPotion : Item
    {

        public SmallPotion()
        {
            name = "작은 회복 포션";
            RecoveryHp = 30;
            Item_Summary = $"체력을 {this.RecoveryHp}만큼 회복 시킵니다";
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
            RecoveryHp = 50;
            Item_Summary = $"체력을 {this.RecoveryHp}만큼 회복 시킵니다";
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


}
