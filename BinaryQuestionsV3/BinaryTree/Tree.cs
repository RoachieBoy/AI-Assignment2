namespace BinaryQuestionsV3.BinaryTree;

public class Tree<T>
{
    /// <summary>
    /// </summary>
    /// <param name="node"></param>
    public Tree(Node<T> node)
    {
        Root = node;
    }

    /// <summary>
    /// </summary>
    public Node<T> Root { get; }

    /// <summary>
    /// </summary>
    public IEnumerable<Node<T>> PreOrderedNodesList => GetNodesInPreOrder(Root);

    /// <summary>
    /// </summary>
    public IEnumerable<Node<T>> PostOrderedNodesList => GetNodesInPostOrder(Root);

    /// <summary>
    /// </summary>
    public IEnumerable<Node<T>> OrderedNodesList => GetNodesInOrder(Root);

    private static IEnumerable<Node<T>> GetNodesInPreOrder(Node<T>? node)
    {
        if (node is null) return new List<Node<T>>();

        var output = new List<Node<T>> { node };

        output.AddRange(GetNodesInPreOrder(node.Left));
        output.AddRange(GetNodesInPreOrder(node.Right));

        return output;
    }

    private static IEnumerable<Node<T>> GetNodesInPostOrder(Node<T>? node)
    {
        if (node is null) return new List<Node<T>>();

        var output = new List<Node<T>>();

        output.AddRange(GetNodesInPostOrder(node.Left));
        output.AddRange(GetNodesInPostOrder(node.Right));

        output.Add(node);

        return output;
    }

    private static IEnumerable<Node<T>> GetNodesInOrder(Node<T>? node)
    {
        if (node is null) return new List<Node<T>>();

        var output = new List<Node<T>>();

        output.AddRange(GetNodesInOrder(node.Left));

        output.Add(node);

        output.AddRange(GetNodesInOrder(node.Right));

        return output;
    }
}