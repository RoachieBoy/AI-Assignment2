using BinaryQuestionsV2.BaseEngine;
using BinaryQuestionsV2.BinaryTreeDataStructure;

namespace BinaryQuestionsV2
{
    public class Game
    {
        private BTree<string> _currentGameData;
        
        public Game(BTree<string> currentGameData)
        {
            _currentGameData = currentGameData;
        }

        /// <summary>
        /// </summary>
        public void Update()
        {
            CheckForQuit();
        }

        private void CheckForQuit()
        {
            if (InputHandler.CheckX())
            {
                Program.QuitGame(_currentGameData);
            }
        }

        private void Query()
        {
            
        }
    }
}