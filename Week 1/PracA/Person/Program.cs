using System;

namespace MyApp
{
    static class Program
    {
        public class Person
        {
            public string firstName;
            public string lastName;
            public int Age;

            public Person(string first, string last, int age)
            {
                firstName = first;
                lastName = last;
                Age = age;
            }

            public string FullName()
            {
                return $"{firstName} {lastName}";
            }

            public bool IsAdult()
            {
                return Age >= 18;
            }
        }

        static void Main(string[] args)
        {
            Person person1 = new Person("John", "Marston", 45);

            Console.WriteLine(person1.FullName());
            Console.WriteLine(person1.IsAdult());
        }
    }
}