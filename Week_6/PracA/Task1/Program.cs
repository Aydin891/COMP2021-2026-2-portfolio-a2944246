using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var undoHistory = new Stack<String>();

            undoHistory.Push("Typed Text");
            undoHistory.Push("Inserted Image");
            undoHistory.Push("Changed Colour");

            Console.WriteLine("Iten at the top of the stck:");
            Console.WriteLine(undoHistory.Peek());


            Console.WriteLine();
            Console.WriteLine("Strings in the stack:");
            foreach(string undo in undoHistory)
            {
                Console.WriteLine(undo);
            }


            string popedString = undoHistory.Pop();
            Console.WriteLine();
            Console.WriteLine("Strings after Pop():");
            foreach(string undo in undoHistory)
            {
                Console.WriteLine(undo);
            }

            Console.WriteLine();
            Console.WriteLine("The Poped string::");
            Console.WriteLine(popedString);

            Console.WriteLine();
            Console.WriteLine("Peek():");
            Console.WriteLine(undoHistory.Peek());


        }
    }
}