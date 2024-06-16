using RPG_Console_App_Game.Services;
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
            while (true) //loops every turn
            {
                matrix = inGameService.SpawnMonster(matrix);
                char actionOption = inGameService.PrintMatrixLayoutActionOpiton(matrix, character);
                if(actionOption == '1') //Attack
                {
                    List<Monster> monstersInRange = inGameService.ListMonstersInRange(matrix, character);
                    int attackOption = inGameService.PrintMatrixLayoutAttackOpiton(matrix, character, monstersInRange);
                    if (attackOption != -1)
                    {
                        matrix = inGameService.AttackMonster(matrix, character, monstersInRange[attackOption].MonsterPosition, character.Damage);
                    }
                }
                if(actionOption == '2') //Move
                {
                    char moveOption = inGameService.PrintMatrixLayoutMoveOpiton(matrix, character);
                    matrix = inGameService.CharacterMove(moveOption, matrix, character);
                }
                character = inGameService.GetAttackedByMonster(matrix, character);
                matrix = inGameService.MoveMonstersToPlayer(matrix, character);
            }
        }
    }
}
