using System;

namespace PasswordApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this password application.");
            Utilities.setupRandomGenerator();
            MainMenu menu = new MainMenu();
            int userInput = 0; 
            while (userInput != 4)
            {
                menu.showMenu();
                userInput = menu.readUserInput();
                menu.processInput(userInput);
            }
            exit(); 
        }

        private static void exit()
        {
            Console.WriteLine("Thank you for using this application.");
            Console.ReadLine();
            System.Environment.Exit(1);
        }
    }
}
