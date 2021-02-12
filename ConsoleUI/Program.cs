using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        /// <summary>
        /// Main method. Program will start here.
        /// </summary>
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                ConsoleMenu.Header("You are welcomed by the car rental service.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                ConsoleMenu.Header("Select an action.");
                ConsoleMenu.MainMenu(new List<string> { "Rent", "Administration" });
                Console.Write("\nPlease make your choice to continue...");
                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        RentConsoleController.Menu();
                        break;
                    case '2':
                        AdministrationConsoleController.Menu();
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}