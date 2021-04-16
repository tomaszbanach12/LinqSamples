using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSamples.Cars.Linq
{
    class LinqWithCaveatsAndPitfalls
    {
        public static void LinqOnCaveatsAndPitfalls()
        {
            // When using Entity Framework:
            // IQueryable gives Entity Framework the opportunity to translate your code into efficent SQL
            // IEnumerable operation always has to happen in memory

            //         IEnumerable vs IQueryable
            // - IEnumerable exists in System.Collections Namespace.
            // - IQueryable exists in System.Linq Namespace.
            // - Both IEnumerable and IQueryable are forward collection.
            // - IEnumerable doesn’t support lazy loading
            // - IQueryable support lazy loading
            // - Querying data from a database, IEnumerable execute a select query on the server side, load data in-memory on a client - side and then filter data.
            // - Querying data from a database, IQueryable execute the select query on the server side with all filters.
            // - IEnumerable Extension methods take functional objects.
            // - IQueryable Extension methods take expression objects means expression tree.

            var appDBContext = new AppDbContext();
            
            Console.WriteLine("****Take all of the BMW cars, sort, and then take 10 (example how to do not use)****");
            var queryWrong = appDBContext.Cars
                .Where(c => c.Manufacturer == "BMW")    // IQueryable
                .OrderByDescending(c => c.Combined)     // IOrderedQueryable
                .ThenBy(c => c.Name)                    // IOrderedQueryable
                .Take(10);                              // IQueryable

            foreach (var car in queryWrong)
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars with extension method syntax****");
            var query = appDBContext.Cars
                .Where(c => c.Manufacturer == "BMW")    // IQueryable
                .OrderByDescending(c => c.Combined)     // IQueryable
                .ThenBy(c => c.Name)                    // IQueryable
                .ToList()                               // IEnumerable - Took everything from the database, that we write earlier
                .Take(10);                              // IEnumerable

            foreach (var car in query)
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }
        }
    }
}
