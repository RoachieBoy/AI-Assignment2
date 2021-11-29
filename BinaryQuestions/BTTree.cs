using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinaryQuestions
{
    [Serializable]
    internal class BtTree
    {
        private BtNode _rootNode;

        public BtTree(string question, string yesGuess, string noGuess)
        {
            _rootNode = new BtNode(question);
            _rootNode.SetYesNode(new BtNode(yesGuess));
            _rootNode.SetNoNode(new BtNode(noGuess));

            //Serialize the object on creation
            SaveQuestionTree();
        }

        public BtTree()
        {
            var formatter = new BinaryFormatter();

            using var stream = File.OpenRead("serialized.bin");

            _rootNode = (BtNode)formatter.Deserialize(stream);
        }

        public void Query()
        {
            _rootNode.Query(1);

            //We're at the end of the game now, so we'll save the tree in case the user added new data
            SaveQuestionTree();
        }

        public void SaveQuestionTree()
        {
            var formatter = new BinaryFormatter();

            using var stream = File.Create("serialized.bin");

            formatter.Serialize(stream, _rootNode);
        }
    }
}