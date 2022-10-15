using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBeginProject
{
    internal class LinqWhere
    {
        public static void Run()
        {
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

            var users25One = from u in users
                             where u.Age > 25
                             select new
                             {
                                 Name = u.Name,
                                 Year = DateTime.Now.Year - u.Age
                             };

            foreach (var item in users25One)
                Console.WriteLine($"{item.Name} {item.Year}");
            Console.WriteLine(new String('-', 20));

            var users25Two = users.Where(u => u.Age > 25)
                                  .Select(u => new
                                  {
                                      Name = u.Name,
                                      Year = DateTime.Now.Year - u.Age
                                  });

            foreach (var item in users25Two)
                Console.WriteLine($"{item.Name} {item.Year}");
            Console.WriteLine(new String('-', 20));

            //
            var userSkillOne = from u in users
                               where u.Age >= 35
                               from s in u.Skils!
                               where s == "C++"
                               select u;

            foreach (var item in userSkillOne)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));

            //
            var userSkillTwo = users.SelectMany(u => u.Skils,
                                     (u, s) => new { User = u, Skill = s })
                                    .Where(r => r.User.Age > 35 && r.Skill == "C++")
                                    .Select(u => u.User)
                                    .SelectMany(u => u.Skils,
                                     (u, s) => new { User = u, Skill = s })
                                    .Where(r => r.User.Age > 35 && r.Skill == "HTML")
                                    .Select(u => u.User);

            foreach (var item in userSkillTwo)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));


            List<Figure> figures = new List<Figure>()
            {
                new Figure(){ Title = "Figure 1" },
                new Circle(){ Title = "Circle 1" },
                new Rect(){ Title = "Rectangle 1" },
                new Figure(){ Title = "Figure 2" },
                new Rect(){ Title = "Rectangle 2" },
                new Circle(){ Title = "Circle 2" },
            };

            var figuresTypes = figures.OfType<Figure>();
            foreach (var item in figuresTypes)
                Console.WriteLine($"{item.Title}");
            Console.WriteLine(new String('-', 20));
        }
    }
}
