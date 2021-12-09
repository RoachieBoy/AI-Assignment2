namespace BinaryQuestionsV2.BaseEngine;

public static class InputHandler
{
    public static bool CheckInput(ConsoleKey keyToCheck)
    {
        var input = Console.ReadKey();

        return input.Key == keyToCheck;
    }

    public static string InputChecker()
    {
        var input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            return input;
        }

        Console.WriteLine("That is not a valid input, try again!");

        return InputChecker();
    }
}