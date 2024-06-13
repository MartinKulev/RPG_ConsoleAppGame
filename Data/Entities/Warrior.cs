using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Data.Entities
{
    public class Warrior : Character
    {
        public Warrior(int strengthPoints, int agilityPoints, int intelligencePoints)
        {
            TimeOfCreation = DateTime.Now;
            Race = "Warrior";
            Symbol = '@';
            StrengthPoints = 3 + strengthPoints;
            AgilityPoints = 3 + agilityPoints;
            IntelligencePoints = 0 + intelligencePoints;
            Range = 1;
            Setup();
        }
    }
}
