using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Data.Entities
{
    public class Archer : Character
    {
        public Archer(int strengthPoints, int agilityPoints, int intelligencePoints)
        {
            TimeOfCreation = DateTime.Now;
            Race = "Archer";
            Symbol = '#';
            StrengthPoints = 2 + strengthPoints;
            AgilityPoints = 4 + agilityPoints;
            IntelligencePoints = 0 + intelligencePoints;
            Range = 2;
            Setup();
        }
    }
}
