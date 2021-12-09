using System.Runtime.Serialization.Formatters.Binary;

namespace BinaryQuestions;

[Serializable]
internal class BtTree
{
    public BtTree(string? question, string? yesGuess, string? noGuess)
    {
        GetRootNode = new BtNode(question);
        GetRootNode.SetYesNode(new BtNode(yesGuess));
        GetRootNode.SetNoNode(new BtNode(noGuess));

        //Serialize the object on creation
        SaveQuestionTree();
    }

    public BtTree()
    {
        var formatter = new BinaryFormatter();

        using var stream = File.OpenRead("serialized.bin");

        GetRootNode = (BtNode)formatter.Deserialize(stream);
    }

    public BtNode? GetRootNode { get; }

    public void Query()
    {
        GetRootNode.Query(1);

        //We're at the end of the game now, so we'll save the tree in case the user added new data
        SaveQuestionTree();
    }

    public void SaveQuestionTree()
    {
        var formatter = new BinaryFormatter();

        using var stream = File.Create("serialized.bin");

        formatter.Serialize(stream, GetRootNode);
    }
}