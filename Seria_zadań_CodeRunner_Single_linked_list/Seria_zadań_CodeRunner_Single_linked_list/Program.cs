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