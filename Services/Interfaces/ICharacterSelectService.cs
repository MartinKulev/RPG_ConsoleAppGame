using RPG_Console_App_Game.Data.Entities;

namespace RPG_Console_App_Game.Services.Interfaces
{
    public interface ICharacterSelectService
    {
        char ChooseCharacter();

        char DoYouWantToBuffYourStats();

        (int strengthPoints, int agilityPoints, int intelligencePoints) BuffYourStats();

        Task<Character> CreateCharacter(char characterOption, int strengthPoints, int agilityPoints, int intelligencePoints);
    }
}
