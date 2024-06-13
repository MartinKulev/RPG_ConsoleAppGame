using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Data.Entities
{
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime TimeOfCreation { get; set; }

        public string Race { get; set; }

        public char Symbol { get; set; }

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
    }
}
