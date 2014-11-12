/*Implement the data structure linked list. Define a class ListItem<T>
 * that has two fields: value (of type T) and NextItem (of type ListItem<T>).
 * Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).
*/

namespace LinkedListImplementation
{
    using System;
    using System.Linq;
    using LinkedList;

    public class LinkedListImplementation
    {
        public static void Main(string[] args)
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();

            list.AddFirst(5);
            list.AddFirst(6);
            list.AddLast(10);
            list.AddLast(50);
            list.AddFirst(4);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}