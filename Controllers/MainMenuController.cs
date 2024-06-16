using RPG_Console_App_Game.GameService;

namespace RPG_Console_App_Game.Controllers
{
    public class MainMenuController
    {
        private readonly MainMenuService mainMenuService;

        public MainMenuController()
        { 
            mainMenuService = new MainMenuService();
        }

        public void PlayMainMenu()
        {
            mainMenuService.DisplayMainMenuText();
        }
    }
}
