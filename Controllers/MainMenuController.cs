using RPG_Console_App_Game.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
