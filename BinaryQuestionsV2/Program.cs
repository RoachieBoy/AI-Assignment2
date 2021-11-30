global using System;
global using System.IO;
using BinaryQuestionsV2.BaseEngine;
using BinaryQuestionsV2.BinaryTreeDataStructure;

namespace BinaryQuestionsV2
{
    internal static class Program
    {
        private const string FileName = "gameData.json";

        private static bool _isRunning;

        private static void Main()
        {
            var game = StartGame();

            while (_isRunning)
            {
                game.Update();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentGameData"></param>
        public static void QuitGame(BTree<string> currentGameData)
        {
            _isRunning = false;

            SaveManager.SaveGame(currentGameData, FileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Game StartGame()
        {
            _isRunning = true;
            
            return new Game(TryLoadGame());
        }

        private static BTree<string> TryLoadGame()
        {
            return File.Exists(FileName) ? SaveManager.LoadGame(FileName) : SaveManager.StartNewGame();
        }
    }
}