using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD_Assigment1__Final
{
    internal class Pet
    {
        PetType petType;
        PetCondition petCondition;

        bool isAlive = true;

        float maxHunger = 100;
        float currentHunger;
        float maxDirtiness = 100;
        float currentDirtiness;
        float maxHappiness = 100;
        float currentHappiness;
        float maxJoy = 100;
        float currentJoy;




        public void InitializePet(PetType _petType)
        {
            petType = _petType;

            currentHunger = 20;
            currentDirtiness = 20;
            currentJoy = 50;
        }
        public void ReturnPetData()
        {
            Console.WriteLine(petType + " -> Hunger :" + currentHunger + " Dirtiness : " + currentDirtiness + " Joy : " + currentJoy);
            Console.WriteLine(petType + " is " + petCondition.ToString().ToUpper());
        }
        public void FeedPet()
        {

        }

        public void BathePet()
        {

        }
        public void PlayWithPet()
        {

        }
        public void ChangePetsStats()
        {
            if (currentHunger + 1 < maxHunger)
            {
                currentHunger++;
            }
            else
            {
                currentHunger = maxHunger;
            }
            if (currentDirtiness + 1 < maxDirtiness)
            {
                currentDirtiness++;
            }
            else
            {
                currentDirtiness = maxDirtiness;
            }
            if (currentJoy - 0.5f > 0)
            {
                currentJoy -= 0.5f;
            }
            else
            {
                currentJoy = 0;
            }
            CalculateHappiness();
        }
        void CalculateHappiness()
        {
            //%40 hunger + %20 of dirtiness + %40 joy
            float happiness = (100 - currentHunger) * 0.4f + (100 - currentDirtiness) * 0.2f + currentJoy * 0.4f;
            
            if (happiness >= 80)
            {
                petCondition = PetCondition.Happy;
            }
            else if (happiness < 80 && happiness >= 60)
            {
                petCondition = PetCondition.Chıll;
            }
            else if (happiness < 60 && happiness >= 40)
            {
                if (petCondition != PetCondition.Angry)
                {
                    Console.WriteLine(petType + " is now ANGRY!");
                }
                petCondition = PetCondition.Angry;
            }
            else if (happiness < 40 && happiness >= 20)
            {
                if (petCondition != PetCondition.Sad)
                {
                    Console.WriteLine(petType + " is now SAD :(");
                }
                petCondition = PetCondition.Sad;
            }
            else if (happiness < 40 && happiness >= 1)
            {

                if (petCondition != PetCondition.Sick)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("HOLY MOLY!"+ petType + " IS SICK NOW");
                    Console.WriteLine("YOU BETTER TAKE CARE OF IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                petCondition = PetCondition.Sick;
            }
            else
            {
                //Kill the pet
            }

        }
    }
}
