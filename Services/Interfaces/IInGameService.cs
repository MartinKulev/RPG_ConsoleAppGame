using RPG_Console_App_Game.Data.Entities;

namespace RPG_Console_App_Game.Services.Interfaces
{
    public interface IInGameService
    {
        char PrintMatrixLayoutActionOpiton(char[,] matrix, Character character);

        char PrintMatrixLayoutMoveOpiton(char[,] matrix, Character character);

        int PrintMatrixLayoutAttackOpiton(char[,] matrix, Character character, List<Monster> monstersInRange);

        void PrintMatrix(char[,] matrix, Character character);

        char[,] CreateMatrix(Character character);

        char[,] CharacterMove(char moveOption, char[,] matrix, Character character);

        (int x, int y) FindPlayerIndex(char[,] matrix, Character character);

        char[,] SpawnMonster(char[,] matrix);

        List<Monster> ListMonstersInRange(char[,] matrix, Character character);

        char[,] AttackMonster(char[,] matrix, Character character, (int monsterX, int monsterY) monsterPosition, int damage);

        Character GetAttackedByMonster(char[,] matrix, Character character);

        char[,] MoveMonstersToPlayer(char[,] matrix, Character character);

        void GameOverAnimation();
    }
}
