/*Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element).
*/

namespace StackImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Stack;

    public class StackImplementation
    {
        public static void Main(string[] args)
        {
            var stack = new CustomStack<int>();

            stack.Push(50);
            stack.Push(3);
            stack.Push(56);
            stack.Push(50);
            stack.Push(3);
            stack.Push(56);
            stack.Push(50);
            stack.Push(3);
            stack.Push(56);
            stack.Push(50);
            stack.Push(3);
            stack.Push(56);

            Console.WriteLine(stack.Peek());
            stack.Pop();
            var a = stack.Pop();
            Console.WriteLine(a);

            Console.WriteLine(stack.Contains(56));
        }
    }
}