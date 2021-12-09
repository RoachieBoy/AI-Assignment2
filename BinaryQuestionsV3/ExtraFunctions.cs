using BinaryQuestionsV3.BinaryTree;

namespace BinaryQuestionsV3;

/// <summary>
/// </summary>
public static class ExtraFunctions
{
    /// <summary>
    /// </summary>
    /// <param name="node"></param>
    /// <param name="depth"></param>
    /// <param name="maxPlayer"></param>
    /// <returns></returns>
    public static int MiniMaxEval(Node<string>? node, int depth, bool maxPlayer)
    {
        if (node is null) return 0;

        if (depth == 0 || node.Left is null && node.Right is null) return node.Data.Length;

        switch (maxPlayer)
        {
            case true:
            {
                var left = MiniMaxEval(node.Left, depth - 1, false);
                var right = MiniMaxEval(node.Right, depth - 1, false);

                return left > right ? left : right;
            }
            case false:
            {
                var left = MiniMaxEval(node.Left, depth - 1, true);
                var right = MiniMaxEval(node.Right, depth - 1, true);

                return left < right ? left : right;
            }
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="node"></param>
    /// <param name="depth"></param>
    /// <param name="alpha"></param>
    /// <param name="beta"></param>
    /// <param name="maxPlayer"></param>
    /// <returns></returns>
    public static int AlphaBetaPruningEval(Node<string>? node, int depth, int alpha, int beta, bool maxPlayer)
    {
        var output = 0;

        if (node is null) return output;

        if (depth == 0 || node.Left is null && node.Right is null) return node.Data.Length;

        switch (maxPlayer)
        {
            case true:
            {
                var left = AlphaBetaPruningEval(node.Left, depth - 1, alpha, beta, false);

                alpha = left > alpha ? left : alpha;

                if (left >= beta) break;

                var right = AlphaBetaPruningEval(node.Left, depth - 1, alpha, beta, false);

                output = left > right ? left : right;

                if (output >= beta) break;

                return output;
            }
            case false:
            {
                var left = AlphaBetaPruningEval(node.Left, depth - 1, alpha, beta, true);

                beta = left < beta ? left : beta;

                if (left <= alpha) break;

                var right = AlphaBetaPruningEval(node.Left, depth - 1, alpha, beta, true);

                output = left < right ? left : right;

                if (output <= alpha) break;

                return output;
            }
        }

        return 0;
    }
}