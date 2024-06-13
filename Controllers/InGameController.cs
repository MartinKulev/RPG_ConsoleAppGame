using RPG_Console_App_Game.GameService;
using RPG_Console_App_Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Controllers
{
    public class InGameController
    {
        private readonly InGameService inGameService;

        public InGameController()
        {
            inGameService = new InGameService();
        }

        public void PlayInGame()
        {

        }
    }
}
