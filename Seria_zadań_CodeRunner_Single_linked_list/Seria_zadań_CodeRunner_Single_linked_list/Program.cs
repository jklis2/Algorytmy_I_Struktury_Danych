                    //Zadanie 1//

/*

public static void PrintSingleLinkedList<T>( Node<T> head )
{
    Console.Write("head -> ");
    while (head != null)
    {
        Console.Write(head);
        head = head.Next;
    }
    Console.Write("null");
}

*/



                    //Zadanie 2//

/*

public static void AddAtEndOfSingleLinkedList<T>(T element, ref Node<T> head)
{
    Node<T> newitem = new Node<T>(element);
    newitem.Data = element;
    if (head == null)
    {

        head = newitem;
        head.Next = null;
    }
    else
    {
        Node<T> current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newitem;
    }
}

*/



                    //Zadanie 3//

/*

public static Node<T> CreateSingleLinkedList<T>(params T[] arr)
{
    Node<T> node = null;
    if (arr != null)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            AddAtEndOfSingleLinkedList(arr[i], ref node);
        }
    }
    else
    {
        node = null;
    }

    return node;
}

public static void AddAtEndOfSingleLinkedList<T>(T element, ref Node<T> head)
{
    Node<T> newitem = new Node<T>(element);
    newitem.Data = element;
    if (head == null)
    {
        head = newitem;
        head.Next = null;
    }
    else
    {
        Node<T> current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newitem;
    }
}

*/



                    //Zadanie 4//

/*

public static Node<T> ReverseSingleLinkedList<T>(Node<T> head)
{
    Node<T> prev = null, current = head, next = null;
    while (current != null)
    {
        next = current.Next;
        current.Next = prev;
        prev = current;
        current = next;
    }
    head = prev;
    return head;
}

*/



                    //Zadanie 5//

/*

public static void MoveLastNodeToFront<T>(ref Node<T> head)
{
    if (head == null ||
                head.Next == null)
        return;

    Node<T> secLast = null;
    Node<T> last = head;

    while (last.Next != null)
    {
        secLast = last;
        last = last.Next;
    }

    secLast.Next = null;

    last.Next = head;

    head = last;
}

*/



                    //Zadanie 6//

/*

public static void RemoveNodeAt<T>(int position, ref Node<T> head)
{
    if (head == null)
        return;

    Node<T> temp = head;

    if (position == 0)
    {
        head = temp.Next;
        return;
    }

    for (int i = 0; temp != null && i < position - 1;
         i++)
        temp = temp.Next;

    if (temp == null || temp.Next == null)
        return;

    Node<T> next = temp.Next.Next;

    temp.Next = next;
}

*/



