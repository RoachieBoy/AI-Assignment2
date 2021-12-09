namespace BinaryQuestionsV2.BaseEngine;

public static class InputHandler
{
    public static bool CheckInput(ConsoleKey keyToCheck)
    {
        var input = Console.ReadKey();

        return input.Key == keyToCheck;
    }
}