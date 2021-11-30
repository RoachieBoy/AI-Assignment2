using System.IO;

namespace BinaryQuestionsV2
{
    internal static class Program
    {
        private const string FileName = "gameData.json";

        public static bool IsRunning;

        private static BTree<string>? _currentGameData;

        private static void Main()
        {
            if (File.Exists(FileName))
            {
                _currentGameData = SaveManager.LoadGame(FileName);

                IsRunning = true;
            }
            else
            {
                _currentGameData = SaveManager.StartNewGame();

                IsRunning = true;
            }

            var game = new Game {CurrentGameData = _currentGameData};

            while (IsRunning) game.Update();
        }
    }
}