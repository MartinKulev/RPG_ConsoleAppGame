using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Data.Entities
{
    public class Monster
    {
        public char Symbol {  get; set; }

        public int StrengthPoints { get; set; }

        public int IntelligencePoints { get; set; }

        public int AgilityPoints { get; set; }

        public int Health { get; set; }

        public int Mana { get; set; }

        public int Damage { get; set; }

        public int Range { get; set; }

        public void Setup()
        {
            Health = StrengthPoints * 5;
            Mana = IntelligencePoints * 3;
            Damage = AgilityPoints * 2;
        }
        public Monster()
        {
            Symbol = '!'; //The '◙' character breaks the matrix when printed so i changed it :(
            Random random = new Random();
            StrengthPoints = random.Next(1, 3);
            IntelligencePoints = random.Next(1, 3);
            AgilityPoints = random.Next(1, 3);
        }
    }
}
