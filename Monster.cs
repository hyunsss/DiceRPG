using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class Monster
    {
        protected StringBuilder sb;
        protected int Hp;
        protected int FullHp;
        protected int Damage;
    }

    public class Toriel : Monster
    {
        private S_Toriel Sprite = new S_Toriel();
        public Toriel()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            
        }
    }
    public class Jery : Monster
    {
        private Jery Sprite = new Jery();
        public Jery() {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            
        }
    }
    public class Wimson : Monster
    {
        private S_Wimson Sprite = new S_Wimson();
        public Wimson()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            
        }
    }
    public class GreatDog : Monster
    {
        private S_GreatDog Sprite = new S_GreatDog();
        public GreatDog()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            
        }
    }
    public class Flowey : Monster
    {
        private S_Flowey Sprite = new S_Flowey();
        public Flowey() {
            Hp = 500;
            FullHp = 500;
            Damage = 30;

        }
    }

    public class PapyRus : Monster
    {
        private S_PapyRus Sprite = new S_PapyRus();
        public PapyRus() {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            
        }
    }
    public class Sanz : Monster
    {
        private S_Sanz Sprite = new S_Sanz();
        public Sanz()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            

        }
    }
    public class Undyne : Monster
    {
        private S_Undyne Sprite = new S_Undyne();
        public Undyne()
        {
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            

        }
    }
}
