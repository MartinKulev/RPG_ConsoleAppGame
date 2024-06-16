namespace RPG_Console_App_Game.Data.Entities
{
    public class Mage : Character
    {
        public Mage(int strengthPoints, int agilityPoints, int intelligencePoints)
        {
            TimeOfCreation = DateTime.Now;
            Race = "Mage";
            Symbol = '*';
            StrengthPoints = 2 + strengthPoints;
            AgilityPoints = 1 + agilityPoints;
            IntelligencePoints = 3 + intelligencePoints;
            Range = 3;
            Setup();
        }
    }
}
