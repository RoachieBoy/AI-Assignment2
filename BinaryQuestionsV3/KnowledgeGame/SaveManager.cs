using System.Text.Json;
using BinaryQuestionsV3.BinaryTree;

namespace BinaryQuestionsV3.KnowledgeGame;

/// <summary>
/// </summary>
public static class SaveManager
{
    private const string FileName = "gameData.json";

    /// <summary>
    /// </summary>
    /// <param name="gameData"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static bool LoadData(out Tree<string>? gameData)
    {
        Console.WriteLine("Attempting to load existing game data...");

        try
        {
            var jsonString = File.ReadAllText(FileName);

            gameData = JsonSerializer.Deserialize<Tree<string>>(jsonString) ??
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
    /// </summary>
    /// <param name="gameData"></param>
    public static void SaveData(Tree<string> gameData)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        var jsonString = JsonSerializer.Serialize(gameData, options);

        File.WriteAllText(FileName, jsonString);
    }
}