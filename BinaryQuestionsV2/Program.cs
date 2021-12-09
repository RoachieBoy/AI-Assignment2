global using System;
global using System.IO;
using BinaryQuestionsV2.BaseEngine;
using BinaryQuestionsV2.BinaryTreeDataStructure;

namespace BinaryQuestionsV2;

internal static class Program
{
    private const string FileName = "gameData.json";

    private static void Main()
    {
        var game = StartGame();
            
        game.Update();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentGameData"></param>
    public static void QuitGame(BTree<string> currentGameData)
    {
        SaveManager.SaveGame(currentGameData, FileName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Game StartGame()
    {
        return new Game(TryLoadGame());
    }

    private static BTree<string> TryLoadGame()
    {
        return File.Exists(FileName) ? SaveManager.LoadGame(FileName) : SaveManager.StartNewGame();
    }
}