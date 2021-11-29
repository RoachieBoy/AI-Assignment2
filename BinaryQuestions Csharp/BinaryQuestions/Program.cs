using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinaryQuestions
{
    class Program
    {
        static BTTree tree;
        static void Main(string[] args)
        {
            //There's no need to ask for the initial data when it already exists
            if (File.Exists("serialized.bin"))
                tree = new BTTree();
            else
                StartNewGame();

            Console.WriteLine("\nStarting the \"20 Binary Questions\" Game!\nThink of an object, person or animal.");
            tree.Query(); //play one game
            while(PlayAgain())
            {
                Console.WriteLine("\nThink of an object, person or animal.");
                Console.WriteLine();
                tree.Query(); //play one game
            }
        }

        static bool PlayAgain()
        {
            Console.Write("\nPlay Another Game? ");
            char inputCharacter = Console.ReadLine().ElementAt(0);
            inputCharacter = Char.ToLower(inputCharacter);
            while (inputCharacter != 'y' && inputCharacter != 'n')
            {
                Console.WriteLine("Incorrect input please enter again: ");
                inputCharacter = Console.ReadLine().ElementAt(0);
                inputCharacter = Char.ToLower(inputCharacter);
            }
            if (inputCharacter == 'y')
                return true;
            else
                return false;
        }

        static void StartNewGame()
        {
            Console.WriteLine("No previous knowledge found!");
            Console.WriteLine("Initializing a new game.\n");
            Console.WriteLine("Enter a question about an object, person or animal: ");
            string question = Console.ReadLine();
            Console.Write("Enter a possible guess (an object, person or animal) if the response to this question is Yes: ");
            string yesGuess = Console.ReadLine();
            Console.Write("Enter a possible guess (an object, person or animal) if the response to this question is No: ");
            string noGuess = Console.ReadLine();

            tree = new BTTree(question, yesGuess, noGuess);
        }
    }
}
