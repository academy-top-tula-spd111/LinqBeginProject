using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBeginProject
{
    internal class LinqSelect
    {
        public static void Run()
        {
            List<User> users = new List<User>()
            {
                new User(){ Name = "Bob", Age = 34 },
                new User(){ Name = "Joe", Age = 22 },
                new User(){ Name = "Sam", Age = 41 },
                new User(){ Name = "Tommy", Age = 32 },
                new User(){ Name = "Jim", Age = 19 },
                new User(){ Name = "Mike", Age = 27 },
                new User(){ Name = "Billy", Age = 43 },
                new User(){ Name = "Walter", Age = 36 },
            };

            List<Company> companies = new()
            {
                new(){ Title = "Yandex" },
                new(){ Title = "Mail Group" },
                new(){ Title = "Ozon" },
                new(){ Title = "Avito" },
            };

            List<Group> groups = new()
            {
                new(){ Title = "AA-123", Users = new(){ users[0], users[3] } },
                new(){ Title = "BB-555", Users = new(){ users[1], users[2], users[4] } },
                new(){ Title = "DF-980", Users = new(){ users[5] } },
                new(){ Title = "JA-011", Users = new(){ users[6], users[7] } },
            };

            // linq operations
            var namesOne = from user in users
                           select user.Name;

            foreach (var name in namesOne)
                Console.WriteLine(name);
            Console.WriteLine(new String('-', 20));

            // linq methods
            var namesTwo = users.Select(u => u.Name);

            foreach (var name in namesTwo)
                Console.WriteLine(name);
            Console.WriteLine(new String('-', 20));

            // linq operations
            var userYearOne = from user in users
                              select new
                              {
                                  FirstName = user.Name,
                                  Year = DateTime.Now.Year - user.Age
                              };

            foreach (var item in userYearOne)
                Console.WriteLine($"{item.FirstName} - {item.Year}");
            Console.WriteLine(new String('-', 20));

            // linq methods
            var userYearTwo = users.Select(u => new
            {
                FirstName = u?.Name,
                Year = DateTime.Now.Year - u.Age
            });

            foreach (var item in userYearTwo)
                Console.WriteLine($"{item.FirstName} - {item.Year}");
            Console.WriteLine(new String('-', 20));

            // linq operations
            var userYearMrOne = from user in users
                                let name = "Mr. " + user.Name
                                let year = DateTime.Now.Year - user.Age
                                select new
                                {
                                    FirstName = name,
                                    Year = year
                                };

            foreach (var item in userYearMrOne)
                Console.WriteLine($"{item.FirstName} - {item.Year}");
            Console.WriteLine(new String('-', 20));

            // two collections
            // linq operathions
            //var decartOne = from u in users
            //                from c in companies
            //                select new
            //                {
            //                    User = u.Name,
            //                    Company = c.Title
            //                };

            //foreach (var item in decartOne)
            //    Console.WriteLine($"{item.User} - {item.Company}");
            //Console.WriteLine(new String('-', 20));

            // select many
            // linq operations
            var usersOne = from g in groups
                           from u in g.Users
                           select u;

            foreach (var item in usersOne)
                Console.WriteLine($"{item.Name} - {item.Age}");
            Console.WriteLine(new String('-', 20));

            // linq methods
            var usersTwo = groups.SelectMany(g => g.Users);

            foreach (var item in usersTwo)
                Console.WriteLine($"{item.Name} - {item.Age}");
            Console.WriteLine(new String('-', 20));

            // linq methods SelectMany<Func, Func>
            var userGroupTwo = groups.SelectMany(
                                                 g => g.Users,
                                                 (g, u) => new
                                                 {
                                                     User = u?.Name,
                                                     Group = g?.Title
                                                 }
                                                 );

            foreach (var item in userGroupTwo)
                Console.WriteLine($"{item.User} - {item.Group}");
            Console.WriteLine(new String('-', 20));
        }
    }
}
