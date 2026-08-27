using System;

namespace MyApp
{
    internal class Program
    {
        class BankAccount
        {
            public string Owner { get; set; }
            public decimal Balance { get; set; }

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
                    throw new ArgumentException("Deposit amount must positive.");
                }
            }

            // Overload method
            public void Deposit(double amount)
            {
                Deposit((decimal)amount);
            }

            public void Deposit(int amount)
            {
                Deposit((decimal)amount);
            }

            public void Withdraw(decimal amount)
            {
                if (amount > Balance)
                {
                    throw new ArgumentException("Blance is not enough");
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

            public virtual void DisplayAccountInfo()
            {
            }
        }

        class SavingsAccount : BankAccount
        {
            private decimal interestRate;

            public decimal InterestRate
            {
                get
                {
                    return interestRate;
                }
                set
                {
                    interestRate = value;
                }
            }

            public SavingsAccount(string owner, decimal balance, decimal interestRate) : base(owner, balance)
            {
                InterestRate = interestRate;
            }

            public override void DisplayAccountInfo()
            {
                Console.WriteLine($"Account: SavingsAccount");
                Console.WriteLine($"Owner: {Owner}");
                Console.WriteLine($"Balance: {Balance}");
                Console.WriteLine($"Interest rate: {InterestRate}");
            }

            public void ApplyInterest()
            {
                Balance = Balance * interestRate;
                Console.WriteLine($"New Balance: {Balance}");
            }
        }

        class CheckingAccount : BankAccount
        {
            private decimal transactionFee;

            public decimal TransactionFee
            {
                get
                {
                    return transactionFee;
                }
                set
                {
                    transactionFee = value;
                }
            }

            public CheckingAccount(string owner, decimal balance, decimal transactionFee) : base(owner, balance)
            {
                TransactionFee = transactionFee;
            }

            public override void DisplayAccountInfo()
            {
            }
        }

        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Jack", 500);
            SavingsAccount save1 = new SavingsAccount("Jack", 100, 0.2m);
            CheckingAccount checking1 = new CheckingAccount("Jack", 100, 0.2m);

            save1.DisplayAccountInfo();
            save1.ApplyInterest();

            checking1.DisplayAccountInfo();

            account1.Deposit(100);
            Console.WriteLine($"amount after deposit: {account1.Balance}");

            account1.Withdraw(200);
            Console.WriteLine($"amount after withdraw: {account1.Balance}");

            // Method overload (int)
            account1.Deposit(100);

            // Method overload (double)
            account1.Deposit(50.5);

            // Method overload (decimal)
            account1.Deposit(50.50m);
        }
    }
}