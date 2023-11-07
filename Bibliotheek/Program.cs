﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TO DO     - bool instead of count
            //          - Remove empty strings from array

            Console.Title = "In de bibliotheek".ToUpper();

            string[] boekTitel = { "Les Fleurs du mal", "aaa" };
            string[] boekAuteurs = { "Charles Baudelaire", "000" };
            string[] tijdschriftNamen = { "National Geographic" };
            string[] gebruikers = { "Toto", "Jojo" };
            string[] borrowedBook = {"Bambi" , "Le Petit Prince", "bbb" };
            string[] borrowedUser = { "Toto", "Jojo", "Jojo" };

            WelcomeBericht();
            MainProgram(ref boekTitel, ref boekAuteurs, ref tijdschriftNamen, ref gebruikers);
            Console.ReadLine();
        }

        private static void ClearScreen()
        {
            //Console.ReadLine();
            Console.Clear();
            WelcomeBericht();
        }

        private static void MainProgram(ref string[] boekTitel, ref string[] boekAuteurs, ref string[] tijdschriftNamen, ref string[] gebruikers)
        {
            bool isRunning = true;
            string userMenuChoiceInput = "";

            while (isRunning)
            {
                Console.WriteLine("Maak uw keuze alstublieft.");
                Console.WriteLine("\t1. Materialen tonen.");
                Console.WriteLine("\t2. Materiaal toevoegen.");
                Console.WriteLine("\t3. Materiaal verwijderen.");
                Console.WriteLine("\t4. Materiaal zoeken.");
                Console.WriteLine("\t5. Nieuwe gebruiker registreren.");
                Console.WriteLine("\t6. Prograam sluiten.");
                Console.WriteLine();

                userMenuChoiceInput = Console.ReadLine();

                switch (userMenuChoiceInput)
                {
                    case "1":
                        ClearScreen();
                        Console.WriteLine("\"Materialen tonen\" gekozen.");
                        ToonMaterialen(boekTitel, boekAuteurs, tijdschriftNamen);
                        break;
                    case "2":
                        ClearScreen();
                        Console.WriteLine("\"Materialen toevoegen\" gekozen.");
                        VoegMateriaalToe(ref boekTitel, ref boekAuteurs, ref tijdschriftNamen);
                        break;
                    case "3":
                        ClearScreen();
                        Console.WriteLine("\"Materialen verwijderen\" gekozen.");
                        VerwijderMateriaal(boekTitel, boekAuteurs, tijdschriftNamen);
                        break;
                    case "4":
                        ClearScreen();
                        Console.WriteLine("\"Materiaal zoeken\" gekozen.");
                        ZoekMateriaal(boekTitel, boekAuteurs, tijdschriftNamen);
                        break;
                    case "5":
                        ClearScreen();
                        Console.WriteLine("\"Neuwe gebruiker registreren\" gekozen.");
                        gebruikers = RegistreerGebruiker(gebruikers);
                        break;
                    case "6":
                        ClearScreen();
                        Console.WriteLine("Tot ziens!");
                        isRunning = false;
                        break;
                    default:
                        ClearScreen();
                        Console.WriteLine($"\"{userMenuChoiceInput}\" is niet in de menu.\n");
                        break;
                }
            }
        }

        private static string[] RegistreerGebruiker(string[] gebruikers)
        {
            Console.Write("Naam van de nieuwe gebruiker: ");
            string nieuwGebruikerInput = Console.ReadLine();

            ClearScreen();

            Array.Resize(ref gebruikers, gebruikers.Length + 1);
            gebruikers[gebruikers.Length - 1] = nieuwGebruikerInput;

            Console.WriteLine($"{nieuwGebruikerInput} is nu een gebruiker van de VelSal bibliotheek!\n");
            return gebruikers;
        }

        private static void ZoekMateriaal(string[] boekTitel, string[] boekAuteurs, string[] tijdschriftNamen)
        {
            Console.Write("Naar welk boek of tijdschrift bent u op zoek? ");
            string searchElementInput = Console.ReadLine();

            ClearScreen();

            int count = 0;
            for (int i = 0; i < boekTitel.Length; i++)
            {
                if (boekTitel[i].ToLower() == searchElementInput.ToLower() || boekAuteurs[i].ToLower() == searchElementInput.ToLower())
                {
                    count++;
                    Console.WriteLine($"{boekTitel[i]} van {boekAuteurs[i]} is beschikbaar.");
                }
                else
                {
                    continue;
                }
                Console.WriteLine();
            }
            for (int i = 0; i < tijdschriftNamen.Length; i++)
            {
                if (tijdschriftNamen[i].ToLower() == searchElementInput.ToLower())
                {
                    count++;
                    Console.WriteLine($"{tijdschriftNamen[i]} is beschikbaar.");
                }
                else
                {
                     continue;
                }
                Console.WriteLine();
            }
            if (count == 0)
            {
                Console.WriteLine($"{searchElementInput} is niet beschikbaar.");
            }
        }

        private static void VerwijderMateriaal(string[] boekTitel, string[] boekAuteurs, string[] tijdschriftNamen)
        {
            ToonMaterialen(boekTitel, boekAuteurs, tijdschriftNamen);
            Console.Write("Welke materiaal wilt u verwijderen (schrijf de boek titel of tijdschrift naam a.u.b): ");
            string deleteBookInput = Console.ReadLine();

            ClearScreen();

            int count = 0;
            for (int i = 0; i < boekTitel.Length; i++)
            {
                if (boekTitel[i].ToLower() == deleteBookInput.ToLower())
                {
                    count++;
                    Console.WriteLine($"{boekTitel[i]} van {boekAuteurs[i]} verwijderd.\n");
                    boekTitel[i] = "";
                    boekAuteurs[i] = "";
                    //boekTitel[i] = null;
                }
            }
            for (int i = 0; i < tijdschriftNamen.Length; i++)
            {
                if (tijdschriftNamen[i].ToLower() == deleteBookInput.ToLower())
                {
                    count++;
                    Console.WriteLine($"{tijdschriftNamen[i]} verwijderd.\n");
                    tijdschriftNamen[i] = "";
                    //tijdschriftNamen[i] = null;
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"{deleteBookInput} is niet in de bibliotheek.");
            }
        }

        private static void VoegMateriaalToe(ref string[] boekTitel, ref string[] boekAuteurs, ref string[] tijdschriftNamen)
        {
            Console.WriteLine("Maak uw keuze alstublieft:");
            bool isRunningBookOrMagazine = true;
            while (isRunningBookOrMagazine)
            {
                Console.WriteLine("\t1. Boek toevoegen. \t2. Tijdschrift toevoegen.");
                string boekOfTijdschriftUserKeuze = Console.ReadLine();
                ClearScreen();
                if (boekOfTijdschriftUserKeuze == "1")
                {
                    Console.WriteLine("Welke boek wilt u toevoegen?");
                    Console.Write("Boek titel: ");
                    string boekTitelInput = Console.ReadLine();

                    Array.Resize(ref boekTitel, boekTitel.Length + 1);
                    boekTitel[boekTitel.Length - 1] = boekTitelInput;

                    Console.Write("Boek auteur: ");
                    string boekAuteurInput = Console.ReadLine();

                    Array.Resize(ref boekAuteurs, boekAuteurs.Length + 1);
                    boekAuteurs[boekAuteurs.Length - 1] = boekAuteurInput;

                    ClearScreen();
                    Console.WriteLine($"{boekTitelInput} van {boekAuteurInput} toegevoegd.\n");

                    break;
                }
                else if (boekOfTijdschriftUserKeuze == "2")
                {
                    Console.Write("Welke tijdschrift wilt u toevoegen? ");
                    string tijdschriftInput = Console.ReadLine();

                    Array.Resize(ref tijdschriftNamen, tijdschriftNamen.Length + 1);
                    tijdschriftNamen[tijdschriftNamen.Length - 1] = tijdschriftInput;

                    ClearScreen();
                    Console.WriteLine($"{tijdschriftInput} toegevoegd.\n");

                    break;
                }
                else
                {
                    Console.WriteLine("Kies tussen 1 en 2 alstublieft.");
                    continue;
                }
            }
        }

        private static void ToonMaterialen(string[] boekTitel, string[] boekAuteurs, string[] tijdschriftNamen)
        {
            Console.WriteLine("Boeken beschikbaar: ");
            
            for (int i = 0; i < boekTitel.Length; i++)
            {
                Console.WriteLine($"\t{boekTitel[i]} van {boekAuteurs[i]}.");
            }
            Console.WriteLine("Tijdschriften beschikbaar: ");
            for (int i = 0; i < tijdschriftNamen.Length; i++)
            {
                Console.WriteLine($"\t{tijdschriftNamen[i]}");
            }
            Console.WriteLine();
        }

        private static void WelcomeBericht()
        {
            Console.Write("Welcome to the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("VelSal ");
            Console.ResetColor();
            Console.WriteLine("Bibliotheek.\n");
            Console.WriteLine("      __...--~~~~~-._   _.-~~~~~--...__\n    //               `V'               \\\\\n   //                 |                 \\\\\n  //__...--~~~~~~-._  |  _.-~~~~~~--...__\\\\ \n //__.....----~~~~._\\ | /_.~~~~----.....__\\\\\n====================\\\\|//====================\n                    `---`\n");

            /*
      __...--~~~~~-._   _.-~~~~~--...__
    //               `V'               \\ 
   //                 |                 \\ 
  //__...--~~~~~~-._  |  _.-~~~~~~--...__\\ 
 //__.....----~~~~._\ | /_.~~~~----.....__\\
====================\\|//====================
                    `---`
            */
        }
    }
}