using BinaryQuestionsV3.BinaryTree;

namespace BinaryQuestionsV3.KnowledgeGame;

/// <summary>
/// </summary>
public class Game
{
    private Tree<string>? _currentGameData;

    /// <summary>
    /// </summary>
    public Game()
    {
        _currentGameData = null;
    }

    /// <summary>
    /// </summary>
    /// <param name="currentGameData"></param>
    public Game(Tree<string> currentGameData)
    {
        _currentGameData = currentGameData;
    }

    private static Tree<string> CreateNewGame()
    {
        Console.WriteLine("It seems there isn't any previous data..." +
                          "\nLet's start creating some!" +
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
        // Check for game data
        if (_currentGameData is null)
        {
            _currentGameData = CreateNewGame();

            Query(_currentGameData.Root);
        }
        else
        {
            Query(_currentGameData.Root);
        }
    }

    private void Query(Node<string> node, int number = 1)
    {
        Console.WriteLine($"Question {number}: {node.Data} \nPlease answer with 'y' yes or 'n' no!");
        // Check whether the node is a leaf node or not
        if (node.Left is not null && node.Right is not null)
        {
            if (Input.CheckYesOrNo())
                Query(node.Left, number + 1);
            else
                Query(node.Right, number + 1);
        }
        else if (node.Left is null && node.Right is null)
        {
            // Leaf node endgame sequence
            if (Input.CheckYesOrNo())
            {
                Console.WriteLine("I win!");

                PlayAgain();
            }
            else
            {
                Console.WriteLine("You win!");
                // Request rebase knowledge database
                AddKnowledgeOnLoss(node);
            }
        }
    }

    private void AddKnowledgeOnLoss(Node<string> node)
    {
        Console.WriteLine("What should the question to specify for a different answer be: ");
        var specifyMeDaddy = Input.TryGetInput();
        // Data switch a roo to replace old question with the new specifying one
        var firstPossibility = node.Data;
        node.Data = specifyMeDaddy;

        Console.WriteLine("What should the second (no) possibility be: ");
        var secondPossibility = Input.TryGetInput();
        // Create new nodes to contain the possibilities
        node.Left = new Node<string>(firstPossibility);
        node.Right = new Node<string>(secondPossibility);

        Console.WriteLine($"Question: {node.Data} " +
                          $"\nAnswer one: {node.Left.Data} " +
                          $"\nAnswer two: {node.Right.Data}" +
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