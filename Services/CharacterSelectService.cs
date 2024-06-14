using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualBasic.FileIO;
using RPG_Console_App_Game.Data.Entities;
using RPG_Console_App_Game.Repositories;
using RPG_Console_App_Game.Repositories.Interfaces;
using RPG_Console_App_Game.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG_Console_App_Game.GameService
{
    public class CharacterSelectService : ICharacterSelectService
    {
        private readonly CharacterRepository<Warrior> characterRepositoryWarrior;
        private readonly CharacterRepository<Archer> characterRepositoryArcher;
        private readonly CharacterRepository<Mage> characterRepositoryMage;

        public CharacterSelectService()
        {
            characterRepositoryWarrior = new CharacterRepository<Warrior>();
            characterRepositoryArcher = new CharacterRepository<Archer>();
            characterRepositoryMage = new CharacterRepository<Mage>();
        }

        public char ChooseCharacter()
        {
            string characterOption = string.Empty;
            string[] availableOptions = { "1", "2", "3" };
            do
            {
                Console.WriteLine("Character Select");
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine("1) Warrior");
                Console.WriteLine("2) Archer");
                Console.WriteLine("3) Mage");
                Console.Write("Your pick: ");
                characterOption = Console.ReadLine();
                Console.Clear();
            }
            while (!availableOptions.Contains(characterOption));

            return characterOption[0];
        }

        public char DoYouWantToBuffYourStats()
        {
            string yesNoOption = string.Empty;
            do
            {
                Console.WriteLine("Character Select");
                Console.WriteLine();
                Console.WriteLine("Would you like to buff up your stats before starting? (Limit: 3 points total)");
                Console.Write("Response (Y\\N):");
                yesNoOption = Console.ReadLine();
                Console.Clear();
            }
            while (yesNoOption != "Y" && yesNoOption != "y" && yesNoOption != "N" && yesNoOption != "n");

            return yesNoOption[0];
        }

        public (int strengthPoints, int agilityPoints, int intelligencePoints) BuffYourStats()
        {
            string statOption = string.Empty;
            int strengthPoints = 0;
            int agilityPoints = 0;
            int intelligencePoints = 0;
            int remainingPoints = 3;

            while (remainingPoints > 0)
            {
                string[] availableOptions1 = { "1", "2", "3" };
                do
                {
                    Console.WriteLine("Character Select");
                    Console.WriteLine();
                    Console.WriteLine($"Strength: {strengthPoints}");
                    Console.WriteLine($"Agility: {agilityPoints}");
                    Console.WriteLine($"Intelligence: {intelligencePoints}");
                    Console.WriteLine();
                    Console.WriteLine($"Remaining Points: {remainingPoints}");
                    Console.WriteLine("1) Add to Strength");
                    Console.WriteLine("2) Add to Agility");
                    Console.WriteLine("3) Add to Intelligence");
                    Console.Write("Your pick: ");
                    statOption = Console.ReadLine();
                    if (statOption == "1")
                    {
                        strengthPoints++;
                    }
                    else if (statOption == "2")
                    {
                        agilityPoints++;
                    }
                    else if (statOption == "3")
                    {
                        intelligencePoints++;
                    }
                    Console.Clear();
                }
                while (!availableOptions1.Contains(statOption));
                remainingPoints--;
            }

            Console.WriteLine("Character Select");
            Console.WriteLine();
            Console.WriteLine($"Strength: {strengthPoints}");
            Console.WriteLine($"Agility: {agilityPoints}");
            Console.WriteLine($"Intelligence: {intelligencePoints}");
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Console.Clear();

            return (strengthPoints, agilityPoints, intelligencePoints);
        }

        public async Task<Character> CreateCharacter(char characterOption, int strengthPoints, int agilityPoints, int intelligencePoints)
        {
            if (characterOption == '1')
            {
                Warrior warrior = new Warrior(strengthPoints, agilityPoints, intelligencePoints);
                await characterRepositoryWarrior.CreateCharacter(warrior);
                return warrior;
            }
            else if (characterOption == '2')
            {
                Archer archer = new Archer(strengthPoints, agilityPoints, intelligencePoints);
                await characterRepositoryArcher.CreateCharacter(archer);
                return archer;
            }
            else if (characterOption == '3')
            {
                Mage mage = new Mage(strengthPoints, agilityPoints, intelligencePoints);
                await characterRepositoryMage.CreateCharacter(mage);
                return mage;
            }
            else
            {
                throw new ArgumentException("Invalid option at CreateCharacter");
            }


        }
    }
}
