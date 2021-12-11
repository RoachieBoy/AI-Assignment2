using System.Text.Json;
using BinaryQuestionsV3.BinaryTree;

namespace BinaryQuestionsV3.KnowledgeGame;

/// <summary>
/// This class manages the saving and loading of game data <see cref="Tree{T}"/>'s.
/// </summary>
public static class SaveManager
{
    private const string FileName = "gameData.json";

    /// <summary>
    /// Tries to load the game data <see cref="Tree{T}"/>.
    /// </summary>
    /// <param name="gameData"> The game data <see cref="Tree{T}"/> to fill. </param>
    /// <returns> Returns true when it can load the data, false otherwise. </returns>
    /// <exception cref="InvalidOperationException">
    /// The exception containing what part of the loading failed.
    /// </exception>
    public static bool LoadData(out Tree<string>? gameData)
    {
        Console.WriteLine("Attempting to load existing game data...");

        try
        {
            var options = new JsonSerializerOptions { IncludeFields = true };
            var jsonString = File.ReadAllText(FileName);

            gameData = JsonSerializer.Deserialize<Tree<string>>(jsonString, options) ??
                       throw new InvalidOperationException();

            Console.WriteLine("Successfully loaded game data!\nStarting game...");

            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("The game data seems to be missing or corrupted...\n\nCreating new game...");

            gameData = null;
            return false;
        }
    }

    /// <summary>
    /// Saves the given game data <see cref="Tree{T}"/> to a json.
    /// </summary>
    /// <param name="gameData"> The game data <see cref="Tree{T}"/> to serialize. </param>
    public static void SaveData(Tree<string> gameData)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };

        var jsonString = JsonSerializer.Serialize(gameData, options);

        File.WriteAllText(FileName, jsonString);
    }
}