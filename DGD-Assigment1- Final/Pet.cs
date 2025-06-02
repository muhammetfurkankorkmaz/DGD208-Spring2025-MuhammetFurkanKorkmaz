using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGD_Assigment1__Final
{
    internal class Pet
    {
        public PetType petType { get; private set; }
        PetCondition petCondition;

        public PetHolder petHolderScript;


        public float currentHunger { get; private set; }

        public float currentJoy { get; private set; }

        public float currentSleep { get; private set; }

        public float currentHappiness { get; private set; }


        public void InitializePet(PetType _petType)
        {
            petType = _petType;

            currentHunger = 40;
            currentSleep = 40;
            currentJoy = 50;
        }
        public void ReturnPetData()
        {
            Console.WriteLine(petType + " -> Hunger :" + currentHunger + " Sleep: " + currentSleep + " Joy : " + currentJoy);
            Console.WriteLine(petType + " is " + petCondition.ToString().ToUpper());
        }

        public void ApplyItemEffectToPet(Item selectedItem)
        {
            switch (selectedItem.AffectedStat)
            {
                case PetStat.Hunger:
                    currentHunger = Math.Min(currentHunger - selectedItem.EffectAmount, 100);
                    break;
                case PetStat.Sleep:
                    currentSleep = Math.Min(currentSleep - selectedItem.EffectAmount, 100);
                    break;
                case PetStat.Fun:
                    currentJoy = Math.Min(currentJoy + selectedItem.EffectAmount, 100);
                    break;
            }
            Console.WriteLine("Items are applied");
        }

        public void ChangePetsStats()
        {
            currentHunger++;
            currentSleep++;
            currentJoy --;

            CalculateHappiness();
        }
        void CalculateHappiness()
        {
            //%40 hunger + %20 of Sleep + %40 joy
            float happiness = (100 - currentHunger) * 0.4f + (100 - currentSleep) * 0.2f + currentJoy * 0.4f;

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
                    Console.WriteLine("HOLY MOLY!" + petType + " IS SICK NOW");
                    Console.WriteLine("YOU BETTER TAKE CARE OF IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                petCondition = PetCondition.Sick;
            }
            else
            {
                petHolderScript.KillPet(this);
            }

        }
    }
}
