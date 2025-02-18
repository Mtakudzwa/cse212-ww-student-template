public class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int newValue)
    {
        if (newValue == Value)
            return; // Ignore duplicate values

        if (newValue < Value)
        {
            if (Left == null)
                Left = new Node(newValue);
            else
                Left.Insert(newValue);
        }
        else
        {
            if (Right == null)
                Right = new Node(newValue);
            else
                Right.Insert(newValue);
        }
    }

    // Problem 2: Contains
    public bool Contains(int searchValue)
    {
        if (searchValue == Value)
            return true;
        if (searchValue < Value)
            return Left != null && Left.Contains(searchValue);
        return Right != null && Right.Contains(searchValue);
    }

    // Problem 4: Tree Height
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}

public class BinarySearchTree
{
    public Node Root;

    public void Insert(int value)
    {
        if (Root == null)
            Root = new Node(value);
        else
            Root.Insert(value);
    }

    public bool Contains(int value)
    {
        return Root != null && Root.Contains(value);
    }

    public int GetHeight()
    {
        return Root?.GetHeight() ?? 0;
    }

    // Problem 3: Traverse Backwards
    public IEnumerable<int> TraverseBackward()
    {
        return TraverseBackwardHelper(Root);
    }

    private IEnumerable<int> TraverseBackwardHelper(Node node)
    {
        if (node == null)
            yield break;

        foreach (var val in TraverseBackwardHelper(node.Right))
            yield return val;

        yield return node.Value;

        foreach (var val in TraverseBackwardHelper(node.Left))
            yield return val;
    }
}

public static class Trees
{
    // Problem 5: Create Tree from Sorted List
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return;

        int mid = (first + last) / 2;
        bst.Insert(sortedNumbers[mid]);
        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
