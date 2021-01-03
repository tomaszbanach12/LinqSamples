using System;
using System.Collections.Generic;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee{Id = 1, Name = "Jeff"},
                new Employee{Id = 1, Name = "Paul"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee{Id = 1, Name = "Chris" }
            };

            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
        }
    }
}
