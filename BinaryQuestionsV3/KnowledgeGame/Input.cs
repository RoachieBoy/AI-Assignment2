namespace BinaryQuestionsV3.KnowledgeGame;

/// <summary>
/// </summary>
public static class Input
{
    public static bool CheckYesOrNo()
    {
        Console.WriteLine("Yes 'y' or no 'n'... (stop playing 'x') \n");
        var input = TryGetInput();

        while (true)
        {
            if (InputCheckY(input)) return true;

            if (InputCheckN(input)) return false;

            if (InputCheckX(input))
            {
                GameManager.TerminateGame();
            }
        }
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    private static bool InputCheckY(string input)
    {
        return input == "y";
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    private static bool InputCheckN(string input)
    {
        return input == "n";
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    private static bool InputCheckX(string input)
    {
        return input == "x";
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public static string TryGetInput()
    {
        var input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input)) return input;

        Console.WriteLine("That's not a valid input!\n");

        return TryGetInput();
    }
}