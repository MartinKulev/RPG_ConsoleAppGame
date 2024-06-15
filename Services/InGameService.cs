using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Asn1.BC;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using RPG_Console_App_Game.Data.Entities;
using RPG_Console_App_Game.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Services
{
    public class InGameService : IInGameService
    {
        private List<Monster> MonstersSpawned = new List<Monster>();

        public InGameService() { }

        public char PrintMatrixLayoutActionOpiton(char[,] matrix, Character character)
        {
            string[] availableOptions = { "1", "2" };
            string actionOption = string.Empty;
            do
            {
                PrintMatrix(matrix, character);
                Console.WriteLine("Choose action");
                Console.WriteLine("1) Attack");
                Console.WriteLine("2) Move");
                Console.Write("Your Pick:");
                actionOption = Console.ReadLine();
                Console.Clear();
            }
            while (!availableOptions.Contains(actionOption));

            return actionOption[0];
        }

        public char PrintMatrixLayoutMoveOpiton(char[,] matrix, Character character)
        {
            string[] moveOptions = { "W", "S", "D", "A", "E", "X", "Q", "Z" };
            string moveOption = string.Empty;
            do
            {
                PrintMatrix(matrix, character);
                Console.WriteLine("Choose move option: ");
                Console.WriteLine("W - Move up");
                Console.WriteLine("S - Move down");
                Console.WriteLine("D - Move right");
                Console.WriteLine("A - Move left");
                Console.WriteLine("E - Move diagonally up & right");
                Console.WriteLine("X - Move diagonally down & right");
                Console.WriteLine("Q - Move diagonally up & left");
                Console.WriteLine("Z - Move diagonally down & left");
                Console.Write("Your Pick:");
                moveOption = Console.ReadLine();
                Console.Clear();
            }
            while (!moveOptions.Contains(moveOption));

            return moveOption[0];
        }

        public int PrintMatrixLayoutAttackOpiton(char[,] matrix, Character character, List<Monster> monstersInRange)
        {
            List<string> attackOptions = monstersInRange.Select((monster, index) => index.ToString()).ToList();

            string attackOption = string.Empty;
            do
            {
                PrintMatrix(matrix, character);
                Console.WriteLine("Choose attack option: ");
                if (monstersInRange.Count == 0)
                {
                    Console.WriteLine("No available targets in your range");
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                    Console.Clear();
                    return -1; //returns -1 if there are no available targets
                }
                else
                {
                    int index = 0;
                    foreach (var monster in monstersInRange)
                    {
                        Console.WriteLine($"{index}) target with remaining blood {monster.Health}");
                        index++;
                    }
                    Console.Write("Your Pick:");
                    attackOption = Console.ReadLine();
                    Console.Clear();
                }

            }
            while (!attackOptions.Contains(attackOption));

            return int.Parse(attackOption);
        }

        public void PrintMatrix(char[,] matrix, Character character)
        {
            Console.WriteLine($"Health: {character.Health}  |  Mana: {character.Mana}");
            Console.WriteLine();
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Console.Write(matrix[x, y]);
                }
                Console.WriteLine();
            }
        }

        public char[,] CreateMatrix(Character character)
        {
            char[,] matrix = new char[10, 10];

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    matrix[x, y] = '▒';
                }
            }

            matrix[1, 1] = character.Symbol;
            return matrix;
        }

        public char[,] CharacterMove(char moveOption, char[,] matrix, Character character)
        {
            bool isValidMoveOption = false;
            (int x, int y) = FindPlayerIndex(matrix, character);

            while (true)
            {
                if (moveOption == 'W')
                {
                    if (x > 0)
                    {
                        isValidMoveOption = true;
                        matrix[x, y] = '▒';
                        matrix[x - 1, y] = character.Symbol;
                    }
                }
                else if (moveOption == 'S')
                {
                    if (x < matrix.GetLength(0) - 1)
                    {
                        isValidMoveOption = true;
                        matrix[x, y] = '▒';
                        matrix[x + 1, y] = character.Symbol;
                    }
                }
                else if (moveOption == 'D')
                {
                    if (y < matrix.GetLength(1) - 1)
                    {
                        isValidMoveOption = true;
                        matrix[x, y] = '▒';
                        matrix[x, y + 1] = character.Symbol;
                    }
                }
                else if (moveOption == 'A')
                {
                    if (y > 0)
                    {
                        isValidMoveOption = true;
                        matrix[x, y] = '▒';
                        matrix[x, y - 1] = character.Symbol;
                    }
                }
                else if (moveOption == 'E')
                {
                    if (x > 0 && y < matrix.GetLength(1) - 1)
                    {
                        isValidMoveOption = true;
                        matrix[x, y] = '▒';
                        matrix[x - 1, y + 1] = character.Symbol;
                    }
                }
                else if (moveOption == 'X')
                {
                    if (x < matrix.GetLength(0) - 1 && y < matrix.GetLength(1) - 1)
                    {
                        isValidMoveOption = true;
                        matrix[x, y] = '▒';
                        matrix[x + 1, y + 1] = character.Symbol;
                    }
                }
                else if (moveOption == 'Q')
                {
                    if (x > 0 && y > 0)
                    {
                        isValidMoveOption = true;
                        matrix[x, y] = '▒';
                        matrix[x - 1, y - 1] = character.Symbol;
                    }
                }
                else if (moveOption == 'Z')
                {
                    if (x < matrix.GetLength(0) - 1 && y > 0)
                    {
                        isValidMoveOption = true;
                        matrix[x, y] = '▒';
                        matrix[x + 1, y - 1] = character.Symbol;
                    }
                }
                if (isValidMoveOption)
                {
                    break;
                }
                moveOption = PrintMatrixLayoutMoveOpiton(matrix, character);
            }
            return matrix;
        }

        public (int x, int y) FindPlayerIndex(char[,] matrix, Character character)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x, y] == character.Symbol)
                    {
                        return (x, y);
                    }
                }
            }
            throw new ArgumentException("Player not found");
        }

        public char[,] SpawnMonster(char[,] matrix)
        {
            Monster monster = new Monster();
            monster.Setup();
            Random random = new Random();

            while (true)
            {
                int x = random.Next(0, matrix.GetLength(0));
                int y = random.Next(0, matrix.GetLength(1));

                if (matrix[x, y] == '▒')
                {
                    matrix[x, y] = monster.Symbol;
                    monster.MonsterPosition = (x, y);
                    break;
                }
            }
            MonstersSpawned.Add(monster);
            return matrix;
        }

        public List<Monster> ListMonstersInRange(char[,] matrix, Character character)
        {
            List<Monster> monsters = new List<Monster>();
            (int characterX, int characterY) = FindPlayerIndex(matrix, character);

            foreach (var monster in MonstersSpawned)
            {
                (int monsterX, int monsterY) = monster.MonsterPosition;

                double distance = Math.Sqrt(Math.Pow(monsterX - characterX, 2) + Math.Pow(monsterY - characterY, 2));

                if (distance <= character.Range)
                {
                    monsters.Add(monster);
                }
            }
            return monsters;
        }

        public char[,] AttackMonster(char[,] matrix, Character character, (int monsterX, int monsterY) monsterPosition, int damage)
        {
            PrintMatrix(matrix, character);

            Monster monster = MonstersSpawned.First(m => m.MonsterPosition == monsterPosition);
            monster.Health -= damage;

            if (monster.Health <= 0)
            {
                MonstersSpawned.Remove(monster);
                Console.WriteLine("You killed a monster!");
                matrix[monsterPosition.monsterX, monsterPosition.monsterY] = '▒';
            }
            else
            {
                Console.WriteLine($"Monster's remaining blood {monster.Health}");
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Console.Clear();
            return matrix;
        }

        public Character GetAttackedByMonster(char[,] matrix, Character character)
        {
            StringBuilder linesToPrint = new StringBuilder();
            bool isCharacterAttacked = false;

            (int characterX, int characterY) = FindPlayerIndex(matrix, character);

            foreach (var monster in MonstersSpawned)
            {
                (int monsterX, int monsterY) = monster.MonsterPosition;

                double distance = Math.Sqrt(Math.Pow(monsterX - characterX, 2) + Math.Pow(monsterY - characterY, 2));

                if (distance <= 1)
                {
                    isCharacterAttacked = true;
                    character.Health -= monster.Damage;
                    linesToPrint.AppendLine($"You have been attacked for {monster.Damage} damage!");
                }
            }
            if (isCharacterAttacked == true)
            {
                PrintMatrix(matrix, character);
                Console.WriteLine(linesToPrint);
                if (character.Health <= 0)
                {
                    linesToPrint.AppendLine("You died!");
                }
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();
                if (character.Health <= 0)
                {
                    GameOverAnimation();
                }
            }

            return character;
        }

        public char[,] MoveMonstersToPlayer(char[,] matrix, Character character)
        {
            (int characterX, int characterY) = FindPlayerIndex(matrix, character);

            var occupiedPositions = new HashSet<(int, int)>();

            foreach (var monster in MonstersSpawned)
            {
                (int monsterX, int monsterY) = monster.MonsterPosition;

                int deltaX = Math.Sign(characterX - monsterX);
                int deltaY = Math.Sign(characterY - monsterY);

                int newMonsterX = monsterX + deltaX;
                int newMonsterY = monsterY + deltaY;

                if (IsValidMonsterMove(matrix, newMonsterX, newMonsterY, characterX, characterY, occupiedPositions))
                {
                    occupiedPositions.Remove((monsterX, monsterY));
                    occupiedPositions.Add((newMonsterX, newMonsterY));
                    monster.MonsterPosition = (newMonsterX, newMonsterY);

                    matrix[monsterX, monsterY] = '▒';
                    matrix[newMonsterX, newMonsterY] = '!';
                }
            }

            return matrix;
        }

        private bool IsValidMonsterMove(char[,] matrix, int newMonsterX, int newMonsterY, int characterX, int characterY, HashSet<(int, int)> occupiedPositions)
        {
            if (newMonsterX < 0 || newMonsterX >= matrix.GetLength(0) ||
                newMonsterY < 0 || newMonsterY >= matrix.GetLength(1))
            {
                return false;
            }

            if (newMonsterX == characterX && newMonsterY == characterY)
            {
                return false;
            }

            if (occupiedPositions.Contains((newMonsterX, newMonsterY)))
            {
                return false;
            }

            return true;
        }

        public void GameOverAnimation()
        {
            Console.WriteLine(@"
               _____                         ____                 
              / ____|                       / __ \                
             | |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __ 
             | | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__|
             | |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |   
              \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|   
            ");
            Environment.Exit(0);
        }
    }
}

