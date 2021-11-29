﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryQuestions
{
    [Serializable] class BTNode
    {
        string message;
        BTNode noNode;
        BTNode yesNode;

        /**
         * Constructor for the nodes: This class holds an String representing 
         * an object if the noNode and yesNode are null and a question if the
         * yesNode and noNode point to a BTNode.
         */
        public BTNode(string nodeMessage)
        {
            message = nodeMessage;
            noNode = null;
            yesNode = null;
        }

        public void Query(int q)
        {
            if (q > 20)
            {
                Console.WriteLine("That was the last question. You win!");
            }
            else if (IsQuestion())
            {
                Console.WriteLine(q + ") " + message);
                Console.Write("Enter 'y' for yes and 'n' for no: ");
                var input = GetYesOrNo(); //y or n
                if (input == 'y')
                    yesNode.Query(q+1);
                else
                    noNode.Query(q+1);
            }
            else
                this.OnQueryObject(q);
        }

        public void OnQueryObject(int q)
        {
            Console.WriteLine(q + ") Are you thinking of a(n) " + message + "? ");
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
                + message + " from " + userObject + ": ");
            var userQuestion = Console.ReadLine();
            Console.Write("If you were thinking of a(n) " + userObject
                + ", what would the answer to that question be (\'yes\' or \'no\')? ");
            var input = GetYesOrNo(); //y or n
            if (input == 'y')
            {
                noNode = new BTNode(message);
                yesNode = new BTNode(userObject);
            }
            else
            {
                yesNode = new BTNode(message);
                noNode = new BTNode(userObject);
            }
            Console.Write("Thank you! My knowledge has been increased");
            SetMessage(userQuestion);
        }

        public bool IsQuestion()
        {
            if (noNode == null && yesNode == null)
                return false;
            else
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
                inputCharacter = Char.ToLower(inputCharacter);
            }
            return inputCharacter;
        }

        //Mutator Methods
        public void SetMessage(string nodeMessage)
        {
            message = nodeMessage;
        }

        public string GetMessage()
        {
            return message;
        }

        public void SetNoNode(BTNode node)
        {
            noNode = node;
        }

        public BTNode GetNoNode()
        {
            return noNode;
        }

        public void SetYesNode(BTNode node)
        {
            yesNode = node;
        }

        public BTNode GetYesNode()
        {
            return yesNode;
        }
    }
}
