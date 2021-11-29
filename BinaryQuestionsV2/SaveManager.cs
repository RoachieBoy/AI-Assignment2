using System;
using System.IO;
using System.Text.Json;

namespace BinaryQuestionsV2
{
    public static class SaveManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static BTree<string> StartNewGame()
        {
            Console.WriteLine("Welcome to [game title]!\n");
            
            return new BTree<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static BTree<string> LoadGame(string fileName)
        {
            Console.WriteLine("Attempting to load game data...");
            
            var jsonString = File.ReadAllText(fileName);

            try
            {
                var gameData = 
                    JsonSerializer.Deserialize<BTree<string>>(jsonString) ?? throw new InvalidOperationException();
                
                Console.WriteLine("Successfully loaded game data!\nStarting game...");
                
                return gameData;
            }
            catch (Exception e)
            {
                Console.WriteLine("The game data seems to be corrupted...\n\nCreating new game...");
            }

            return StartNewGame();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameData"></param>
        /// <param name="fileName"></param>
        /// <param name="formatted"></param>
        public static void SaveGame(BTree<string> gameData, string fileName, bool formatted = true)
        {
            var options = new JsonSerializerOptions { WriteIndented = formatted };

            var jsonString = JsonSerializer.Serialize(gameData, options);

            File.WriteAllText(fileName, jsonString);
        }
    }
}