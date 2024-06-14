using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RPG_Console_App_Game.Data.Entities;
using RPG_Console_App_Game.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.Services
{
    public class InGameService : IInGameService
    {
        public InGameService() { }

        public char PrintMatrixLayoutActionOpiton(char[,] matrix, Character character)
        {
            string[] availableOptions = { "1", "2"};
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
            string[] moveOptions = {"W", "S", "D", "A", "E", "X", "Q", "Z"};
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

        public char PrintMatrixLayoutAttackOpiton(char[,] matrix, Character character)
        {
            (int x, int y) = FindPlayerIndex(matrix, character);

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
            (int x, int y) = FindPlayerIndex(matrix, character);

            if (moveOption == 'W')
            {
                if (x > 0)
                {
                    matrix[x, y] = '▒';
                    matrix[x - 1, y] = character.Symbol;
                }
            }
            else if (moveOption == 'S')
            {
                if (x < matrix.GetLength(0) - 1)
                {
                    matrix[x, y] = '▒';
                    matrix[x + 1, y] = character.Symbol;
                }
            }
            else if (moveOption == 'D')
            {
                if (y < matrix.GetLength(1) - 1)
                {
                    matrix[x, y] = '▒';
                    matrix[x, y + 1] = character.Symbol;
                }
            }
            else if (moveOption == 'A')
            {
                if (y > 0)
                {
                    matrix[x, y] = '▒';
                    matrix[x, y - 1] = character.Symbol;
                }
            }
            else if (moveOption == 'E')
            {
                if (x > 0 && y < matrix.GetLength(1) - 1)
                {
                    matrix[x, y] = '▒';
                    matrix[x - 1, y + 1] = character.Symbol;
                }
            }
            else if (moveOption == 'X')
            {
                if (x < matrix.GetLength(0) - 1 && y < matrix.GetLength(1) - 1)
                {
                    matrix[x, y] = '▒';
                    matrix[x + 1, y + 1] = character.Symbol;
                }
            }
            else if (moveOption == 'Q')
            {
                if (x > 0 && y > 0)
                {
                    matrix[x, y] = '▒';
                    matrix[x - 1, y - 1] = character.Symbol;
                }
            }
            else if (moveOption == 'Z')
            {
                if (x < matrix.GetLength(0) - 1 && y > 0)
                {
                    matrix[x, y] = '▒';
                    matrix[x + 1, y - 1] = character.Symbol;
                }
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
                    break;
                }
            }
            return matrix;
        }
    }
}

