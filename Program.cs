using System;
using System.Collections.Generic;
using System.IO;

namespace Flashcards
{
    class Program
    {
        
        /// Get the directory of the program and return 
        /// a string containing the "\cards" directory.
        static string getUserDirectory()
        {
            string path = Directory.GetCurrentDirectory();
            if (path.Contains("bin\\Debug"))
            {
                path = path.Replace("bin\\Debug", "cards\\");
            }
            return path;

        }
        static IList<Card>[] makeList()
        {
            //get card group paths and store it in a string array
            string[] folders = Directory.GetDirectories(getUserDirectory());

            //number of card groups the user has
            int numGroups = folders.Length;

            IList<Card>[] iListArray = new IList<Card>[numGroups];
        }
        static int Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                //main menu
                Console.WriteLine("-----Flashcards App LINKED LIST SOLUTION-----\n");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("\n\t1: Create card group");
                Console.WriteLine("\n\t2: Display card groups");
                Console.WriteLine("\n\t3: Delete card group");
                Console.WriteLine("\n\t4: Create card");
                Console.WriteLine("\n\t5: Read cards");
                Console.WriteLine("\n\t6: Delete card");
                Console.WriteLine("\n\t7: Exit program\n");
                Console.WriteLine("---------------------------------------------");

                //get user's command
                string choice = Console.ReadLine();

                //switch cases to lead to different functions
                switch (choice)
                {

                    case "1":
                        break;
                    case "2":

                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        return 1;//terminate program
                    default:
                        Console.WriteLine("Invalid command. Please try again: ");
                        break;

                }

            }
        }
    }
}
