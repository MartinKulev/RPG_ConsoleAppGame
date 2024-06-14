using RPG_Console_App_Game.GameService;
using RPG_Console_App_Game.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Console_App_Game.Data.Entities;

namespace RPG_Console_App_Game.Controllers
{
    public class InGameController
    {
        private readonly InGameService inGameService;

        public InGameController()
        {
            inGameService = new InGameService();
        }


        public void PlayInGame(Character character)
        {
            char[,] matrix = inGameService.CreateMatrix(character);
            while(true)
            {
                matrix = inGameService.SpawnMonster(matrix);
                char actionOption = inGameService.PrintMatrixLayoutActionOpiton(matrix, character);
                if(actionOption == '2')
                {
                    char moveOption = inGameService.PrintMatrixLayoutMoveOpiton(matrix, character);
                    matrix = inGameService.CharacterMove(moveOption, matrix, character);
                }
            }
        }
    }
}
