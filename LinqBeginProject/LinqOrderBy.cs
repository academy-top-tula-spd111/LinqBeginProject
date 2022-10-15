using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBeginProject
{
    internal class LinqOrderBy
    {
        public static void Run()
        {
            List<User> users = new List<User>()
            {
                new User(){ Name = "Bob", Age = 37, Skils = new(){ "C++", "JS", "HTML" } },
                new User(){ Name = "Tommy", Age = 22, Skils = new(){ "C#", "Java", "HTML", "CSS" } },
                new User(){ Name = "Sam", Age = 41, Skils = new(){ "C++", "C#", "Java" } },
                new User(){ Name = "Tommy", Age = 32, Skils = new(){ "JS", "HTML", "CSS" } },
                new User(){ Name = "Jim", Age = 32, Skils = new(){ "C#", "Java", "CSS" } },
                new User(){ Name = "Bob", Age = 27, Skils = new(){ "C++", "C#" } },
                new User(){ Name = "Billy", Age = 27, Skils = new(){ "HTML", "CSS" } },
                new User(){ Name = "Tommy", Age = 36, Skils = new(){ "C++", "JS", "HTML" } },
            };

            var usersSortOne = from u in users
                               orderby u.Age
                               orderby u.Name
                               select u;

            foreach (var item in usersSortOne)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));

            //
            var usersSortTwo = users.OrderBy(u => u.Name).ThenBy(u => u.Age);

            foreach (var item in usersSortTwo)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));


            //
            var usersSortNameOne = from u in users
                                   orderby u.Name
                                   select u;

            foreach (var item in usersSortNameOne)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));

            //
            var usersSortNameTwo = users.OrderBy(u => u.Name, new UserNameLengthComparer()!);

            foreach (var item in usersSortNameTwo)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));
        }
    }
}
