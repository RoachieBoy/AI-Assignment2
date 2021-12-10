using BinaryQuestionsV3.BinaryTree;

namespace BinaryQuestionsV3.KnowledgeGame;

public class Game
{
    private Tree<string>? _currentGameData;

    public Game()
    {
        _currentGameData = null;
    }

    public Game(Tree<string> currentGameData)
    {
        _currentGameData = currentGameData;
    }

    private static Tree<string> CreateNewGame()
    {
        Console.WriteLine("It seems there isn't any previous data...\nLet's start creating some!" +
                          "\nWhat should the first question be: ");

        var firstQuestion = Input.TryGetInput();

        Console.WriteLine("What should the first (yes) possibility be: ");

        var leftNode = new Node<string>(Input.TryGetInput());

        Console.WriteLine("What should the second (no) possibility be: ");

        var rightNode = new Node<string>(Input.TryGetInput());

        var rootNode = new Node<string>(firstQuestion, leftNode, rightNode);

        var tree = new Tree<string>(rootNode);

        return tree;
    }

    public void Run()
    {
        if (_currentGameData is null)
        {
            _currentGameData = CreateNewGame();

            Query(_currentGameData.Root);
        }
        else
        {
            // Write game logic once the game is running
            Query(_currentGameData.Root);
        }
    }

    private void Query(Node<string> node, int number = 1)
    {
        Console.WriteLine($"Question {number}: {node.Data} \nPlease answer with 'y' yes or 'n' no!");

        if (node.Left is not null && node.Right is not null)
        {
            if (Input.CheckYesOrNo())
                Query(node.Left, number + 1);
            else
                Query(node.Right, number + 1);
        }
        else if (node.Left is null && node.Right is null)
        {
            if (Input.CheckYesOrNo())
            {
                Console.WriteLine("I win!");

                PlayAgain();
            }
            else
            {
                Console.WriteLine("You win!");

                AddKnowledgeOnLoss(node);
            }
        }
    }

    private void AddKnowledgeOnLoss(Node<string> node)
    {
        Console.WriteLine("What should the question to specify be: ");
        var specifyMeDaddy = Input.TryGetInput();

        var oldQuestion = node.Data;
        node.Data = specifyMeDaddy;

        Console.WriteLine("What should the second (no) possibility be: ");
        var secondPossibility = Input.TryGetInput();

        node.Left = new Node<string>(oldQuestion);
        node.Right = new Node<string>(secondPossibility);

        Console.WriteLine($"Question: {node.Data} \nAnswer one: {node.Left.Data} \nAnswer two: {node.Right.Data}" +
                          "\nThank you for your addition!");

        PlayAgain();
    }

    private void PlayAgain()
    {
        Console.WriteLine("Do you want to play again?");

        if (Input.CheckYesOrNo())
            GameManager.PlayAgain(this, _currentGameData!);
        else
            GameManager.QuitGame(_currentGameData!);
    }
}