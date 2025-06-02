using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DGD_Assigment1__Final
{
    internal class Program
    {
        private bool _isRunning;

        System.Timers.Timer petTimer;

        PetHolder petHolderScript = new PetHolder();
        AdoptationMenu adoptationMenuScript = new AdoptationMenu();
        public event Action<PetType> onNewPetAdapt;
        public event Action onDecreaseStat;

        static async Task Main(string[] args)
        {
            Program programScript = new Program();
            await programScript.GameLoop();
        }
        public async Task GameLoop()
        {
            Initialize();

            _isRunning = true;

            petTimer = new System.Timers.Timer(1000); // 1000 ms = 1 second
            petTimer.Elapsed += OnStatDecreaseTick;
            petTimer.AutoReset = true;
            petTimer.Enabled = true;

            while (_isRunning)
            {
                // Display menu and get player input
                string userChoice = GetUserInput();

                // Process the player's choice
                await ProcessUserChoice(userChoice);
            }
            petTimer.Stop();
            petTimer.Dispose();
            Console.WriteLine("Thanks for playing the Tamagotchi!");
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
                Console.Clear();
                petHolderScript.ShowCurrentPets();
            }
            else if (userInput == "3")
            {
                //It should show current pets and should allow user to take care of them
                await ViewPetsAndAvailableItems();
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

        private void OnStatDecreaseTick(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Stats are decreased");
            onDecreaseStat?.Invoke();
        }
        private async Task ViewPetsAndAvailableItems()
        {
            if (petHolderScript.currentPetAmount == 0)
            {
                Console.WriteLine("You have no pets yet. Adopt one first.");
                Console.ReadKey();
                return;
            }

            // Step 2: Let the user select a pet
            Pet selectedPet = await GetPetSelection();

            if (selectedPet == null)
            {
                Console.WriteLine("No pet selected. Going back...");
                return;
            }
            Item selectedItem = await GetItemSelectionForPet(selectedPet);

            if (selectedItem == null)
            {
                Console.WriteLine("No item selected. Going back...");
                return;
            }

            // Step 4: Use the selected item on the pet
            await UseItemOnPet(selectedPet, selectedItem);
        }

        private async Task<Pet> GetPetSelection()
        {
            var petMenu = new Menu<Pet>(
                "Select a Pet",
                petHolderScript.GetPets(),
                pet => $"{pet.petType} - Hunger: {pet.currentHunger}, Sleep: {pet.currentSleep}, Fun: {pet.currentHappiness}"
            );

            return petMenu.ShowAndGetSelection(); 
        }

        private async Task<Item> GetItemSelectionForPet(Pet selectedPet)
        {
            var availableItems = ItemDatabase.AllItems
                .Where(item => item.CompatibleWith.Contains(selectedPet.petType))
                .ToList();

            if (availableItems.Count == 0)
            {
                Console.WriteLine($"No items available for {selectedPet.petType}.");
                return null; 
            }

            var itemMenu = new Menu<Item>(
                "Select an Item",
                availableItems,
                item => $"{item.Name} - Affects {item.AffectedStat} (+{item.EffectAmount})"
            );

            return itemMenu.ShowAndGetSelection(); 
        }

        private async Task UseItemOnPet(Pet selectedPet, Item selectedItem)
        {
            Console.WriteLine($"You are using {selectedItem.Name} on {selectedPet.petType}.");

            await Task.Delay((int)(selectedItem.Duration * 1000));

            selectedPet.ApplyItemEffectToPet(selectedItem);

            Console.WriteLine($"Effect applied! {selectedItem.AffectedStat} of {selectedPet.petType} is now .");
        }

    }//CLASS
}//NAMESPACE
