using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBeginProject
{
    internal class LinqBegin
    {
        public static void Run()
        {
            string[] strs = { "Tom", "Billy", "Joe", "Mike", "Sam", "Nick" };

            List<string> namesThree = new List<string>();

            // original
            foreach (string s in strs)
                if (s.Length <= 3)
                    namesThree.Add(s);
            namesThree.Sort();

            foreach (string s in namesThree)
                Console.WriteLine(s);
            Console.WriteLine(new String('-', 20));

            // LINQ operation
            var namesLinqOne = from s in strs
                               where s.Length <= 3
                               orderby s
                               select s;

            foreach (string s in namesLinqOne)
                Console.WriteLine(s);
            Console.WriteLine(new String('-', 20));

            //LINQ methods
            var namesLinqTwo = strs.Where(s => s.Length <= 3).OrderBy(s => s);

            foreach (string s in namesLinqTwo)
                Console.WriteLine(s);
            Console.WriteLine(new String('-', 20));
        }
    }
}
