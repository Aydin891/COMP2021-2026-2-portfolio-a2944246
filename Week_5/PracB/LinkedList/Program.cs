using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new LinkedList<int>();

            numbers.AddLast(10);
            numbers.AddLast(20);
            numbers.AddLast(30);
            numbers.AddLast(40);
            numbers.AddLast(50);
            numbers.AddLast(60);
            numbers.AddLast(70);


            numbers.AddFirst(5);


            LinkedListNode<int>? node = numbers.Find(50);

            if (node != null)
            {
                numbers.AddAfter(node, 55);
                numbers.AddBefore(node, 45);
            }

            Console.WriteLine("The List:");
            
            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }

            numbers.Remove(45);
            numbers.RemoveFirst();
            numbers.RemoveLast();

            
            Console.WriteLine("The list after Remove, RemoveFirst, RemoveLast:");
            
            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }

            var current = numbers.First;
            int count = 1;

            while(count < 5) 
            {
                current = current.Next;
                count ++;
            }

            numbers.Remove(current);


            Console.WriteLine("The list after 5th node Remove:");
            
            foreach(int number in numbers)
            {
                Console.WriteLine(number);
            }


            



        }
    }
}