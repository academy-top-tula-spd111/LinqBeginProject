using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBeginProject
{
    internal class SetOperation
    {
        public static void Run()
        {
            Region regionA = new()
            {
                Companies = new()
                {
                    "Yandex", "Mail Grooup", "Avito", "Ozon", "Gazprom"
                }
            };

            Region regionB = new()
            {
                Companies = new() {
                    "SberMarket", "Tinkoff", "DomStroy", "Yandex", "Mail Grooup"
                }
            };

            List<Company> companies = new List<Company>()
            {
                new Company(){ Title = "Yandex", City = "Moscow" },
                new Company(){ Title = "Mail Grooup", City = "Moscow" },
                new Company(){ Title = "Avito", City = "Moscow" },
                new Company(){ Title = "Ozon", City = "Moscow" },
                new Company(){ Title = "Gazprom", City = "Moscow" },
                new Company(){ Title = "SberMarket", City = "Moscow" },
                new Company(){ Title = "Tinkoff", City = "Moscow" },
                new Company(){ Title = "DomStroy", City = "Moscow" },
                //8
                new Company(){ Title = "Yandex", City = "St Peterburg" },
                new Company(){ Title = "Mail Grooup", City = "St Peterburg" },
                new Company(){ Title = "Avito", City = "St Peterburg" },
                new Company(){ Title = "Ozon", City = "St Peterburg" },
            };

            List<Company> regA = new()
            {
                companies[0], companies[1], companies[2], companies[3], companies[4], companies[10], companies[11]
            };

            List<Company> regB = new()
            {
                companies[5], companies[6], companies[7], companies[8], companies[9], companies[10], companies[11]
            };

            // Intersect
            var regionIntersect = regionA.Companies.Intersect(regionB.Companies);
            foreach (var item in regionIntersect)
                Console.WriteLine($"{item}");
            Console.WriteLine(new String('-', 20));

            var regIntersect = regA.Intersect(regB);
            foreach (var item in regIntersect)
                Console.WriteLine($"{item.Title} {item.City}");
            Console.WriteLine(new String('-', 20));


            // Union
            var regionUnion = regionA.Companies.Union(regionB.Companies);
            foreach (var item in regionUnion)
                Console.WriteLine($"{item}");
            Console.WriteLine(new String('-', 20));


            var regUnion = regA.Union(regB);
            foreach (var item in regUnion)
                Console.WriteLine($"{item.Title} {item.City}");
            Console.WriteLine(new String('-', 20));

            // Concat & Distinct
            var regionConcat = regionA.Companies.Concat(regionB.Companies).Distinct();
            foreach (var item in regionConcat)
                Console.WriteLine($"{item}");
            Console.WriteLine(new String('-', 20));

            // Except
            var regionExceptA = regionA.Companies.Except(regionB.Companies);
            foreach (var item in regionExceptA)
                Console.WriteLine($"{item}");
            Console.WriteLine(new String('-', 20));

            var regionExceptSymmetricOne = regionA.Companies.Except(regionB.Companies)
                                                            .Union(regionB.Companies.Except(regionA.Companies));
            foreach (var item in regionExceptSymmetricOne)
                Console.WriteLine($"{item}");
            Console.WriteLine(new String('-', 20));

            var regionExceptSymmetricTwo = regionA.Companies.Union(regionB.Companies)
                                                            .Except(regionA.Companies.Intersect(regionB.Companies));
            foreach (var item in regionExceptSymmetricTwo)
                Console.WriteLine($"{item}");
            Console.WriteLine(new String('-', 20));
        }
    }
}
