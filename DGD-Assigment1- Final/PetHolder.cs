using System;
using System.Collections.Generic;

namespace DGD_Assigment1__Final
{
    internal class PetHolder
    {
        Program programScript;


        public void DeclareProgram(Program _programScript)
        {
            programScript = _programScript;
            programScript.onNewPetAdapt += CreatePet;
            programScript.onDecreaseStat += ChangePetStats;
        }

        List<Pet> petScripts = new List<Pet>();

        public int currentPetAmount { get;private set; } = 0;

        public void CreatePet(PetType newPetType)
        {
            Pet _pet = new Pet();
            _pet.petHolderScript = this;

            petScripts.Add(_pet);
            petScripts[currentPetAmount].InitializePet(newPetType);
            currentPetAmount++;
        }

        public void ShowCurrentPets()
        {
            for (int i = 0; i < petScripts.Count; i++)
            {
                petScripts[i].ReturnPetData();
            }
            Console.WriteLine(" ");
        }

        public void KillPet(Pet _petToKill)
        {
            if (petScripts.Contains(_petToKill))
            {
                petScripts.Remove(_petToKill);
            }
            currentPetAmount--;
        }

        void ChangePetStats()
        {
            for (int i = 0; i < petScripts.Count; i++)
            {
                petScripts[i].ChangePetsStats();
            }
        }
        public List<Pet> GetPets()
        {
            return petScripts;
        }
    }
}//Class
