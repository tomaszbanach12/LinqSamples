using System;
using System.Linq;

namespace LinqSamples.Cars.Linq
{
    class LinqWithAdvancedLinqQuery
    {
        public static void LinqOnAdvancedLinqQuery()
        {
            var appDBContext = new AppDbContext();

            Console.WriteLine("****Take all of the BMW cars, sort, and then take 10 (example how to do not use)****");
            var query = appDBContext.Cars
                .GroupBy(c => c.Manufacturer)
                .Select(g => new
                {
                    Name = g.Key//,
                    // Cars = g.OrderByDescending(c => c.Combined).Take(2)
                });

            foreach (var group in query)
            {
                // Console.WriteLine(group.Name);
                // foreach (var car in group.Cars)
                // {
                //     Console.WriteLine($"\t{car.Name}: {car.Combined}");
                // }
            }
        }
    }
}
