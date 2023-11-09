using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bibliotheek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TO DO     - bool instead of count

            Console.Title = "In de bibliotheek".ToUpper();

            string[] boekTitel = { "les fleurs du mal", "don Quichotte", "monster" };
            string[] boekAuteurs = { "charles baudelaire", "miguel de cervantes", "naoki urasawa" };
            string[] tijdschriftNamen = { "national geographic" };
            string[] gebruikers = { "toto", "jojo" };
            string[] borrowedMaterials = {"vogue" , "le petit prince", "pluto" };
            string[] borrowedUser = { "toto", "jojo", "jojo" };

            WelcomeBericht();
            MainProgram(ref boekTitel, ref boekAuteurs, ref tijdschriftNamen, ref gebruikers, ref borrowedMaterials, ref borrowedUser);
            Console.ReadLine();
        }

        static void ClearScreen()
        {
            //Console.ReadLine();
            Console.Clear();
            WelcomeBericht();
        }

        private static void MainProgram(ref string[] boekTitel, ref string[] boekAuteurs, ref string[] tijdschriftNamen, ref string[] gebruikers, ref string[] borrowedMaterials, ref string[] borrowedUser)
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
                Console.WriteLine("\t6. Materialen uitlenen YET TO DO.");
                Console.WriteLine("\t7. Materialen terugbrengen YET TO DO.");
                Console.WriteLine("\t8. Prograam sluiten.");
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
                        ToonMaterialen(boekTitel, boekAuteurs, tijdschriftNamen);
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
                        Console.WriteLine("\"Materialen uitlenen\" gekozen.");
                        Console.WriteLine("1. Uitgeleend materialen zien.");
                        Console.WriteLine("2. Materiaal lenen.");
                        string lendChoice = Console.ReadLine();
                        while (lendChoice == "1" || lendChoice == "2")
                        {
                            if (lendChoice == "1")
                            {
                                for (int i = 0; i < borrowedMaterials.Length; i++)
                                {
                                    Console.WriteLine($"{borrowedMaterials[i]} uitgeleend aan {borrowedUser[i]}.");
                                }
                                break;
                            }
                            else if (lendChoice == "2")
                            {
                                Console.WriteLine("Welke gebruiker wilt een materiaal uitlenen? ");
                                string renterUserInput = Console.ReadLine();
                                for (int i = 0; i < gebruikers.Length; i++)
                                {
                                    if (gebruikers[i].ToLower() == renterUserInput.ToLower())
                                    {
                                        bool inLendMenu = true;
                                        while (inLendMenu)
                                        {
                                            //What material to lend
                                            Console.WriteLine("Welke soort materiaal wilt de gebruiker uitlenen?");
                                            Console.WriteLine("\t1. Boek \t2. Tijdschrift");
                                            string materialChoice = Console.ReadLine();
                                            //if book available => ok
                                            if (materialChoice == "1")
                                            {
                                                Console.Write("Titel van de boek: ");
                                                LendBook(boekTitel, gebruikers, ref borrowedMaterials, ref borrowedUser, i);

                                                inLendMenu = false;
                                            }
                                            else if (materialChoice == "2")
                                            {
                                                Console.Write("Titel van de tijdschrift: ");
                                                LendMagazine(tijdschriftNamen, gebruikers, ref borrowedMaterials, ref borrowedUser, i);
                                                inLendMenu = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Verkeerde invoer...");
                                                inLendMenu = false;
                                            }
                                            
                                            //remove material from first array
                                        }

                                    }
                                    else
                                    {
                                        //User not in array
                                        //Does the user want to be a client?
                                        //if no : cw must be a client to borrow book
                                        //if yes: what material to lend
                                        //if book available => ok
                                        //if not => not ok
                                        //cw book lent to user
                                        //remove material from first array
                                        //add material to borrowed array
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    case "7":
                        ClearScreen();
                        Console.WriteLine("\"Materialen teruggeven\" gekozen.");
                        //Code here
                        break;
                    case "8":
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

        private static void LendBook(string[] boekTitel, string[] gebruikers, ref string[] borrowedMaterials, ref string[] borrowedUser, int i)
        {
            string materialTitleChoice = Console.ReadLine().ToLower();
            if (boekTitel.Contains(materialTitleChoice))
            {
                Console.WriteLine($"{materialTitleChoice} uitgeleend aan {gebruikers[i]}");
                Array.Resize(ref borrowedMaterials, borrowedMaterials.Length + 1);
                borrowedMaterials[borrowedMaterials.Length - 1] = materialTitleChoice;
                Array.Resize(ref borrowedUser, borrowedUser.Length + 1);
                borrowedUser[borrowedUser.Length - 1] = gebruikers[i];
            }
            else
            {
                Console.WriteLine($"{materialTitleChoice} is niet beschikbaar.");
            }
        }
        private static void LendMagazine(string[] tijdschriftNamen, string[] gebruikers, ref string[] borrowedMaterials, ref string[] borrowedUser, int i)
        {
            string materialTitleChoice = Console.ReadLine().ToLower();
            if (tijdschriftNamen.Contains(materialTitleChoice))
            {
                Console.WriteLine($"{materialTitleChoice} uitgeleend aan {gebruikers[i]}");
                Array.Resize(ref borrowedMaterials, borrowedMaterials.Length + 1);
                borrowedMaterials[borrowedMaterials.Length - 1] = materialTitleChoice;
                Array.Resize(ref borrowedUser, borrowedUser.Length + 1);
                borrowedUser[borrowedUser.Length - 1] = gebruikers[i];
            }
            else
            {
                Console.WriteLine($"{materialTitleChoice} is niet beschikbaar.");
            }
        }
        private static string[] RegistreerGebruiker(string[] gebruikers)
        {
            Console.Write("Naam van de nieuwe gebruiker: ");
            string nieuwGebruikerInput = Console.ReadLine();

            ClearScreen();

            Array.Resize(ref gebruikers, gebruikers.Length + 1);
            gebruikers[gebruikers.Length - 1] = nieuwGebruikerInput;

            Console.WriteLine($"{nieuwGebruikerInput} is nu een gebruiker van de O, R & S bibliotheek!\n");
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
                }
            }

            for (int i = 0; i < tijdschriftNamen.Length; i++)
            {
                if (tijdschriftNamen[i].ToLower() == deleteBookInput.ToLower())
                {
                    count++;
                    Console.WriteLine($"{tijdschriftNamen[i]} verwijderd.\n");
                    tijdschriftNamen[i] = "";
                }
            }
            if (count == 0)
            {
                Console.WriteLine($"{deleteBookInput} is niet in de bibliotheek.");
            }

            RemoveEmptyElements(ref boekTitel, ref boekAuteurs, ref tijdschriftNamen);
        }

        private static void RemoveEmptyElements(ref string[] boekTitel, ref string[] boekAuteurs, ref string[] tijdschriftNamen)
        {
            boekTitel = boekTitel.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            boekAuteurs = boekAuteurs.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            tijdschriftNamen = tijdschriftNamen.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
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
            RemoveEmptyElements(ref boekTitel, ref boekAuteurs, ref tijdschriftNamen);

            Console.WriteLine("\nBeschikbaar materialen: \n");
            if (boekTitel.Length <= 0)
            {
                Console.WriteLine("Sorry, er zijn geen beschikbaar boeken.");
            }
            else
            {
                Console.WriteLine("Beschikbaar boeken: ");
                for (int i = 0; i < boekTitel.Length; i++)
                {
                    Console.WriteLine($"\t{boekTitel[i]} van {boekAuteurs[i]}.");
                }
            }
            
            if (tijdschriftNamen.Length <= 0)
            {
                Console.WriteLine("Sorry er zijn geen beschikbaar tijdschriften.");
            }
            else
            {
                Console.WriteLine("Beschikbaar tijdschriften: ");
                for (int i = 0; i < tijdschriftNamen.Length; i++)
                {
                    Console.WriteLine($"\t{tijdschriftNamen[i]}");
                }
            }
            Console.WriteLine();
        }

        private static void WelcomeBericht()
        {
            Console.Write("Welcome to the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("O, R & S ");
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
