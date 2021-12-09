using BinaryQuestionsV2.BaseEngine;
using BinaryQuestionsV2.BinaryTreeDataStructure;

namespace BinaryQuestionsV2;

public class Game
{
    private readonly BTree<string> _currentGameData;

    public Game(BTree<string> currentGameData)
    {
        _currentGameData = currentGameData;
    }

    /// <summary>
    /// </summary>
    public void Run()
    {
        CreateOnStart();

        RunQuery(_currentGameData.Root);
    }

    private void CreateOnStart()
    {
        if (_currentGameData.Count != 0) return;

        Console.WriteLine("There seems to be no data! \nLet us populate it... \n" +
                          "What should the first yes or no question be: ");

        var userQuestion = InputHandler.InputChecker();

        Console.WriteLine("What should the follow-up question for no be: ");

        var userQuestionNo = InputHandler.InputChecker();

        Console.WriteLine("What should the follow-up question for yes be: ");

        var userQuestionYes = InputHandler.InputChecker();

        _currentGameData.Add(userQuestion);
        _currentGameData.Add(userQuestionNo);
        _currentGameData.Add(userQuestionYes);
    }

    private void RunQuery(BtNode<string>? node)
    {
        if (node is null)
        {
            Console.WriteLine("Yeet");
        }
        else
        {
            Console.WriteLine(node.Key + "\n\n Yes 'y' or no 'n': ");

            if (node.Left is not null && node.Right is not null)
            {
                if (InputHandler.CheckInput(ConsoleKey.Y)) RunQuery(node.Right!);

                if (InputHandler.CheckInput(ConsoleKey.N)) RunQuery(node.Left!);
            }
            else
            {
                if (InputHandler.CheckInput(ConsoleKey.Y)) Console.WriteLine("I win!");

                if (InputHandler.CheckInput(ConsoleKey.N)) Console.WriteLine("You win!");
            }
        }
    }
}