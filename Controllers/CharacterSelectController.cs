using RPG_Console_App_Game.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Controllers
{
    public class CharacterSelectController
    {
        private readonly CharacterSelectService characterSelectService;
        public CharacterSelectController()
        {
            characterSelectService = new CharacterSelectService();
        }

        public async Task PlayCharacterSelect()
        {
            string characterOption = characterSelectService.ChooseCharacter();
            string yesNoOption = characterSelectService.DoYouWantToBuffYourStats();

            int strengthPoints = 0;
            int agilityPoints = 0;
            int intelligencePoints = 0;

            if (yesNoOption == "Y" || yesNoOption == "y")
            {
                (strengthPoints, agilityPoints, intelligencePoints) = characterSelectService.BuffYourStats();
            }

            await characterSelectService.CreateCharacter(characterOption, strengthPoints, agilityPoints, intelligencePoints);
        }
    }
}
