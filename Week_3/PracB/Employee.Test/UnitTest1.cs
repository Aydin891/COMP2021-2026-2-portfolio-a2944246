namespace Employee.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        FullTimeEmployee employee1 = new FullTimeEmployee{Name = "Arthur", AnnualSalary = 48000m};

        decimal result = employee1.CalculatePay();
        Assert.Equal(38400m, result);
    }
    [Fact]
    public void Test2()
    {
        Contractor contractor1 = new Contractor{Name ="John", Rate = 50m, Hours = 20m};

        decimal result = contractor1.CalculatePay();
        Assert.Equal(800m, result);
    }
}
