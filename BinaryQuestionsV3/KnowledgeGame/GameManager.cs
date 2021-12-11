using BinaryQuestionsV3.BinaryTree;

namespace BinaryQuestionsV3.KnowledgeGame;

/// <summary>
///     This class manages the <see cref="Game" />'s state.
/// </summary>
public static class GameManager
{
    /// <summary>
    ///     Restarts the active <see cref="Game" />.
    /// </summary>
    /// <param name="currentGame"> The current game. </param>
    /// <param name="currentGameData"> The current game's <see cref="Tree{T}" /> data. </param>
    public static void PlayAgain(Game currentGame, Tree<string> currentGameData)
    {
        SaveManager.SaveData(currentGameData);

        currentGame.Run();
    }

    /// <summary>
    ///     Tries to instantiate a <see cref="Game" /> with existing <see cref="Tree{T}" /> game data.
    /// </summary>
    /// <returns> Returns a <see cref="Game" /> instance. </returns>
    public static Game TryLoadGame()
    {
        return SaveManager.LoadData(out var gameData) ? new Game(gameData!) : new Game();
    }

    /// <summary>
    ///     Saves and terminates the current <see cref="Game" />.
    /// </summary>
    /// <param name="currentGameData"> <see cref="Tree{T}" /> which holds the current <see cref="Game" />'s data. </param>
    public static void QuitGame(Tree<string> currentGameData)
    {
        Console.WriteLine("Saving game...");

        SaveManager.SaveData(currentGameData);

        TerminateGame();
    }

    /// <summary>
    ///     Terminates the current <see cref="Game" />.
    /// </summary>
    public static void TerminateGame()
    {
        Console.WriteLine("Exiting game...");

        Environment.Exit(0);
    }
}