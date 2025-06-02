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

            petTimer = new System.Timers.Timer(1000);
            petTimer.Elapsed += OnStatDecreaseTick;
            petTimer.AutoReset = true;
            petTimer.Enabled = true;

            while (_isRunning)
            {
                string userChoice = GetUserInput();

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
                var petTypeMenu = new Menu<PetType>("Select a Pet for Adoption", Enum.GetValues(typeof(PetType)).Cast<PetType>().ToList(), petType => petType.ToString());

                PetType? selectedPetType = petTypeMenu.ShowAndGetSelection();

                if (!petTypeMenu.isChoosen)
                {
                    Console.WriteLine("You chose to cancel the adoption. Returning to the main menu.");
                }
                else
                {
                    PetType petToAdopt = selectedPetType.Value;
                    AdoptPet(petToAdopt);
                    Console.WriteLine($"You have adopted a {petToAdopt}!");
                }
            }

            else if (userInput == "2")
            {
                Console.Clear();
                petHolderScript.ShowCurrentPets();
            }
            else if (userInput == "3")
            {
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
            onDecreaseStat?.Invoke();
        }
        private async Task ViewPetsAndAvailableItems()
        {
            if (petHolderScript.currentPetAmount == 0)
            {
                Console.WriteLine("You have no pets. Adopt one first.");
                Console.ReadKey();
                return;
            }
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

            Console.WriteLine($"Effect applied! {selectedItem.AffectedStat} of {selectedPet.petType} is now changed.");
        }

    }//CLASS
}//NAMESPACE
