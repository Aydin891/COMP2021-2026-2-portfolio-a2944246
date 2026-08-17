using System;

namespace MyApp
{
    static class Program
    {
        const double TaxRate = 0.2;
        static double calculate_pay(double hours, double rate)
        {
            if(hours < 0 || rate < 0 )
            {
                throw new ArgumentException("Hours and rate must be positive.");
            }
            
        double gross = hours * rate;
        double tax = gross * TaxRate;
        double net = gross - tax;
        
        return net;

        }
        static void Main(string[] args)
        {
            Console.Write("Enter employee name: ");
            string name = Console.ReadLine();

            Console.Write("Hours worked: ");
            double hours = double.Parse(Console.ReadLine());
            
            Console.Write("Hourly rate: ");
            double rate =  double.Parse(Console.ReadLine());

            double net_pay = calculate_pay(hours, rate);

            Console.WriteLine($"{name} earned ${net_pay:F2} after tax. ");

        }
    }
}

        

