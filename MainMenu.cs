using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApp
{
    class MainMenu
    {
        PasswordHasher passwordHasher;
        public MainMenu()
        {
            passwordHasher = new PasswordHasher();
        }

        public void showMenu()
        {
            Console.WriteLine("\n\n\t\t MAIN MENU");
            Console.WriteLine("0- Generate a safe password with symbols");
            Console.WriteLine("1- Generate a safe password without symbols");
            Console.WriteLine("2- Register password (i.e. encryption). This will hash through cryptography a password. For demo purposes, it will print out the hash.");
            Console.WriteLine("3- Verify password (i.e. decryption). This will only work if you have a registered password and only work against this one. This is for demo purposes.");
            Console.WriteLine("4- Exit the application");
            Console.WriteLine("\n");
        }

        internal void processInput(int userInput)
        {
            switch (userInput)
            {
                case 0:
                    generateSafePasswordWithSymbols();
                    Console.WriteLine("(Please press enter)");
                    Console.WriteLine("\n");
                    Console.ReadLine(); 
                    break;
                case 1:
                    generateSafePasswordWithoutSymbols();
                    Console.WriteLine("(Please press enter)");
                    Console.WriteLine("\n");
                    Console.ReadLine();
                    break;
                case 2:
                    registerPassword();
                    Console.WriteLine("(Please press enter)");
                    Console.WriteLine("\n");
                    Console.ReadLine();
                    break;
                case 3:
                    verifyPassword();
                    Console.WriteLine("(Please press enter)");
                    Console.WriteLine("\n");
                    Console.ReadLine();
                    break;
                default:
                    break; 
            }
        }

        private void verifyPassword()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Enter the password to want to verify.");
            string userInput = getUserPassword();
            if (this.passwordHasher.Check(userInput))
            {
                Console.WriteLine("\n");
                Console.WriteLine("Success! This password match what is encrypted.");
            } else
            {
                Console.WriteLine("\n");
                Console.WriteLine("Failure! This password does not match what was encrypted.");
            }
        }

        private void registerPassword()
        {
            string userPassword = getUserPassword(); 
            this.passwordHasher.Hash(userPassword);
        }

        private string getUserPassword()
        {
            string userPassword = "";
            do
            {
                Console.WriteLine("Please enter a password of at least 10 characters and maximum 20.");
                userPassword = Console.ReadLine(); 
            } while (!checkPasswordQuality(userPassword));
            return userPassword;
        }

        private bool checkPasswordQuality(string password)
        {
            if (password == null)
            {
                Console.WriteLine("There is no password"); 
                return false;
            }
            if (password.Length < 10)
            {
                Console.WriteLine("The password is too small");
                return false;
            }
            if (password.Distinct().Count() == 1)
            {
                Console.WriteLine("You need to have distinct letters/symbols/numbers");
                return false;
            }
            return true;
        }

        private void generateSafePasswordWithSymbols()
        {
            Password password = new Password(true);
            Console.WriteLine(password.PasswordArray);
        }
        private void generateSafePasswordWithoutSymbols()
        {
            Password password = new Password(false);
            Console.WriteLine(password.PasswordArray);
        }

        internal int readUserInput()
        {
            int numericalChoice = -1;
            bool validChoiceFromUser = false;
            while (!validChoiceFromUser)
            {
                Console.WriteLine("Enter a number to choose from the menu.");
                var choiceStringInput = Console.ReadLine();
                numericalChoice = convertInputToInt(choiceStringInput);
                validChoiceFromUser = verifyInputMenuChoice(numericalChoice);
            }
            return numericalChoice;

        }
        private static int convertInputToInt(string choiceStringInput)
        {
            int choiceInputAsInt = 0;
            choiceStringInput = choiceStringInput.Trim();
            char choiceCharInput = '0';
            try
            {
                choiceCharInput = choiceStringInput[0];
            }
            catch
            {
                Console.WriteLine("Invalid entry");
            }
            try
            {
                choiceInputAsInt = Convert.ToInt32(new string(choiceCharInput, 1));
            }
            catch
            {
                Console.WriteLine("Invalid entry");
            }
            return choiceInputAsInt;
        }
        private static bool verifyInputMenuChoice(int numericalChoice)
        {
            if(numericalChoice < 0 || numericalChoice > 5)
            {
                Console.WriteLine("Invalid entry");
                return false; 
            }
            return true;
        }
    }
}
