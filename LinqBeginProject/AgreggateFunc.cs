using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBeginProject
{
    internal class AgreggateFunc
    {
        public static void Run()
        {
            List<Employe> employes = new()
            {
                new(){ Name = "Bob", Age = 45, Salary = 62000 },
                new(){ Name = "Joe", Age = 23, Salary = 78000 },
                new(){ Name = "Tim", Age = 37, Salary = 54000 },
                new(){ Name = "Ben", Age = 21, Salary = 49000 },
                new(){ Name = "Sam", Age = 42, Salary = 65000 },
                new(){ Name = "Tom", Age = 29, Salary = 71000 },
            };

            // Count
            Console.WriteLine($"Count: {employes.Count()}");
            Console.WriteLine($"Count if: {employes.Count(e => e.Salary >= 50000 && e.Salary <= 65000)}");

            // Sum
            Console.WriteLine($"Salary Total: {employes.Sum(e => e.Salary)}");
            Console.WriteLine($"Salary Total Where: {employes.Where(e => e.Age > 30).Sum(e => e.Salary)}");

            // Avg
            Console.WriteLine($"Avg Age: {employes.Average(e => e.Age)}");
            Console.WriteLine($"Avg Salary: {employes.Average(e => e.Salary)}");

            //Min
            //Max
            Console.WriteLine($"Min Age: {employes.Min(e => e.Age)}");
            Console.WriteLine($"Min Salary: {employes.Min(e => e.Salary)}");
            Console.WriteLine($"Max Age: {employes.Max(e => e.Age)}");
            Console.WriteLine($"Max Salary: {employes.Max(e => e.Salary)}");

            // Aggregate
            Console.WriteLine($"Salary Total nalog: {employes.Aggregate(0.0, (a, n) => a + n.Salary * 0.87)}");
        }
    }
}
