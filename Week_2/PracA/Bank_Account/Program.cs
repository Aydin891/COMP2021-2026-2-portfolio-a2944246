using System;

namespace MyApp
{
    static class Program
    {
        class Payroll
        {
            private double hours;
            private decimal rate;
            private decimal taxRate;

            public double Hours
            {
                get
                {
                    return hours;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("The hour cant be negative");
                    }

                    hours = value;
                }
            }

            public decimal Rate
            {
                get 
                {
                    return rate;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("The rate cant be negative");
                    }

                    rate = value;
                }
            }

            public decimal TaxRate
            {
                get 
                {
                    return taxRate;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("The taxRate cant be negative");
                    }

                    taxRate = value;
                }
            }



            public Payroll(double hours, decimal rate, decimal taxRate)
            {
                Hours = hours;
                Rate = rate;
                TaxRate = taxRate;
                
            }

            public decimal CalculateNetPay()
            { 
                decimal gross = (decimal)hours * rate;
                decimal tax = gross * taxRate;
                decimal net = gross - tax;
                
                return net;
            } 

            public void ChangeTaxRate(decimal newTaxRate)
            {
                if (newTaxRate < 0)
                {
                    throw new ArgumentException("Tax rate has to be postivie a number");
                }
                taxRate = newTaxRate; 
            }


        }
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

        

