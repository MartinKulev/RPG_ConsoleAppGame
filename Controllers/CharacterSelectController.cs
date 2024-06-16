using RPG_Console_App_Game.GameService;
using System;
using System.Collections.Generic;
using RPG_Console_App_Game.Data.Entities;

namespace RPG_Console_App_Game.Controllers
{
    public class CharacterSelectController
    {
        private readonly CharacterSelectService characterSelectService;

        public CharacterSelectController()
        {
            characterSelectService = new CharacterSelectService();
        }

        public async Task<Character> PlayCharacterSelect()
        {
            char characterOption = characterSelectService.ChooseCharacter();
            char yesNoOption = characterSelectService.DoYouWantToBuffYourStats();

            int strengthPoints = 0;
            int agilityPoints = 0;
            int intelligencePoints = 0;

            if (yesNoOption == 'Y' || yesNoOption == 'y')
            {
                (strengthPoints, agilityPoints, intelligencePoints) = characterSelectService.BuffYourStats();
            }

            return await characterSelectService.CreateCharacter(characterOption, strengthPoints, agilityPoints, intelligencePoints);
        }
    }
}
