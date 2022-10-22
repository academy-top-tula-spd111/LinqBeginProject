using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBeginProject
{
    internal class LinqGroup
    {
        public static void Run()
        {
            List<Employe> employes = new()
            {
                new() { Name = "Bob", Company = "Yandex" },
                new() { Name = "Joe", Company = "Mail Group" },
                new() { Name = "Tim", Company = "Ozon" },
                new() { Name = "Sam", Company = "Yandex" },
                new() { Name = "Ben", Company = "Ozon" },
                new() { Name = "Tom", Company = "Mail Group" },
                new() { Name = "Jim", Company = "Yandex" },
                new() { Name = "Leo", Company = "Mail Group" },
                new() { Name = "Ann", Company = "Ozon" },
                new() { Name = "Kim", Company = "Yandex" },
            };


            // linq operations
            var usersGroupOne = from e in employes
                                group e by e.Company;

            //Console.WriteLine(usersGroupOne.GetType());
            foreach (var comp in usersGroupOne)
            {
                Console.WriteLine($"Company: {comp.Key}");
                foreach (var e in comp)
                    Console.WriteLine($"\t{e.Name}");
            }
            Console.WriteLine(new String('-', 20));

            // linq methods
            var usersGroupTwo = employes.GroupBy(e => e.Company);

            foreach (var comp in usersGroupTwo)
            {
                Console.WriteLine($"Company: {comp.Key}");
                foreach (var e in comp)
                    Console.WriteLine($"\t{e.Name}");
            }
            Console.WriteLine(new String('-', 20));


            // linq operations
            var usersGroupNewOne = from e in employes
                                   group e by e.Company into temp
                                   select new
                                   {
                                       Company = temp.Key,
                                       Count = temp.Count()
                                   };

            //Console.WriteLine(usersGroupOne.GetType());
            foreach (var comp in usersGroupNewOne)
            {
                Console.WriteLine($"Company: {comp.Company} - {comp.Count}");

            }
            Console.WriteLine(new String('-', 20));

            // linq methods
            var usersGroupNewTwo = employes.GroupBy(e => e.Company)
                                           .Select(temp => new
                                           {
                                               Company = temp.Key,
                                               Count = temp.Count()
                                           });

            foreach (var comp in usersGroupNewTwo)
            {
                Console.WriteLine($"Company: {comp.Company} - {comp.Count}");
            }
            Console.WriteLine(new String('-', 20));


            // linq operations
            var usersGroupColOne = from e in employes
                                   group e by e.Company into temp
                                   select new
                                   {
                                       Company = temp.Key,
                                       Count = temp.Count(),
                                       Employes = from t in temp select t
                                   };

            //Console.WriteLine(usersGroupOne.GetType());
            foreach (var comp in usersGroupColOne)
            {
                Console.WriteLine($"Company: {comp.Company} - {comp.Count}");
                foreach (var e in comp.Employes)
                    Console.WriteLine($"\t{e.Name}");
            }
            Console.WriteLine(new String('-', 20));

            // linq methods
            var usersGroupColTwo = employes.GroupBy(e => e.Company)
                                           .Select(temp => new
                                           {
                                               Company = temp.Key,
                                               Count = temp.Count(),
                                               Employes = temp.Select(e => e)
                                           });

            //foreach (var comp in usersGroupColTwo)
            //{
            //    Console.WriteLine($"Company: {comp.Company} - {comp.Count}");
            //    foreach (var e in comp.Employes)
            //        Console.WriteLine($"\t{e.Name}");
            //}
            Console.WriteLine(new String('-', 20));


            string compn = "Yandex";
            var eComp = from e in employes
                        where e.Company == compn
                        select e;


            compn = "Ozon";
            foreach (var e in eComp)
                Console.WriteLine($"{e.Name} {e.Company}");
            Console.WriteLine(new String('-', 20));

            compn = "Yandex";
            foreach (var e in eComp)
                Console.WriteLine($"{e.Name} {e.Company}");
            Console.WriteLine(new String('-', 20));
        }
    }
}
