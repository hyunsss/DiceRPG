using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public abstract class Monster
    {
        public AsciiSprite Sprite = new AsciiSprite();
        protected StringBuilder sb;
        protected string name;
        protected int Hp;
        protected int FullHp;
        protected int Damage;



        public void Update()
        {

        }


        public abstract void Attack(Player player);
        public string GetName { get { return name; } }
        public int GetHp { get { return Hp;} set { Hp = value; } }
        public int GetFullHp { get { return FullHp;} set { FullHp = value; } }
        public int GetDamage { get { return Damage;} set { Damage = value; } }
        

    }

    public class Toriel : Monster
    {
        public Toriel()
        {
            Sprite = new S_Toriel();
            Hp = 10;
            FullHp = 10;
            Damage = 1;
            
        }

        public void PrintSprite() {

        }

        public override void Attack(Player player)
        {
            Console.WriteLine("  . . . .  ");
        }
    }
    public class Jery : Monster
    {
        public Jery() {
            Sprite = new S_Jery();
            Hp = 45;
            FullHp = 45;
            Damage = 8;
            
        }
        public override void Attack(Player player)
        {
            Console.WriteLine(" . . . . . . ");
            player.GetPlayerHp -= this.Damage;
        }
    }
    public class Wimson : Monster
    {
        public Wimson()
        {
            Sprite = new S_Wimson();
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            
        }
        public override void Attack(Player player)
        {
            Console.WriteLine(" . . . . . . !! ");
            player.GetPlayerHp -= this.Damage;
        }
    }
    public class GreatDog : Monster
    {
        public GreatDog()
        {
            Sprite = new S_GreatDog();
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            
        }
        public override void Attack(Player player)
        {
            Console.WriteLine("왈! 왈!");
            player.GetPlayerHp -= this.Damage;
        }
    }
    public class Flowey : Monster
    {
        
        public Flowey() {
            Sprite = new S_Flowey();
            Hp = 500;
            FullHp = 500;
            Damage = 30;

        }
        public override void Attack(Player player)
        {
            Console.WriteLine("ㅎ ㅎ ㅎ ㅎ ");
            player.GetPlayerHp -= this.Damage;
        }
    }

    public class PapyRus : Monster
    {
        public PapyRus() {
            Sprite = new S_PapyRus();
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            
        }
        public override void Attack(Player player)
        {
            throw new NotImplementedException();
        }
    }
    public class Sanz : Monster
    {
        public Sanz()
        {
            Sprite = new S_Sanz();
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            

        }
        public override void Attack(Player player)
        {
            throw new NotImplementedException();
        }
    }
    public class Undyne : Monster
    {
        public Undyne()
        {
            Sprite = new S_Undyne();
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            

        }
        public override void Attack(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
