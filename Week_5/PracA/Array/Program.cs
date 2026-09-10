using System;
using Microsoft.VisualBasic;

namespace MyApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------Print out of the values----------");
            var names = new string[] {"Arthur", "John", "Max", "Allen", "Bruce", "Sarah", "Olivia", "Daniel", "Emma"};

            foreach (var name in names)
            {
                Console.WriteLine($"Name: {name}");
            }

            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine("----------Name Largest and Shortes----------");
            var longest = names[0];
            var shortest = names[0];

            foreach (var name in names)
            {
                if (name.Length > longest.Length)
                {
                    longest = name;
                }

                else if (name.Length < shortest.Length)
                {
                    shortest = name;
                }
            }

            Console.WriteLine($"Lingest name: {longest}");
            Console.WriteLine($"Shortest name: {shortest}");

            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine("----------Name Sorting----------");
            Array.Sort(names);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }


            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine("----------Reverse the array----------");
            Array.Reverse(names);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Array.Sort(names);
            Console.WriteLine("");

            foreach (var name in names)
            {
                
                Console.WriteLine(name);
            }


        }
    }
}

        

