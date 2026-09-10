using System;

namespace MyApp
{
    public class Person
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public double Age
        {
            get;
            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Age can't be less than 0");
                }
                else
                {
                    field = value;
                }
            }
        }

        public string FullName => $"{FirstName}, {LastName}";

        public Person(string firstName, string lastName, double age)
        {
            FirstName = firstName;
            LastName = lastName;

            if (age <= 0.0f)
            {
                throw new ArgumentException("Age should be greater than zero");
            }

            Age = age;
        }

        public bool IsAdult()
        {
            return Age >= 18;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}