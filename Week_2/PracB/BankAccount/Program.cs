using System;
using System.Security.Cryptography.X509Certificates;

namespace MyApp
{
    internal class Program
    {
        class BankAccount
        {
            public string Owner {get; set;}
            public decimal Balance {get; set;}

            public BankAccount(string owner, decimal balance)
            {
                Owner = owner;
                Balance = balance;

            }

            public void Deposit(decimal amount)
            {
                if (amount > 0)
                {
                    Balance = Balance + amount;
                }
                else
                {
                    throw new ArgumentException ("Deposit amount must positive.");
                }
            //Over load method
            public void Deposit(double amount)
            {
                Deposit((decimal) amount);
            }
            public void Deposit(int amount)
            {
                Deposit((decimal) amount);
            }

            }
            public void Withdraw(decimal amount)
            {
                if (amount > Balance)
            {
                throw new ArgumentException ("Blance is not enough");
            }
            else if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }
            else
            {
                Balance = Balance - amount;
            }

            }


        }
        
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Jack", 500);

            account1.Deposit(100);
            Console.WriteLine($"amount after deposit: {account1.Balance}");

            account1.Withdraw(200);
            Console.WriteLine($"amount after withdraw: {account1.Balance}");

            //Method overload (int)
            account1.Deposit(100); 

            //Method overload (double)
            account1.Deposit(50.5); 

            //Method overload (decimla)
            account1.Deposit(50.50);


        }
    }
}