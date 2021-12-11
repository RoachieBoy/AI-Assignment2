namespace BinaryQuestionsV3.BinaryTree;

/// <summary>
///     This class defines a binary <see cref="Node{T}" /> used for our game data structure <see cref="Tree{T}" />.
/// </summary>
/// <typeparam name="T"> The datatype the node needs to hold. </typeparam>
public class Node<T>
{
    /// <summary>
    ///     Instantiates a <see cref="Node{T}" /> with two edges, left and right.
    /// </summary>
    /// <param name="data"> What data the node needs to store. </param>
    /// <param name="left"> Left edge child, defaults to null. </param>
    /// <param name="right"> Right edge child, defaults to null. </param>
    public Node(T data, Node<T>? left = null, Node<T>? right = null)
    {
        Data = data;
        Left = left;
        Right = right;
    }

    /// <summary>
    ///     Data of type <see cref="T" /> contained in the <see cref="Node{T}" />.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    ///     The child <see cref="Node{T}" /> which the left edge leads to.
    /// </summary>
    public Node<T>? Left { get; set; }

    /// <summary>
    ///     The child <see cref="Node{T}" /> which the right edge leads to.
    /// </summary>
    public Node<T>? Right { get; set; }
}