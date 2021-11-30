using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryQuestions
{
    internal static class Program
    {
        private static BtTree? _tree;
        private static readonly List<BtNode?> PassedNodes = new();

        private static void Main()
        {
            //There's no need to ask for the initial data when it already exists
            if (File.Exists("serialized.bin"))
            {
                _tree = new BtTree();
                PrintOrder();
            }
            else

                StartNewGame();

            Console.WriteLine("\nStarting the \"20 Binary Questions\" Game!\nThink of an object, person or animal.");

            _tree?.Query(); //play one game

            while (PlayAgain())
            {
                Console.WriteLine("\nThink of an object, person or animal.");
                Console.WriteLine();
                _tree?.Query(); //play one game
            }
        }

        private static void PrintOrder()
        {
            Console.WriteLine("Busy Printing PreOrder...\n");
            PrintPreOrder(_tree?.GetRootNode);
            Console.WriteLine("\nEnd of the PreOrder\n");

            PassedNodes.Clear();
            Console.WriteLine("Busy Printing InOrder...\n");
            PrintInOrder(_tree?.GetRootNode);
            Console.WriteLine("\nEnd of the InOrder\n");

            PassedNodes.Clear();
            Console.WriteLine("Busy Printing PostOrder...\n");
            PrintPostOrder(_tree?.GetRootNode);
            Console.WriteLine("\nEnd of the PostOrder\n");
        }

        /// <summary>
        ///     Access the pre order 
        /// </summary>
        /// <param name="node"> current binary tree node </param>
        private static void PrintPreOrder(BtNode? node)
        {
            if (!PassedNodes.Contains(node))
            {
                PassedNodes.Add(node);
                Console.WriteLine(node?.GetMessage());
                PrintPreOrder(node);
            }

            if (node?.GetNoNode() != null)
            {
                if (!PassedNodes.Contains(node.GetNoNode()))
                {
                    PassedNodes.Add(node.GetNoNode());
                    Console.WriteLine(node.GetNoNode()?.GetMessage());
                    PrintPreOrder(node.GetNoNode());
                }
            }

            if (node?.GetYesNode() == null) return;
            if (PassedNodes.Contains(node.GetYesNode())) return;
            PassedNodes.Add(node.GetYesNode());
            Console.WriteLine(node.GetYesNode()?.GetMessage());
            PrintPreOrder(node.GetYesNode());
        }
        
        /// <summary>
        ///     Access the in order 
        /// </summary>
        /// <param name="node"> current node in the tree </param>
        private static void PrintInOrder(BtNode? node)
        {
            if (node?.GetNoNode() != null)
            {
                if (!PassedNodes.Contains(node.GetNoNode()))
                {
                    PrintInOrder(node.GetNoNode());
                }
            }

            if (!PassedNodes.Contains(node))
            {
                PassedNodes.Add(node);
                Console.WriteLine(node?.GetMessage() + ", Evaluation = " + node.GetEvaluation());
                PrintInOrder(node);
            }

            if (node?.GetYesNode() == null) return;
            
            if (!PassedNodes.Contains(node.GetYesNode()))
            {
                PrintInOrder(node.GetYesNode());
            }
        }

        /// <summary>
        ///     Access the post order 
        /// </summary>
        /// <param name="node"> current node in the tree </param>
        private static void PrintPostOrder(BtNode? node)
        {
            if (node?.GetNoNode() != null)
            {
                if (!PassedNodes.Contains(node.GetNoNode()))
                {
                    PrintPostOrder(node.GetNoNode());
                }
            }

            if (node?.GetYesNode() != null)
            {
                if (!PassedNodes.Contains(node.GetYesNode()))
                {
                    PrintPostOrder(node.GetYesNode());
                }
            }

            if (!PassedNodes.Contains(node))
            {
                PassedNodes.Add(node);
                Console.WriteLine(node?.GetMessage());
                PrintPostOrder(node);
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

            Console.Write(
                "Enter a possible guess (an object, person or animal) if the response to this question is Yes: ");
            var yesGuess = Console.ReadLine();

            Console.Write(
                "Enter a possible guess (an object, person or animal) if the response to this question is No: ");
            var noGuess = Console.ReadLine();

            _tree = new BtTree(question, yesGuess, noGuess);
        }
    }
}