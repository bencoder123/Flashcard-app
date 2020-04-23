using System;
using System.Collections.Generic;
using System.IO;


/// Program Name: Flashcards App (temporary name)
/// Program Description: A program that saves and reads 
/// flashcards for the user. 

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
        /// Creates a new card group within /cards.
        static void createCardGroup()
        {
            Console.WriteLine("What would you like the new flashcard group to be called?");
            string folderName = Console.ReadLine();
            string path = @"C:\Users\User\source\repos\Flashcards\cards\" + folderName;

            try
            {
                // Determine whether the directory exists. 
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }
        /// Deletes a specified directory within /cards.
        /// This will also delete all text files (cards) within the 
        /// card group.
        static void deleteCardGroup()
        {
            Console.WriteLine("Which card group would you like to delete?");
            string folderName = Console.ReadLine();
            string path = @"C:\Users\User\source\repos\Flashcards\cards\" + folderName;

            try
            {
                // Determine whether the directory exists. 
                if (Directory.Exists(path))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("WARNING: All cards within the group will be lost.");
                    Console.ResetColor();
                    Console.Write("Are you sure you want to delete this card group? (y/n)");
                    Directory.Delete(path, true);
                    return;
                }
                else
                {
                    Console.WriteLine("The specified card group does not exist.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        /// Create a new text file (a card) containing
        /// two lines, which correspond to two sides of 
        /// a card.
        static void createCard()
        {
            while(true) { 
                Console.WriteLine("Which card group would you like to modify?");
                string path = @"C:\Users\User\source\repos\Flashcards\cards\" + Console.ReadLine();
                if (Directory.Exists(path))
                {
                    string[] cardContent = { "", "" };
                    //ask user to populate two sides of the card
                    Console.Write("What would you like to write on side 1?");
                    cardContent[0] = Console.ReadLine();

                    Console.Write("What would you like to write on side 2?");
                    cardContent[1] = Console.ReadLine();

                    string textFileName = "1";
                    //create and write to new text file
                    System.IO.File.WriteAllLines(@path + "/" + textFileName + ".txt", cardContent);
                    break;
                }
                else
                {
                    Console.WriteLine("The specified card group does not exist.");
                }
            }


        }
        /// Displays the directories("card groups") within /cards.
        static void displayCardGroups()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Your card groups: ");
            string targetDirectory = @"C:\Users\User\source\repos\Flashcards\cards\";

            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetDirectories(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);


            Console.WriteLine("---------------------------------------------");
        }
        /// Method for formatting and printing 
        /// the card group names.
        public static void ProcessFile(string path)
        {
            path = path.Replace(@"C:\Users\User\source\repos\Flashcards\cards\", "");
            Console.WriteLine(" - {0}", path);
        }
        //main
        static int Main(string[] args)
        {
            Console.WriteLine("Welcome to the Flashcards app.");
            //loop to allow for continuous usage
            while (true)
            {
                Console.Clear();
                //main menu
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
                        createCardGroup();
                        break;
                    case "2":
                        displayCardGroups();
                        break;
                    case "3":
                        deleteCardGroup();
                        break;
                    case "4":
                        createCard();
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
                Console.ReadKey();

            }
        }
    }
}
