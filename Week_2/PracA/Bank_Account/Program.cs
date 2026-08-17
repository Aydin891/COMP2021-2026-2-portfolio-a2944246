using System;

namespace MyApp
{
    static class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Enter employee name: ");
            string name = Console.ReadLine();

            Console.Write("Hours worked: ");
            double hours = double.Parse(Console.ReadLine());
            
            Console.Write("Hourly rate: ");
            decimal rate =  decimal.Parse(Console.ReadLine());

            Console.Write("Enter tax rate: ");
            decimal taxRate = decimal.Parse(Console.ReadLine());

            Payroll payroll = new Payroll(hours, rate, taxRate);


            decimal net_pay = payroll.CalculateNetPay();

            Console.WriteLine($"{name} earned ${net_pay:F2} after tax. ");

        }
    }
}

        

