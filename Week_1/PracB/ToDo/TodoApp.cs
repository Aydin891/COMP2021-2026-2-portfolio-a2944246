using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<string> {};
            var tags = new Dictionary<string, List<int>>();

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
                    
                    case "Tag":
                        {
                            Console.WriteLine("Enter Index");
                            int indexInput = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Tag name");
                            string tagName= Console.ReadLine();
                            tags.Add(tagName, new List<int>());

                            if (!tags.ConstrainsKey(indexInput))
                            {
                                
                            }







                        }


                    default:
                        {
                        Console.WriteLine("Input not valid.");
                        break;
                        }
                    

                    
                    




 
                       
                }   

            }


        }
    }
}