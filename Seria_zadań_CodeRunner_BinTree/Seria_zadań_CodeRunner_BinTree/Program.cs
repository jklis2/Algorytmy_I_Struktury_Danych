                //Zadanie 1//

/*

public static BinTreeNode<char> CreateTreeOfChars()
{
    BinTreeNode<char> I = new BinTreeNode<char>('I', null, null);
    BinTreeNode<char> H = new BinTreeNode<char>('H', null, null);
    BinTreeNode<char> F = new BinTreeNode<char>('F', H, I);
    BinTreeNode<char> G = new BinTreeNode<char>('G', null, null);
    BinTreeNode<char> E = new BinTreeNode<char>('E', null, null);
    BinTreeNode<char> D = new BinTreeNode<char>('D', null, null);
    BinTreeNode<char> B = new BinTreeNode<char>('B', D, E);
    BinTreeNode<char> C = new BinTreeNode<char>('C', F, G);
    BinTreeNode<char> A = new BinTreeNode<char>('A', B, C);

    return A;
}

*/



                //Zadanie 2//

/*

public static void PrintTree<T>(BinTreeNode<T> p, int level = 0)
{
    if (p == null) return;
    Console.WriteLine("".PadLeft(level, '.') + p.Value);
    PrintTree(p.Left, level + 1);
    PrintTree(p.Right, level + 1);
}

*/



                //Zadanie 3//

/*

public static int NoOfNodes<T>(BinTreeNode<T> tree)
{
    if (tree == null) return 0;
    return 1 + NoOfNodes(tree.Left) + NoOfNodes(tree.Right);
}

*/



                //Zadanie 4//

/*

public static int Depth<T>(BinTreeNode<T> tree)
{
    if (tree == null) return 0;
    return 1 + Math.Max(Depth(tree.Left), Depth(tree.Right));
}

*/



                //Zadanie 5//

/*

public static void DoMirrorOfTree<T>(BinTreeNode<T> tree)
{
    if (tree == null) return;
    DoMirrorOfTree(tree.Left);
    DoMirrorOfTree(tree.Right);
    var schowek = tree.Left;
    tree.Left = tree.Right;
    tree.Right = schowek;
}

*/



                //Zadanie 6//

/*

public static List<T> GetTraversePreorder<T>(BinTreeNode<T> tree)
{
    List<T> listawynik = new List<T>();
    TraversePreOrder(tree, listawynik.Add);
    return listawynik;
}

*/