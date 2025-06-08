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

            currentHunger = 50;
            currentSleep = 50;
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
                    currentHunger = Math.Min(currentHunger + selectedItem.EffectAmount, 100);
                    break;
                case PetStat.Sleep:
                    currentSleep = Math.Min(currentSleep + selectedItem.EffectAmount, 100);
                    break;
                case PetStat.Fun:
                    currentJoy = Math.Min(currentJoy + selectedItem.EffectAmount, 100);
                    break;
            }
            Console.WriteLine("Items are applied");
        }

        public void ChangePetsStats()
        {
            currentHunger--;
            currentSleep--;
            currentJoy --;

            CalculateHappiness();
        }
        void CalculateHappiness()
        {
            //%40 hunger + %20 of Sleep + %40 joy
            float happiness =  currentHunger * 0.4f + currentSleep * 0.2f + currentJoy * 0.4f;

            if (happiness >= 70)
            {
                petCondition = PetCondition.Happy;
            }
            else if (happiness < 70 && happiness >= 45)
            {
                petCondition = PetCondition.Chıll;
            }
            else if (happiness < 45 && happiness >= 30)
            {
                if (petCondition != PetCondition.Angry)
                {
                    Console.WriteLine(petType + " is now ANGRY!");
                }
                petCondition = PetCondition.Angry;
            }
            else if (happiness < 30 && happiness >= 10)
            {
                if (petCondition != PetCondition.Sad)
                {
                    Console.WriteLine(petType + " is now SAD :(");
                }
                petCondition = PetCondition.Sad;
            }
            else if (happiness < 10 && happiness >= 1)
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
