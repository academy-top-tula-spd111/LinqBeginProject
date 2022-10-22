using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBeginProject
{
    internal class LinqJoin
    {
        public static void Run()
        {
            List<User> users = new()
            {
                new(){ Id = 1, Name = "Bob", Age = 34 },
                new(){ Id = 2, Name = "Joe", Age = 21 },
                new(){ Id = 3, Name = "Tim", Age = 42 },
                new(){ Id = 4, Name = "Sam", Age = 39 },
            };

            List<Skill> skills = new()
            {
                new(){ Id = 1, Title = "C#" },
                new(){ Id = 2, Title = "C++" },
                new(){ Id = 3, Title = "Java" },
            };

            List<UserSkill> usersSkills = new()
            {
                new(){ UserId = 1, SkillId = 1 },
                new(){ UserId = 1, SkillId = 2 },
                new(){ UserId = 2, SkillId = 2 },
                new(){ UserId = 2, SkillId = 3 },
                new(){ UserId = 3, SkillId = 2 },
                new(){ UserId = 4, SkillId = 1 },
                new(){ UserId = 4, SkillId = 3 },
            };

            var userQueryOne = from us in usersSkills
                               from u in users
                               from s in skills
                               where us.UserId == u.Id && us.SkillId == s.Id
                               select new
                               {
                                   UserName = u.Name,
                                   UserAge = u.Age,
                                   UserSkill = s.Title
                               };

            //foreach(var item in userQueryOne)
            //    Console.WriteLine($"{item.UserName} - {item.UserAge} - {item.UserSkill}");


            List<Company> companies = new()
            {
                new() { Title = "Yandex", City = "Moscow" },
                new() { Title = "Ozon" , City = "St. Peterburg"},
                new() { Title = "Avito", City = "Sochi" }
            };

            List<Employe> employes = new()
            {
                new(){ Name = "Nick", Company = "Yandex" },
                new(){ Name = "Mike", Company = "Ozon" },
                new(){ Name = "Bill", Company = "Yandex" },
                new(){ Name = "Tom", Company = "Ozon" },
                new(){ Name = "Pillip", Company = "Avito" },
                new(){ Name = "Roger", Company = "Ozon" },
                new(){ Name = "Leo", Company = "Avito" },
            };


            // where
            //var userCityWhere = from c in companies
            //                    from e in employes
            //                    where c.Title == e.Company
            //                    select new
            //                    {
            //                        Name = e.Name,
            //                        City = c.City
            //                    };

            //foreach(var item in userCityWhere)
            //    Console.WriteLine($"{item.Name} - {item.City}");
            //Console.WriteLine(new String('-', 20));

            // operations LINQ
            //var userCityJoin = from c in companies
            //                   join e in employes on c.Title equals e.Company
            //                   select new
            //                   {
            //                       Name = e.Name,
            //                       City = c.City
            //                   };
            //foreach (var item in userCityJoin)
            //    Console.WriteLine($"{item.Name} - {item.City}");
            //Console.WriteLine(new String('-', 20));

            // methods LINQ
            //var userCityJoinTwo = companies.Join(
            //        employes,
            //        c => c.Title,
            //        e => e.Company,
            //        (c, e) => new { Name = e.Name, City = c.City }
            //    );

            //foreach (var item in userCityJoinTwo)
            //    Console.WriteLine($"{item.Name} - {item.City}");
            //Console.WriteLine(new String('-', 20));

            // operations LINQ
            var userCityGroupJoin = from c in companies
                                    join e in employes on c.Title equals e.Company
                                    group e by c.City into temp
                                    select new
                                    {
                                        City = temp.Key,
                                        Employe = temp,
                                    };
            foreach (var item in userCityGroupJoin)
            {
                Console.WriteLine($"{item.City}");
                foreach (var n in item.Employe)
                    Console.WriteLine($"\t{n.Name}");
            }

            Console.WriteLine(new String('-', 20));


            var userCityGroupJoinTwo = companies.Join(
                    employes,
                    c => c.Title,
                    e => e.Company,
                    (c, e) => new { Name = e.Name, City = c.City }
                ).GroupBy(c => c.City)
                 .Select(temp => new
                 {
                     City = temp.Key,
                     Employe = temp,
                 });

            var userCityGroupJoinThree = companies.GroupJoin(
                employes,
                c => c.Title,
                e => e.Company,
                (c, empl) => new
                {
                    City = c.City,
                    Employe = empl
                }
                );


            foreach (var item in userCityGroupJoinTwo)
            {
                Console.WriteLine($"{item.City}");
                foreach (var n in item.Employe)
                    Console.WriteLine($"\t{n.Name}");
            }
            Console.WriteLine(new String('-', 20));

            foreach (var item in userCityGroupJoinThree)
            {
                Console.WriteLine($"{item.City}");
                foreach (var n in item.Employe)
                    Console.WriteLine($"\t{n.Name}");
            }
            Console.WriteLine(new String('-', 20));
        }
    }
}
