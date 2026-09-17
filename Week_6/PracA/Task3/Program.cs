public class BankAccount(string owner, decimal balance)
{
  public string Owner { get; set; } = owner;
  public decimal Balance { get; set; } = balance;

  public decimal Deposit(decimal amount)
  {
    if (amount < 0)
    {
      throw new ArgumentException("Amount must not be negative.");
    }
    return Balance += amount;
  }

  public decimal Deposit(int amount)
  {
    return Deposit((decimal)amount);
  }

  public decimal Deposit(double amount)
  {
    return Deposit((decimal)amount);
  }

  public virtual decimal Withdraw(decimal amount)
  {
    if (amount < 0)
    {
      throw new ArgumentException("Amount must not be negative.");
    }
    if (Balance < amount)
    {
      throw new ArgumentException("Balance is less than amount");
    }
    return Balance -= amount;
  }

  public override string ToString()
  {
    string info = $"""
      Account: {nameof(BankAccount)}
      Owner: {Owner}
      Balance: {Balance:F2}
      """;
    return info;
  }

    static void Main(string[] args)
    {
        var bankAccount = new Stack<BankAccount>();

        var account1 = new BankAccount("John", 1000);
        var account2 = new BankAccount("Jack", 500);
        var account3 = new BankAccount("Arthur", 250);
        var account4 = new BankAccount("Sadie", 125);
        var account5 = new BankAccount("Abigail", 2500);
        var account6 = new BankAccount("Duch", 3000);
        var account7 = new BankAccount("Bill", 10000);
        var account8 = new BankAccount("Alex", 38);
        var account9 = new BankAccount("Maria", 800);
        var account10 = new BankAccount("Mia", 235);


        bankAccount.Push(account1);
        bankAccount.Push(account2);
        bankAccount.Push(account3);
        bankAccount.Push(account4);
        bankAccount.Push(account5);
        bankAccount.Push(account6);
        bankAccount.Push(account7);
        bankAccount.Push(account8);
        bankAccount.Push(account9);
        bankAccount.Push(account10);

        int counter = 1;

        foreach(var account in bankAccount)
        {
            Console.WriteLine();
            Console.WriteLine($"Acount {counter}:");
            Console.WriteLine(account);

            counter ++;
        }

    }
    static Queue<BankAccount> StackToQueue(Stack<BankAccount> accounts)
    {
        var accountQueue = new Queue<BankAccount>();

        foreach (BankAccount account in accounts)
        {
            accountQueue.Enqueue(account);
        }

        return accountQueue;
    }
}