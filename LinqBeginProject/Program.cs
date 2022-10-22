using System;
using System.Collections;
using System.Drawing;
using System.Linq;
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


    record User
    {
        public int Id { set; get; } = 0;
        public string? Name { get; set; }
        public int Age { set; get; }
        public List<string>? Skils { set; get; }
        //public int SkillId { set; get; }

    }

    class Skill
    {
        public int Id { set; get; }
        public string? Title { get; set; }
    }

    struct UserSkill
    {
        public int UserId { set; get; }
        public int SkillId { set; get; }
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

            

            List<User> users = new List<User>()
            {
                new User(){ Name = "Bob", Age = 37, Skils = new(){ "C++", "JS", "HTML" } },
                new User(){ Name = "Joe", Age = 22, Skils = new(){ "C#", "Java", "HTML", "CSS" } },
                new User(){ Name = "Sam", Age = 41, Skils = new(){ "C++", "C#", "Java" } },
                new User(){ Name = "Tommy", Age = 32, Skils = new(){ "JS", "HTML", "CSS" } },
                new User(){ Name = "Jim", Age = 19, Skils = new(){ "C#", "Java", "CSS" } },
                new User(){ Name = "Mike", Age = 27, Skils = new(){ "C++", "C#" } },
                new User(){ Name = "Billy", Age = 43, Skils = new(){ "HTML", "CSS" } },
                new User(){ Name = "Walter", Age = 36, Skils = new(){ "C++", "JS", "HTML" } },
            };

            //bool flag = users.All(u => u.Age > 20);
            //Console.WriteLine($"{flag}");

            //bool flag2 = users.Any(u => u.Age == 43);
            //Console.WriteLine($"{flag2}");

            //bool flag3 = users.Contains(new User() { Name = "Walter", Age = 36, Skils = new() { "C++", "JS", "HTML" } });
            //Console.WriteLine($"{flag3}");

            //string[] arrStr = { "aaa", "bbb", "ccc" };
            //Console.WriteLine($"{arrStr.Contains("ddd")}");

            int age = 22;

            var user22 = from u in users
                         where u.Age >= age
                         select u;

            //age = 27;

            //foreach(var u in user22)
            //    Console.WriteLine($"{u.Name} - {u.Age}");
            //Console.WriteLine();
            //age = 35;

            //foreach (var u in user22)
            //    Console.WriteLine($"{u.Name} - {u.Age}");
        }
    }
}