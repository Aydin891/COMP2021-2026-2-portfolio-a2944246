using System;

namespace MyApp
{
    internal class Program
    {
        abstract class Employee
        {
            public string Name { get; set; }

            protected const decimal TaxRate = 0.2m;

            public abstract decimal CalculatePay();
        }

        class FullTimeEmployee : Employee, IReportable
        {
            public decimal AnnualSalary { get; set; }

            public override decimal CalculatePay()
            {
                decimal tax = AnnualSalary * TaxRate;
                return AnnualSalary - tax;
            }

            public void GenerateReport()
            {
                Console.WriteLine($"Name: {Name}, Annual Salary: ${AnnualSalary}, Pay after tax: {CalculatePay()}");
            }
        }

        class Contractor : Employee, IReportable
        {
            public decimal Rate { get; set; }
            public decimal Hours { get; set; }

            public override decimal CalculatePay()
            {
                decimal grossPay = Rate * Hours;
                decimal tax = grossPay * TaxRate;

                return grossPay - tax;
            }

            public void GenerateReport()
            {
                Console.WriteLine($"Name: {Name}, Rate: ${Rate}, Hours: {Hours}, Pay after tax: ${CalculatePay()}");
            }
        }

        interface IReportable
        {
            void GenerateReport();
        }

        static void Main(string[] args)
        {
            FullTimeEmployee employee1 = new FullTimeEmployee{Name = "Arthur", AnnualSalary = 48000m};
            Contractor contractor1 = new Contractor{Name ="John", Rate = 50m, Hours = 20m};
            
            employee1.GenerateReport();

            Console.WriteLine();

            contractor1.GenerateReport();

        }
    }
}