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
    
    private Tree<string>? CreateNewGame()
    {
        // Write new game logic, so ask questions to compile root node

        return null;
    }
    
    public void Run()
    {
        if (_currentGameData is null)
        {
            _currentGameData = CreateNewGame();
        }
        
        // Write game logic once the game is running
    }

    private void Query()
    {
        // Ask questions
    }
}