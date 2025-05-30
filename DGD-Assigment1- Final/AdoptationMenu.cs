using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DGD_Assigment1__Final
{
    internal class AdoptationMenu
    {

        Program programScript;

        public void DeclareProgram(Program _programScript)
        {
            programScript = _programScript;

        }

        public void ShowAdoptationOptions()
        {
            bool exitedAdoptationMenu = false;

            while (!exitedAdoptationMenu)
            {
                Console.Clear();
                Console.WriteLine("1- Adopt a Dragon");
                Console.WriteLine("2- Adopt a Three Headed Dog");
                Console.WriteLine("3- Adopt a Frog");
                Console.WriteLine("4- Adopt a Tarantula");
                Console.WriteLine("5- Adopt a Giraffe");
                Console.WriteLine("6- Return to Main Menu");

                string userInput = Console.ReadLine();
                Console.Clear();
                if (userInput == "1")
                {
                    programScript.AdoptPet(PetType.Dragon);
                    Console.WriteLine("Dragon is adopted! So Cute!");
                    exitedAdoptationMenu = true;
                }
                else if (userInput == "2")
                {
                    programScript.AdoptPet(PetType.ThreeHeadedDog);
                    Console.WriteLine("Three Headed Dog is adopted! Adorable!");

                    exitedAdoptationMenu = true;
                }
                else if (userInput == "3")
                {
                    programScript.AdoptPet(PetType.Frog);
                    Console.WriteLine("Frog is adopted! Vrak!");

                    exitedAdoptationMenu = true;
                }
                else if (userInput == "4")
                {

                    programScript.AdoptPet(PetType.Tarantula);
                    Console.WriteLine("Tarantula is adopted! He has all 6 legs!");
                    exitedAdoptationMenu = true;
                }
                else if (userInput == "5")
                {

                    programScript.AdoptPet(PetType.Giraffe);
                    Console.WriteLine("Giraffe is adopted! Definitely taller than you!");
                    exitedAdoptationMenu = true;
                }
                else if (userInput == "6")
                {
                    Console.WriteLine("Returning Main Menu");

                    exitedAdoptationMenu = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID INPUT!!!");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }//Class
}//NameSpcae
