namespace BinaryQuestionsV3.BinaryTree;

public class Node<T>
{
    public Node(T data, Node<T>? left = null, Node<T>? right = null)
    {
        Data = data;
        Left = left;
        Right = right;
    }

    public T Data { get; set; }

    public Node<T>? Left { get; set; }

    public Node<T>? Right { get; set; }
}