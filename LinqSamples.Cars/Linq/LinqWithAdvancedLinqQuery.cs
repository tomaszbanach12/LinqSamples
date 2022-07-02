using System;
using System.Linq;

namespace LinqSamples.Cars.Linq
{
    class LinqWithAdvancedLinqQuery
    {
        public static void LinqOnAdvancedLinqQuery()
        {
            var appDBContext = new AppDbContext();
            
            Console.WriteLine("****Take 2 most fuel efficent cars by manufacturer with extension method syntax****");
            // In EF Core 3.x LINQ queries that cannot be translated are no longer evaluated on the client
            // https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-3.x/breaking-changes#linq-queries-are-no-longer-evaluated-on-the-client
            //var query = appDBContext.Cars.GroupBy(c => c.Manufacturer)
            //                             .Select(g => new
            //                             {
            //                                 Name = g.Key,
            //                                 Cars = g.OrderByDescending(c => c.Combined).Take(2)
            //                             });

            var query = appDBContext.Cars.AsEnumerable().OrderByDescending(x=>x.Manufacturer)
                                                        .GroupBy(c => c.Manufacturer)
                                                        .OrderBy(s=>s.Key)
                                                        .Select(g => new
                                                        {
                                                            Name = g.Key,
                                                            Cars = g.OrderByDescending(c => c.Combined).Take(2)
                                                        });

            foreach (var group in query)
            {
                Console.WriteLine(group.Name);
                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }

            
            Console.WriteLine("****Take 2 most fuel efficent cars by manufacturer with query method syntax****");
            // In EF Core 3.x LINQ queries that cannot be translated are no longer evaluated on the client
            // https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-3.x/breaking-changes#linq-queries-are-no-longer-evaluated-on-the-client
            //query = from car in appDBContext.Cars
            //        group car by car.Manufacturer into manufacturer
            //          select new
            //          {
            //              Name = manufacturer.Key,
            //              Cars = (from car in manufacturer
            //                      orderby car.Combined descending
            //                      select car).Take(2)
            //          };

            query = from car in appDBContext.Cars.AsEnumerable()
                         group car by car.Manufacturer into manufacturer
                         orderby manufacturer.Key
                         select new
                         {
                             Name = manufacturer.Key,
                             Cars = (from car in manufacturer
                                     orderby car.Combined descending
                                     select car).Take(2)
                         };

            foreach (var group in query)
            {
                Console.WriteLine(group.Name);
                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }
            
        }
    }
}
