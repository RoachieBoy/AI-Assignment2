using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinaryQuestions
{
    [Serializable] class BTTree
    {
        BTNode rootNode;

        public BTTree(string question, string yesGuess, string noGuess)
        {
            rootNode = new BTNode(question);
            rootNode.SetYesNode(new BTNode(yesGuess));
            rootNode.SetNoNode(new BTNode(noGuess));

            //Serialize the object on creation
            SaveQuestionTree();
        }

        public BTTree()
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.OpenRead("serialized.bin"))
            {
                rootNode = (BTNode)formatter.Deserialize(stream);
            }
        }

        public void Query()
        {
            rootNode.Query(1);

            //We're at the end of the game now, so we'll save the tree in case the user added new data
            SaveQuestionTree();
        }

        public void SaveQuestionTree()
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create("serialized.bin"))
            {
                formatter.Serialize(stream, rootNode);
            }
        }
    }
}
