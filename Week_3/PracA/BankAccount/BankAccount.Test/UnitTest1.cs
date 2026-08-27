namespace BankAccount.Test;

public class UnitTest1
{
    [Fact]
    public void DepositTest()
    {
        BankAccount account1 = new BankAccount("Jack", 100m);
        account1.Deposit(50m);
        Assert.Equal(150m, account1.Balance); 
    }

    [Fact]
    public void WithdrawTest()
    {
        BankAccount account1 = new BankAccount("Jack", 100m);
        account1.Withdraw(50m);
        Assert.Equal(0m, account1.Balance); 
    }

        [Fact]
        public void SavingInterestTest()
    {
        BankAccount account1 = new BankAccount("Jack", 100m, 0.20m);
        account1.ApplyInterest();
        Assert.Equal(120m, account1.Balance); 
    }
}
