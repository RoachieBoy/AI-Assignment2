namespace BinaryQuestionsV3.BinaryTree;

public class Node<T>
{
    public Node(T data, Node<T>? left, Node<T>? right)
    {
        Data = data;
        Left = left;
        Right = right;
    }

    public T Data { get; set; }

    public Node<T>? Left { get; set; }

    public Node<T>? Right { get; set; }
}