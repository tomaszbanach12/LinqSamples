using System;
using System.Collections.Generic;
//using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{Id = 1, Name = "Jeff"},
                new Employee{Id = 1, Name = "Bob"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee{Id = 1, Name = "Chris" },
                new Employee{Id = 1, Name = "Paul" }
            };
            Console.WriteLine(sales.Count());

            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
        }
    }
}
