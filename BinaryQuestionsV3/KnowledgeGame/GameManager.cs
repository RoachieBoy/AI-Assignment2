using BinaryQuestionsV3.BinaryTree;

namespace BinaryQuestionsV3.KnowledgeGame;

/// <summary>
/// </summary>
public static class GameManager
{
    /// <summary>
    /// </summary>
    /// <param name="currentGame"></param>
    /// <param name="currentGameData"></param>
    public static void PlayAgain(Game currentGame, Tree<string> currentGameData)
    {
        SaveManager.SaveData(currentGameData);

        currentGame.Run();
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static Game TryLoadGame()
    {
        return SaveManager.LoadData(out var gameData) ? new Game(gameData!) : new Game();
    }

    /// <summary>
    /// </summary>
    public static void QuitGame(Tree<string> currentGameData)
    {
        Console.WriteLine("Saving game...");
        
        SaveManager.SaveData(currentGameData);
        
        TerminateGame();
    }

    public static void TerminateGame()
    {
        Console.WriteLine("Exiting game...");
        
        Environment.Exit(0);
    }
}