using System;
using System.Security.Cryptography.X509Certificates;

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
            Person person_1 = new Person("Arthur", "Morgan", 45);
            Person person_2 = new Person("John", "Marston", 35);
            Person person_3 = new Person("Ana", "Brown", 22);
            Person person_4 = new Person("Fred", "Smith", 21);
            Person person_5 = new Person("Emma", "Wilson", 32);
            Person person_6 = new Person("David", "Jones", 28);
            Person person_7 = new Person("Michael", "Miller", 26);
            Person person_8 = new Person("Lisa", "Anderson", 55);
            Person person_9 = new Person("James", "Thomas", 67);
            Person person_10 = new Person("Sophie", "Davis", 92);

            List<Person> people = new List<Person>();

            people.Add(person_1);
            people.Add(person_2);
            people.Add(person_3);
            people.Add(person_4);
            people.Add(person_5);
            people.Add(person_6);
            people.Add(person_7);
            people.Add(person_8);
            people.Add(person_9);
            people.Add(person_10);

        }
        public static LinkedList<Person> ToLinkedList(List<Person> people)
        {
            LinkedList<Person> linkedPeople = new LinkedList<Person>();

            foreach (Person person in people)
            {
                linkedPeople.AddLast(person);
            }

            return linkedPeople;
        }
    }
}