using MyApp;
namespace Bank_Account.Tests;


public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Payroll payroll = new Payroll(10, 20, 0.2);
        decimal result = payroll.CalculateNetPay();
        Assert.Equal(160, result);
    }
}
