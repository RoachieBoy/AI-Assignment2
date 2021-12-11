using BinaryQuestionsV3.BinaryTree;

namespace BinaryQuestionsV3.KnowledgeGame;

/// <summary>
/// This class defines the <see cref="Game"/> behaviour.
/// </summary>
public class Game
{
    private Tree<string>? _currentGameData;

    /// <summary>
    /// Instantiates a new empty <see cref="Game"/>.
    /// </summary>
    public Game()
    {
        _currentGameData = null;
    }

    /// <summary>
    /// Instantiates a new <see cref="Game"/> with existing data (stored in a <see cref="Tree{T}"/>).
    /// </summary>
    /// <param name="gameData"> Game data <see cref="Tree{T}"/> to use when instantiating. </param>
    public Game(Tree<string> gameData)
    {
        _currentGameData = gameData;
    }

    private static Tree<string> CreateGameDataStructure()
    {
        // Start with creating a root node
        Console.WriteLine("It seems there isn't any previous data..." +
                          "\nLet's start creating some!" +
                          "\nWhat should the first question be: ");
        var firstQuestion = Input.TryGetInput();
        // Make sure to also fill the left and right child
        Console.WriteLine("What should the first (yes) possibility be: ");
        var leftNode = new Node<string>(Input.TryGetInput());

        Console.WriteLine("What should the second (no) possibility be: ");
        var rightNode = new Node<string>(Input.TryGetInput());

        var rootNode = new Node<string>(firstQuestion, leftNode, rightNode);
        // Instantiate tree with the root node
        return new Tree<string>(rootNode);
    }

    /// <summary>
    /// Starts the <see cref="Game"/>.
    /// </summary>
    public void Run()
    {
        // Check for game data
        if (_currentGameData is null)
        {
            _currentGameData = CreateGameDataStructure();

            Query(_currentGameData.Root);
        }
        else
        {
            var minMax = ExtraFunctions.MiniMaxEval(
                _currentGameData.Root, int.MaxValue, true);
            var alphaBeta = ExtraFunctions.AlphaBetaPruningEval(
                _currentGameData.Root, int.MaxValue, int.MinValue, int.MaxValue, true);
            
            Console.WriteLine($"Mini-max: {minMax} & alpha-beta: {alphaBeta}");
            
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
        // Create new nodes and fill the children to contain the possibilities
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