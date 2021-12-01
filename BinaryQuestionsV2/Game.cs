using BinaryQuestionsV2.BaseEngine;
using BinaryQuestionsV2.BinaryTreeDataStructure;

namespace BinaryQuestionsV2
{
    public class Game
    {
        private BTree<string> _currentGameData;

        public Game(BTree<string> currentGameData)
        {
            _currentGameData = currentGameData;
        }

        /// <summary>
        /// </summary>
        public void Update()
        {
        }

        private void CheckForQuit()
        {
            if (InputHandler.CheckInput(ConsoleKey.X))
            {
                Program.QuitGame(_currentGameData);
            }
        }
        
        private void Query(BtNode<string> node, int number = 1)
        {
            if (node.Left is not null && node.Right is not null)
            {
                Console.Write($"{number} Question: {node.Key} \nEnter 'y' for yes and 'n' for no:");

                if (InputHandler.CheckInput(ConsoleKey.Y))
                {
                    Query(node.Left);
                }

                if (InputHandler.CheckInput(ConsoleKey.N))
                {
                    Query(node.Right);
                }

                CheckForQuit();
            }
            else
            {
                if (InputHandler.CheckInput(ConsoleKey.Y))
                {
                    Console.WriteLine("I win!");
                }

                if (InputHandler.CheckInput(ConsoleKey.N))
                {
                    AddQueryOnLose(node);
                }
            }
        }

        private void AddQueryOnLose(BtNode<string> node)
        {
            Console.Write("You win! \nWhat were you thinking off: ");
            var userAnswer = TryGetInput();

            Console.Write($"Please enter a question to distinguish {node.Key} from {userAnswer}: ");
            var userQuestion = TryGetInput();

            Console.Write($"If you were thinking of {userAnswer}, what would the answer to {userQuestion} be? \n" +
                          "Yes 'y' or no 'n': ");

            if (InputHandler.CheckInput(ConsoleKey.Y))
            {
                var newNode = new BtNode<string>(userQuestion)
                {
                    Left = new BtNode<string>(node.Key),
                    Right = new BtNode<string>(userAnswer)
                };

                node = newNode;
            }

            if (InputHandler.CheckInput(ConsoleKey.N))
            {
                var newNode = new BtNode<string>(userQuestion)
                {
                    Left = new BtNode<string>(userAnswer),
                    Right = new BtNode<string>(node.Key)
                };

                node = newNode;
            }

            Console.WriteLine("Thank you! My knowledge has increased!");
        }

        private void StartCreation()
        {
            Console.WriteLine("It seems there aren't many questions to ask! Let's add some shall we... \n\n");
        }

        private BtNode<string> CreateUserQuery()
        {
            Console.Write("What should the question be: ");
            var userQuestion = TryGetInput();

            Console.Write("What should be the right ('y') answer?");
            var userAnswer = TryGetInput();

            return new BtNode<string>(userQuestion)
            {
                Left = new BtNode<string>(userAnswer)
            };
        }

        private static string TryGetInput()
        {
            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input)) return input;

            Console.WriteLine("That is not a valid input, try again!");

            return TryGetInput();
        }
    }
}