using System;
using System.Threading;

namespace DGD_Assigment1__Final
{
    internal class StartMenu
    {
        public void GameStartMenu()
        {
            bool _isGameInitialized = false;
            while (!_isGameInitialized)
            {
                Console.WriteLine("1- Start the Tamagotchi");
                Console.WriteLine("2- Credits");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.WriteLine("Tamagotchi is starting now!!!");
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();
                    Thread.Sleep(1000);
                    Console.Clear();
                    _isGameInitialized = true;
                }
                else if (userInput == "2")
                {
                    CreditsScreen();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID INPUT!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        void CreditsScreen()
        {
            Console.WriteLine("M. Furkan Korkmaz 225040043");
            Console.WriteLine("Press any button to proceed.");
            Console.ReadLine();
            Console.Clear();
        }
    }//Class
}//NameSpace
