using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var printerJob = new Queue<String>();

            printerJob.Enqueue("Print Job 1");
            printerJob.Enqueue("Print Job 2");
            printerJob.Enqueue("Print Job 3");

            Console.WriteLine("Iten at the top of the Queue:");
            Console.WriteLine(printerJob.Peek());


            Console.WriteLine();
            Console.WriteLine("Print Jobs in the queue:");
            foreach(string print in printerJob)
            {
                Console.WriteLine(print);
            }


            string dequeueString = printerJob.Dequeue();
            Console.WriteLine();
            Console.WriteLine("Print jobs after Dequeue():");
            foreach(string print in printerJob)
            {
                Console.WriteLine(print);
            }

            Console.WriteLine();
            Console.WriteLine("The Dequeue string::");
            Console.WriteLine(dequeueString);

            Console.WriteLine();
            Console.WriteLine("Dequeue():");
            Console.WriteLine(printerJob.Dequeue());


        }
    }
}