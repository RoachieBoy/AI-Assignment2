using System;
using System.IO;
using System.Linq;

namespace BinaryQuestions
{
    internal static class Program
    {
        private static BtTree _tree;

        private static void Main()
        {
            //There's no need to ask for the initial data when it already exists
            if (File.Exists("serialized.bin"))
                _tree = new BtTree();
            else
                StartNewGame();

            Console.WriteLine("\nStarting the \"20 Binary Questions\" Game!\nThink of an object, person or animal.");
            
            _tree.Query(); //play one game
            
            while(PlayAgain())
            {
                Console.WriteLine("\nThink of an object, person or animal.");
                Console.WriteLine();
                _tree.Query(); //play one game
            }
        }

        private static bool PlayAgain()
        {
            Console.Write("\nPlay Another Game? ");
            
            var inputCharacter = Console.ReadLine().ElementAt(0);
            
            inputCharacter = char.ToLower(inputCharacter);
            
            while (inputCharacter != 'y' && inputCharacter != 'n')
            {
                Console.WriteLine("Incorrect input please enter again: ");
                
                inputCharacter = Console.ReadLine().ElementAt(0);
                
                inputCharacter = char.ToLower(inputCharacter);
            }
            
            return inputCharacter == 'y';
        }

        private static void StartNewGame()
        {
            Console.WriteLine("No previous knowledge found!");
            Console.WriteLine("Initializing a new game.\n");
            Console.WriteLine("Enter a question about an object, person or animal: ");
            var question = Console.ReadLine();
            
            Console.Write("Enter a possible guess (an object, person or animal) if the response to this question is Yes: ");
            var yesGuess = Console.ReadLine();
            
            Console.Write("Enter a possible guess (an object, person or animal) if the response to this question is No: ");
            var noGuess = Console.ReadLine();

            _tree = new BtTree(question, yesGuess, noGuess);
        }
    }
}