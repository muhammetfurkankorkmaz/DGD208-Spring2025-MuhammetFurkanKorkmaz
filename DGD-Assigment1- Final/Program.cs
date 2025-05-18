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

        PetHolder petHolderScript = new PetHolder();
        AdoptationMenu adoptationMenuScript = new AdoptationMenu();
        public event Action<PetType> onNewPetAdapt;

        static async Task Main(string[] args)
        {
            Program programScript = new Program();
            await programScript.GameLoop();
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


            petHolderScript.DeclareProgram(this);


            adoptationMenuScript.DeclareProgram(this);
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

        private async Task ProcessUserChoice(string userInput)
        {
            if (userInput == "1")
            {
                //It should open the pet adoptation page
                adoptationMenuScript.ShowAdoptationOptions();
            }
            else if (userInput == "2")
            {
                petHolderScript.ShowCurrentPets();
            }
            else if (userInput == "3")
            {
                //It should show current pets and should allow user to take care of them(should open another page)
            }
            else if (userInput == "4")
            {
                _isRunning = false;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID INPUT!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void AdoptPet(PetType petType)
        {
            onNewPetAdapt?.Invoke(petType);
        }
    }//CLASS
}//NAMESPACE
