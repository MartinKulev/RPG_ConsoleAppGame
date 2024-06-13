using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console_App_Game.GameService
{
    public class MainMenuService
    {
        public MainMenuService() { }

        public void DisplayMainMenuText()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("Welcome!");
            Console.WriteLine("Press any key to play!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
