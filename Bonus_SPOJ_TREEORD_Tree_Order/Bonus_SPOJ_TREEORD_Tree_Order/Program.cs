using System;

public class Node
{
    public int data;
    public Node left, right;

    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

class GFG
{
    public Node root;
    public static int preIndex = 0;

    public virtual Node buildTree(int[] arr, int[] pre,
                                int inStrt, int inEnd)
    {
        if (inStrt > inEnd)
        {
            return null;
        }

        Node tNode = new Node(pre[preIndex++]);

        if (inStrt == inEnd)
        {
            return tNode;
        }

        int inIndex = search(arr, inStrt,
                            inEnd, tNode.data);

        tNode.left = buildTree(arr, pre, inStrt, inIndex - 1);
        tNode.right = buildTree(arr, pre, inIndex + 1, inEnd);

        return tNode;
    }

    public virtual int search(int[] arr, int strt,
                            int end, int value)
    {
        int i;
        for (i = strt; i <= end; i++)
        {
            if (arr[i] == value)
            {
                return i;
            }
        }
        return i;
    }

    public virtual void printInorder(Node node)
    {
        if (node == null)
        {
            return;
        }

        printInorder(node.left);

        Console.Write(node.data + " ");

        printInorder(node.right);
    }

    public static string preOutput = "";
    public static string postOutput = "";
    public static string inOutput = "";

    public void TraversePreOrder(Node parent)
    {
        if (parent != null)
        {
            preOutput += parent.data + " ";
            TraversePreOrder(parent.left);
            TraversePreOrder(parent.right);
        }
    }

    public void TraverseInOrder(Node parent)
    {
        if (parent != null)
        {
            TraverseInOrder(parent.left);
            inOutput += parent.data + " ";
            TraverseInOrder(parent.right);
        }
    }

    public void TraversePostOrder(Node parent)
    {
        if (parent != null)
        {
            TraversePostOrder(parent.left);
            TraversePostOrder(parent.right);
            postOutput += parent.data + " ";
        }
    }

    public static void Main(string[] args)
    {
        GFG tree = new GFG();
        int len = int.Parse(Console.ReadLine());
        int[] preOrder = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        string postOrder = Console.ReadLine();
        int[] inOrder = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        Node root = tree.buildTree(inOrder, preOrder, 0, len - 1);

        string x = "";

        tree.TraversePreOrder(root);

        tree.TraverseInOrder(root);

        tree.TraversePostOrder(root);

        foreach (var item in preOrder)
        {
            x += item.ToString() + " ";
        }

        if (postOrder == postOutput.Trim() && x == preOutput) Console.WriteLine("yes");
        else Console.WriteLine("no");
    }
}