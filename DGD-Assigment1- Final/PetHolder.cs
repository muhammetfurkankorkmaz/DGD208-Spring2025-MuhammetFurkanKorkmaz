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

        List<PetType> pets = new List<PetType>();
        List<Pet> petScripts = new List<Pet>();

        int currentPetAmount = 0;

        public void CreatePet(PetType newPetType)
        {
            pets.Add(newPetType);
            petScripts.Add(new Pet());
            petScripts[currentPetAmount].InitializePet(newPetType);
            currentPetAmount++;
        }

        public void ShowCurrentPets()
        {
            for (int i = 0; i < pets.Count; i++)
            {
                petScripts[i].ReturnPetData();
            }
        }

        public void KillPet(Pet _petToKill)
        {
            if (petScripts.Contains(_petToKill))
            {
                //Finds which one is and removes it
                petScripts.Remove(_petToKill);
                //pets.Remove();
            }
            currentPetAmount--;
        }

        void ChangePetStats()
        {
            for (int i = 0; i < pets.Count; i++)
            {
                petScripts[i].ChangePetsStats();
            }
        }

    }
}
