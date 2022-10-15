using System;
using System.Collections;
using System.Drawing;
using System.Xml.Linq;

namespace LinqBeginProject
{
    class Figure
    {
        public string Title { get; set; }
    }

    class Rect : Figure
    {

    }

    class Circle : Figure
    {

    }


    class User
    {
        public string? Name { get; set; }
        public int Age { set; get; }
        public List<string>? Skils { set; get; }

    }

    class UserNameLengthComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            int result = x?.Length ?? 0 - y?.Length ?? 0;
            if (result == 0)
                return String.Compare(x, y);
            return result;
        }
    }

    class Company : IEquatable<Company>
    {
        public string? Title { set; get; }
        public string? City { set; get; }

        public bool Equals(Company? other)
        {
            return this.Title == other.Title;
        }
        public override bool Equals(object obj) => Equals(obj as Company);
        public override int GetHashCode() => (Title).GetHashCode();
    }

    class CompanyTitleComparer : IComparer<Company>
    {
        public int Compare(Company? x, Company? y)
        {
            return String.Compare(x.Title, y.Title);
        }
    }

    class Group
    {
        public string? Title { set; get; }
        public List<User>? Users { set; get; }
    }

    class Region
    {
        public List<string> Companies { set; get; }
    }

    class Employe
    {
        public string? Name { set; get; }

        public string? Company { set; get; }
        public int Age { set; get; }
        public float Salary { set; get; }
    }
    internal class Program
    {
        static bool IsAll(string key, IEnumerable<string> collection)
        {
            bool result = true;
            foreach (var item in collection)
                result = result && item == key;

            return result;
        }
        static void Main(string[] args)
        {
            //LinqBegin.Run();
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
            foreach(var comp in usersGroupOne)
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
                foreach(var e in comp.Employes)
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