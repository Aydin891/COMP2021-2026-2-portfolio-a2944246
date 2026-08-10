using System;
using System.Runtime.InteropServices;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<string> {};

            Console.WriteLine("==========To Do==========");

            Console.WriteLine("Add to add tasks");
            Console.WriteLine("Show to see your tasks");
            Console.WriteLine("Remove to remove tasks");
            Console.WriteLine("Clear to clear all tasks");
            Console.WriteLine();



            while (true)
            {
                Console.Write("What you wnat to do?");
                string userInput = Console.ReadLine();
                switch(userInput)
                {
                    case "Add":
                        {
                        Console.Write("Please enter your task: ");
                        string taskInput = Console.ReadLine();
                        tasks.Add(taskInput);
                        Console.WriteLine("Your task has been added.");
                        break;   
                        }

                    
                    case "Show":
                        {
                        Console.WriteLine("Your taks:");
                        foreach (string task in tasks)
                        {
                            Console.WriteLine(task);
                        }
                        break;
                        
                        }

                    case "Remove":
                        {
                        Console.Write("Please enter your task to remove: ");
                        string taskInput = Console.ReadLine();
                        tasks.Remove(taskInput);
                        Console.WriteLine("Your task has been removed.");
                        break;
                        }


                    case "Clear":
                        {
                        tasks.Clear();
                        Console.WriteLine("Your tasks has been cleared.");
                        break;
                        }


                    default:
                        Console.WriteLine("Input not valid.");
                        break;
                    




 
                       
                }   

            }


        }
    }
}