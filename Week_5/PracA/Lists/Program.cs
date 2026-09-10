using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>("Arthur", "John", "Max", "Allen", "Bruce");

            names.Add("Sarah");
            names.Add("Olivia");
            names.Remove("Olivia");
            names.Insert(1, "Jack");
            names.AddRange(new string []{"Emma", "Daniel", "Mia"});

            int index = names.IndexOf("Arthur");
            Console.WriteLine($"Arthur index is: {index}");

        }
    }
}