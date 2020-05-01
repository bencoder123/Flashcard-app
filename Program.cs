﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// Program Name: Flashcards App (temporary name)
/// Program Description: A program that saves and reads 
/// flashcards for the user. 

namespace Flashcards
{
    class Program
    {
        //the IList array containing the user's card collection
        IList<Card>[] cardsCollection = makeList();


        /// Get the directory of the program and return 
        /// a string containing the "\cards" directory.
        static string getUserDirectory()
        {
            string path = Directory.GetCurrentDirectory();
            if (path.Contains("bin\\Debug\\netcoreapp3.1"))
            {
                path = path.Replace("bin\\Debug\\netcoreapp3.1", "cards\\");
            }
            return path;

        }

        static IList<Card>[] makeList()
        {
            //get card group directories and store it in a string array
            string[] fileEntries = Directory.GetDirectories(getUserDirectory());

            //number of card groups the user has
            int numGroups = fileEntries.Length;

            //Create an array of ILists. The size of the array depends on the number of 
            //card groups the user has.
            IList<Card>[] iListArray = new IList<Card>[numGroups];



            //get cards from each card group
            for (int i = 0; i < fileEntries.Length; i++)
            {
                int cardCount = System.IO.Directory.GetFiles(fileEntries[i]).Length;
                Console.WriteLine(fileEntries[i]);
                Console.WriteLine(cardCount);
            }
            return iListArray;
        }
        /// Creates a new card group within /cards.
        static void createCard()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Which card group would you like to modify?");
                displayCardGroups(false);
                string path = getUserDirectory() + Console.ReadLine();
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("The card was created successcully. Press any key to continue.");
            Console.ResetColor();
            Console.ReadKey();
        }
        /// Allows the user to select a card group and
        /// read its cards.
        static void readCards()
        {

        }

        /// Allows the user to select a card group and 
        /// delete a card from it.
        static void deleteCard()
        {
            string folderName;
            string deleteCard;
            //select card group to modify
            while (true)
            {
                Console.WriteLine("Which card group would you like to modify?");
                displayCardGroups(false);
                folderName = Console.ReadLine();

                if (Directory.Exists(getUserDirectory() + folderName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The specified card group does not exist. Please try again.");
                }


                //select and delete card
                displayCards(folderName);
                Console.WriteLine("Which card would you like to delete?");
                while (true)
                {
                    deleteCard = Console.ReadLine();
                    if (File.Exists(getUserDirectory() + folderName + "\\" + deleteCard))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The specified card does not exist. Please try again.");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING: All cards within the group will be lost. ");
                Console.ResetColor();
                Console.WriteLine("Are you sure you want to delete this card group? (y/n)");
                string choice = Console.ReadLine();
                try
                {
                    if (choice.Equals("y") || choice.Equals("Y"))
                    {
                        File.Delete(getUserDirectory() + folderName + "\\" + deleteCard);
                    }
                    else
                    {
                        Console.WriteLine("No cards were deleted.");
                        return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("The card ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(deleteCard);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" was deleted succesfully. Press any key to continue.");
                Console.ResetColor();
                Console.ReadKey();



            }

           
            


        }
        static void displayCards(string group)
        {
            Console.Clear();
            Console.WriteLine("-------------- " + group + " ---------------");
            string targetDirectory = getUserDirectory();
            string[] fileEntries = Directory.GetFiles(targetDirectory + group + "\\");
            foreach (string fileName in fileEntries)
                ProcessFiles(fileName, group);

            Console.WriteLine("---------------------------------------------");

        }
        static void ProcessFiles(string path, string cardGroup)
        {
            path = path.Replace(getUserDirectory() + cardGroup + "\\", "");
            Console.WriteLine(" - {0}", path);
        }

        /// Deletes a specified directory within /cards.
        /// This will also delete all text files (cards) within the 
        /// card group.
        static void deleteCardGroup()
        {
            Console.Clear();
            Console.WriteLine("Which card group would you like to delete?");
            displayCardGroups(false);
            string folderName = Console.ReadLine();
            string path = getUserDirectory() + folderName;

            try
            {
                // Determine whether the directory exists. 
                if (Directory.Exists(path))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("WARNING: All cards within the group will be lost. ");
                    Console.ResetColor();
                    Console.Write("Are you sure you want to delete this card group? (y/n)");
                    string choice = Console.ReadLine();
                    if (choice.Equals("y") || choice.Equals("Y"))
                    {
                        Directory.Delete(path, true);
                    }
                    else
                    {
                        Console.WriteLine("No card groups were deleted.");
                        return;
                    }


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
            finally {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("The card group ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(folderName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" was deleted succesfully. Press any key to continue.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        /// Create a new text file (a card) containing
        /// two lines, which correspond to two sides of 
        /// a card.

        /// Displays the directories("card groups") within /cards.
        static void displayCardGroups(bool calledFromMain)
        {
            Console.WriteLine("--------------Your card groups---------------");
            string targetDirectory = getUserDirectory();

            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetDirectories(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFolder(fileName);


            Console.WriteLine("---------------------------------------------");

            if (calledFromMain)
            {
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
        /// Method for formatting and printing 
        /// the card group names.
        public static void ProcessFolder(string path)
        {
            path = path.Replace(getUserDirectory(), "");
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

                makeList();
                //get user's command
                string choice = Console.ReadLine();

                //switch cases to lead to different functions
                switch (choice)
                {

                    case "1":
                        createCardGroup();
                        break;
                    case "2":
                        Console.Clear();
                        displayCardGroups(true);
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
                        deleteCard();
                        break;
                    case "7":
                        return 1;//terminate program
                    default:
                        Console.WriteLine("Invalid command. Please try again: ");
                        break;

                }

            }
        }
        static void createCardGroup()
        {
            Console.WriteLine("What would you like the new flashcard group to be called?");
            string folderName = Console.ReadLine();
            string path = getUserDirectory() + folderName;

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
                //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

            //inform user of successful card group creation
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("The card group ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(folderName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" was created succesfully. Press any key to continue.");
            Console.ResetColor();
            Console.ReadKey();
        }


    }
}
