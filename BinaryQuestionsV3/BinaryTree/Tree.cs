using System.Text.Json.Serialization;

namespace BinaryQuestionsV3.BinaryTree;

/// <summary>
/// This class defines a binary <see cref="Tree{T}"/> used as our game's data structure.
/// </summary>
/// <typeparam name="T"> What datatype the tree needs to hold. </typeparam>
public class Tree<T>
{
    /// <summary>
    /// Instantiates a <see cref="Tree{T}"/> of datatype <see cref="T"/>.
    /// </summary>
    /// <param name="root"></param>
    public Tree(Node<T> root)
    {
        Root = root;
    }

    /// <summary>
    /// The <see cref="Node{T}"/> at depth zero, the root.
    /// </summary>
    [JsonInclude]
    public Node<T> Root { get; init; }

    /// <summary>
    /// The <see cref="Tree{T}"/> in a pre-ordered <see cref="IEnumerable{T}"/> list of <see cref="Node{T}"/>'s.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<Node<T>> PreOrderedNodesList => GetNodesInPreOrder(Root);

    /// <summary>
    /// The <see cref="Tree{T}"/> in a post-ordered <see cref="IEnumerable{T}"/> list of <see cref="Node{T}"/>'s.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<Node<T>> PostOrderedNodesList => GetNodesInPostOrder(Root);

    /// <summary>
    /// The <see cref="Tree{T}"/> in a ordered <see cref="IEnumerable{T}"/> list of <see cref="Node{T}"/>'s.
    /// </summary>
    [JsonIgnore]
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