using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Enumerator****");
            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee{Id = 1, Name = "Chris" },
                new Employee{Id = 2, Name = "Paul" },
                new Employee{Id = 3, Name = "John" },
                new Employee{Id = 4, Name = "Ross" },
                new Employee{Id = 5, Name = "Liam" },
                new Employee{Id = 6, Name = "Noah" },
                new Employee{Id = 7, Name = "Todd" },
                new Employee{Id = 8, Name = "Bob"}
            };
            // Enumerator
            IEnumerator<Employee> enumerator = sales.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            Console.WriteLine("****Extension method****");
            // Extension method
            Console.WriteLine(sales.Count());

            Console.WriteLine("****Named method****");
            // Named method
            foreach (var item in sales.Where(NameStatsWithR))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("****Anonymous method****");
            // Anonymous method
            foreach (var item in sales.Where(
                delegate (Employee employee)
                {
                    return employee.Name.StartsWith('J');
                }))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("****Lambda method****");
            // Lambda method
            foreach (var item in sales.Where(e => e.Name.StartsWith('L')))
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("****Another lambda method****");
            // Lambda method
            foreach (var item in sales.Where(e => e.Name.Length == 4)
                                      .OrderBy(e => e.Name))
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("****Func types and action types****");
            //Func type that takes an integer and returns an integer 
            Func<int, int> square = x => x * x;
            //Func type that takes two integers and returns an integer 
            Func<int, int, int> add = (x, y) =>
            {
                return x + y;
            };
            // Action type that takes an integer and returns a void, as always
            Action<int> write = x => Console.WriteLine(x);
            write(square(add(3, 2)));        
        }
        private static bool NameStatsWithR(Employee employee)
        {
            return employee.Name.StartsWith('R');
        }
    }
}
