using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBeginProject
{
    internal class SkipTake
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

            // Skip
            var usersSkip = users.Skip(2);

            foreach (var item in usersSkip)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));

            // SkipLast
            var usersSkipLast = users.SkipLast(3);

            foreach (var item in usersSkipLast)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));

            // SkipWhile
            var usersSkipWhile = users.SkipWhile(u => u.Age > 19);

            foreach (var item in usersSkipWhile)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));

            var usersSkipWhile2 = users.SkipWhile(u => u.Name != "Tommy");

            foreach (var item in usersSkipWhile2)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));


            // Take
            var usersTake = users.Skip(2).Take(3);
            foreach (var item in usersTake)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));

            //TakeLast
            var usersTakeLast = users.SkipLast(2).TakeLast(3);
            foreach (var item in usersTakeLast)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));

            //TakeWhile
            var usersTakeWhile = users.TakeWhile(u => u.Age > 19);
            foreach (var item in usersTakeWhile)
                Console.WriteLine($"{item.Name} {item.Age}");
            Console.WriteLine(new String('-', 20));
        }
    }
}
