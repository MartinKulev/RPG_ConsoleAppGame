using RPG_Console_App_Game.Controllers;
using RPG_Console_App_Game.Data.Entities;

MainMenuController mainMenuController = new MainMenuController();
InGameController inGameController = new InGameController();
CharacterSelectController characterSelectController = new CharacterSelectController();

mainMenuController.PlayMainMenu();
await characterSelectController.PlayCharacterSelect();
inGameController.PlayInGame();













