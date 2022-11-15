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



                    //Zadanie 7//

/*

public static void RemoveAllDuplicatesFromSortedLinkedList<T>(ref Node<T> head)
    where T : IEquatable<T>, IComparable<T>
{
    if (head != null)
    {
        Node<T> dummy = new Node<T>(head.Data);

        dummy.Next = head;
        Node<T> prev = dummy;
        Node<T> current = head;

        while (current != null)
        {
            while (current.Next != null &&
                   Equals(prev.Next.Data, current.Next.Data))
                current = current.Next;

            if (prev.Next == current)
                prev = prev.Next;

            else
                prev.Next = current.Next;

            current = current.Next;
        }

        head = dummy.Next;
    }
    else
    {
        head = null;
    }
}

*/



                    //Zadanie 8//

/*

public static void DistinctElementsInLinkedList<T>(ref Node<T> head)
    where T : IEquatable<T>, IComparable<T>
{
    Node<T> ptr1 = null, ptr2 = null;
    ptr1 = head;

    while (ptr1 != null && ptr1.Next != null)
    {
        ptr2 = ptr1;

        while (ptr2.Next != null)
        {
            if (ptr1.Data.Equals(ptr2.Next.Data))
            {
                ptr2.Next = ptr2.Next.Next;
            }
            else
            {
                ptr2 = ptr2.Next;
            }
        }

        ptr1 = ptr1.Next;
    }
}

*/