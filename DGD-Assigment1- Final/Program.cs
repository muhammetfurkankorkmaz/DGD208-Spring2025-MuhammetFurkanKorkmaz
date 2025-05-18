using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DGD_Assigment1__Final
{
    internal class Program
    {
        private bool _isRunning;

        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GameLoop();
        }
        public async Task GameLoop()
        {
            Initialize();

            _isRunning = true;
            while (_isRunning)
            {
                // Display menu and get player input
                string userChoice = GetUserInput();

                // Process the player's choice
                await ProcessUserChoice(userChoice);
            }

            Console.WriteLine("Thanks for playing!");
        }
        private void Initialize()
        {
            StartMenu startMenu = new StartMenu();
            startMenu.GameStartMenu();
            Console.WriteLine("Tamagotchi is starting now!!!");
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Thread.Sleep(1000);
            Console.Clear();           

        }

        private string GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("WELCOME TO TAMAGOTCHI");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1- Adopt a pet");
            Console.WriteLine("2- Look your pets");
            Console.WriteLine("3- Spend time with your pets");
            Console.WriteLine("4- Exit the Tamagotchi");

            return Console.ReadLine();
        }

        private async Task ProcessUserChoice(string choice)
        {
            // Use this to process any choice user makes
            // Set _isRunning = false to exit the game
        }
    }//CLASS
}//NAMESPACE
