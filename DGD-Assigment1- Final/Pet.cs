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
        void DecreaseStat()
        {

        }
        void CalculateHappiness()
        {

        }
    }
}
