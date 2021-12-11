namespace BinaryQuestionsV3.KnowledgeGame;

/// <summary>
///     This class handles all input.
/// </summary>
public static class Input
{
    /// <summary>
    ///     Checks the input for being a yes, no or to terminate
    /// </summary>
    /// <returns> Returns true when reading 'y' and false when reading 'n'. </returns>
    public static bool CheckYesOrNo()
    {
        Console.WriteLine("Yes 'y' or no 'n'... (stop playing 'x') \n");
        var input = TryGetInput();

        while (true)
        {
            if (InputCheckY(input)) return true;

            if (InputCheckN(input)) return false;

            if (InputCheckX(input)) GameManager.TerminateGame();
        }
    }

    private static bool InputCheckY(string input)
    {
        return input == "y";
    }

    private static bool InputCheckN(string input)
    {
        return input == "n";
    }

    private static bool InputCheckX(string input)
    {
        return input == "x";
    }

    /// <summary>
    ///     Tries to get a valid input until.
    /// </summary>
    /// <returns> Returns the console input as a string, cannot be empty or null. </returns>
    public static string TryGetInput()
    {
        var input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input)) return input;

        Console.WriteLine("That's not a valid input!\n");

        return TryGetInput();
    }
}