using System;
using System.Linq;

namespace BinaryQuestions
{
    [Serializable]
    public class BtNode
    {
        private string _message;
        private BtNode _noNode;
        private BtNode _yesNode;

        /**
         * Constructor for the nodes: This class holds an String representing 
         * an object if the noNode and yesNode are null and a question if the
         * yesNode and noNode point to a BTNode.
         */
        public BtNode(string nodeMessage)
        {
            _message = nodeMessage;
            _noNode = null;
            _yesNode = null;
        }

        public void Query(int q)
        {
            if (q > 20)
            {
                Console.WriteLine("That was the last question. You win!");
            }
            else if (IsQuestion())
            {
                Console.WriteLine(q + ") " + _message);
                Console.Write("Enter 'y' for yes and 'n' for no: ");
                var input = GetYesOrNo(); //y or n
                if (input == 'y')
                    _yesNode.Query(q + 1);
                else
                    _noNode.Query(q + 1);
            }
            else
            {
                OnQueryObject(q);
            }
        }

        public void OnQueryObject(int q)
        {
            Console.WriteLine(q + ") Are you thinking of a(n) " + _message + "? ");
            Console.Write("Enter 'y' for yes and 'n' for no: ");
            var input = GetYesOrNo(); //y or n
            if (input == 'y')
                Console.Write("I Win!\n");
            else
                UpdateTree();
        }

        private void UpdateTree()
        {
            Console.Write("You win! What were you thinking of? ");
            var userObject = Console.ReadLine();
            Console.Write("Please enter a question to distinguish a(n) "
                          + _message + " from " + userObject + ": ");
            var userQuestion = Console.ReadLine();
            Console.Write("If you were thinking of a(n) " + userObject
                                                          + ", what would the answer to that question be (\'yes\' or \'no\')? ");
            var input = GetYesOrNo(); //y or n
            if (input == 'y')
            {
                _noNode = new BtNode(_message);
                _yesNode = new BtNode(userObject);
            }
            else
            {
                _yesNode = new BtNode(_message);
                _noNode = new BtNode(userObject);
            }

            Console.Write("Thank you! My knowledge has been increased");
            SetMessage(userQuestion);
        }

        public bool IsQuestion()
        {
            if (_noNode == null && _yesNode == null)
                return false;
            return true;
        }

        /**
         * Asks a user for yes or no and keeps prompting them until the key
         * Y,y,N,or n is entered
         */
        private char GetYesOrNo()
        {
            var inputCharacter = ' ';
            while (inputCharacter != 'y' && inputCharacter != 'n')
            {
                inputCharacter = Console.ReadLine().ElementAt(0);
                inputCharacter = char.ToLower(inputCharacter);
            }

            return inputCharacter;
        }

        //Mutator Methods
        public void SetMessage(string nodeMessage)
        {
            _message = nodeMessage;
        }

        public string GetMessage()
        {
            return _message;
        }

        public void SetNoNode(BtNode node)
        {
            _noNode = node;
        }

        public BtNode GetNoNode()
        {
            return _noNode;
        }

        public void SetYesNode(BtNode node)
        {
            _yesNode = node;
        }

        public BtNode GetYesNode()
        {
            return _yesNode;
        }
    }
}