using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class CarsAndManufacturersProgram
    {
        public static void LinqOnCarsAndManufacturers()
        {
            Console.WriteLine("****LINQ ON MANUFACTURERS****");

            Console.WriteLine("****Finding the top 10 most fuel efficent cars and thier headquaters with join data with query method syntax****");
            var cars = ProcessMethods.ProcessCarFileByExtensionMethod("fuel.csv");
            var manufacturers = ProcessMethods.ProcessManufacturersFileByExtensionMethod("manufacturers.csv");

            var query =
                from car in cars
                join manufacturer in manufacturers
                on car.Manufacturer equals manufacturer.Name
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Name,
                    CarName = car.Name,
                    manufacturer.Headquater,
                    car.Combined
                };

            foreach (var item in query.Take(10))
            {
                Console.WriteLine($"{item.Name} {item.CarName} {item.Headquater} : {item.Combined} ");
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars and thier headquaters with join data with extension method syntax****");
            query =
                cars.Join(manufacturers,
                            c => c.Manufacturer,
                            m => m.Name,
                            (c, m) => new
                            {
                                m.Name,
                                CarName = c.Name,
                                m.Headquater,
                                c.Combined
                            }).OrderByDescending(c => c.Combined).ThenBy(c => c.CarName);

            foreach (var item in query.Take(10))
            {
                Console.WriteLine($"{item.Name} {item.CarName} {item.Headquater} : {item.Combined} ");
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars and thier headquaters with join with composite key with query method syntax****");
            query =
                from car in cars
                join manufacturer in manufacturers
                    on new { car.Manufacturer, car.Year }
                        equals
                        new { Manufacturer = manufacturer.Name, manufacturer.Year }
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Name,
                    CarName = car.Name,
                    manufacturer.Headquater,
                    car.Combined
                };

            foreach (var item in query.Take(10))
            {
                Console.WriteLine($"{item.Name} {item.CarName} {item.Headquater} : {item.Combined} ");
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars and thier headquaters with join with composite key with extension method syntax****");
            query =
                cars.Join(manufacturers,
                            c => new { c.Manufacturer, c.Year },
                            m => new { Manufacturer = m.Name, m.Year }, (c, m) => new
                            {
                                m.Name,
                                CarName = c.Name,
                                m.Headquater,
                                c.Combined
                            }).OrderByDescending(c => c.Combined).ThenBy(c => c.CarName);

            foreach (var item in query.Take(10))
            {
                Console.WriteLine($"{item.Name} {item.CarName} {item.Headquater} : {item.Combined} ");
            }

            Console.WriteLine("****List cars count by manufacturers using group with query method syntax****");
            var groupedCars = from car in cars
                              group car by car.Manufacturer.ToUpper()
                               into manufacturer
                              orderby manufacturer.Key
                              select manufacturer;

            foreach (var group in groupedCars)
            {
                Console.WriteLine($"{ group.Key } produced { group.Count() } cars");
            }

            Console.WriteLine("****List cars count by manufacturers using group with extension method syntax****");
            groupedCars = cars.GroupBy(c => c.Manufacturer.ToUpper())
                              .OrderBy(g => g.Key);

            foreach (var group in groupedCars)
            {
                Console.WriteLine($"{ group.Key } produced { group.Count() } cars");
            }

            Console.WriteLine("****Finding the top 2 most fuel efficent cars grouped by manufacturers using group****");

            foreach (var group in groupedCars)
            {
                Console.WriteLine(group.Key);
                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{ car.Name } : { car.Combined }");
                }

            }

            Console.WriteLine("****Finding the top 2 most fuel efficent cars grouped by manufacturers using group join with query method syntax****");
            var groupedJoinByOrderedByManufacturersName = from manufacturer in manufacturers
                                                          join car in cars
                                                          on manufacturer.Name.ToUpper() equals car.Manufacturer.ToUpper()
                                                            into carGroup
                                                          orderby manufacturer.Name
                                                          select new
                                                          {
                                                              Manufacturer = manufacturer,
                                                              Car = carGroup
                                                          };

            foreach (var group in groupedJoinByOrderedByManufacturersName)
            {
                Console.WriteLine($"{ group.Manufacturer.Name }: {group.Manufacturer.Headquater }");
                foreach (var car in group.Car.Take(2).OrderBy(x => x.Combined))
                {
                    Console.WriteLine($"\t { car.Name } { car.Combined }");
                }
            }

            Console.WriteLine("****Finding the top 2 most fuel efficent cars grouped by manufacturers using group join with extension method syntax****");
            groupedJoinByOrderedByManufacturersName = manufacturers.GroupJoin(cars,
                                                      m => m.Name.ToUpper(),
                                                      c => c.Manufacturer.ToUpper(),
                                                      (m, g) => new
                                                      {
                                                          Manufacturer = m,
                                                          Car = g
                                                      })
                                                      .OrderBy(m => m.Manufacturer.Name);

            foreach (var group in groupedJoinByOrderedByManufacturersName)
            {
                Console.WriteLine($"{ group.Manufacturer.Name }: { group.Manufacturer.Headquater }");
                foreach (var car in group.Car.OrderBy(g => g.Combined).Take(2))
                {
                    Console.WriteLine($"\t { car.Name } { car.Combined }");
                }
            }

            Console.WriteLine("****Finding the top 3 most fuel efficent cars grouped by countries using group join with query method syntax****");
            var groupedJoinByManufacturersOrderedByCountry = from manufacturer in manufacturers
                                                             join car in cars
                                                             on manufacturer.Name.ToUpper() equals car.Manufacturer.ToUpper()
                                                               into carGroup
                                                             orderby manufacturer.Name
                                                             select new
                                                             {
                                                                 Manufacturer = manufacturer,
                                                                 Car = carGroup
                                                             }
                                                             into result
                                                             orderby result.Manufacturer.Headquater
                                                             group result by result.Manufacturer.Headquater;

            foreach (var group in groupedJoinByManufacturersOrderedByCountry)
            {
                Console.WriteLine($"{ group.Key }");
                foreach (var car in group.SelectMany(x => x.Car).OrderByDescending(x => x.Combined).Take(3))
                {
                    Console.WriteLine($"\t{ car.Name } {car.Combined}");
                }
            }

            Console.WriteLine("****Finding the top 3 most fuel efficent cars grouped by countries using group join with extension method syntax****");
            groupedJoinByManufacturersOrderedByCountry = manufacturers.GroupJoin(cars,
                                                         m => m.Name.ToUpper(),
                                                         c => c.Manufacturer.ToUpper(),
                                                                (m, g) => new
                                                                {
                                                                    Manufacturer = m,
                                                                    Car = g
                                                                })
                                                                .GroupBy(m => m.Manufacturer.Headquater)
                                                                .OrderBy(m => m.Key);

            foreach (var group in groupedJoinByManufacturersOrderedByCountry)
            {
                Console.WriteLine($"{ group.Key }");
                foreach (var car in group.SelectMany(x => x.Car).OrderByDescending(x => x.Combined).Take(3))
                {
                    Console.WriteLine($"\t{ car.Name } {car.Combined}");
                }
            }

            Console.WriteLine("****Find the manufacturer with most fuel efficent car with query method syntax****");
            var aggregatedCars = from car in cars
                                 group car by car.Manufacturer
                                 into carGroup
                                 select new
                                 {
                                     Name = carGroup.Key.ToUpper(),
                                     Max = carGroup.Max(c => c.Combined),
                                     Min = carGroup.Min(c => c.Combined),
                                     Avg = carGroup.Average(c => c.Combined)
                                 }
                                 into result
                                 orderby result.Max descending
                                 select result;

            foreach (var result in aggregatedCars)
            {
                Console.WriteLine($"{ result.Name}");
                Console.WriteLine($"\tMax: { result.Max }");
                Console.WriteLine($"\tMin: { result.Min }");
                Console.WriteLine($"\tAvg: { result.Avg }");
            }

            Console.WriteLine("****Find the manufacturer with most fuel efficent car with extension method syntax****");
            aggregatedCars = cars.GroupBy(c => c.Manufacturer)
                                  .Select(g =>
                                  {
                                      return new
                                      {
                                          Name = g.Key.ToUpper(),
                                          Max = g.Max(c => c.Combined),
                                          Min = g.Min(c => c.Combined),
                                          Avg = g.Average(c => c.Combined)
                                      };
                                  })
                                 .OrderByDescending(g => g.Max);

            foreach (var result in aggregatedCars)
            {
                Console.WriteLine($"{ result.Name}");
                Console.WriteLine($"\tMax: { result.Max }");
                Console.WriteLine($"\tMin: { result.Min }");
                Console.WriteLine($"\tAvg: { result.Avg }");
            }

            Console.WriteLine("****Find the manufacturer with most fuel efficent car with aggregating extension method syntax****");
            var sasggregatedCars = cars.GroupBy(c => c.Manufacturer)
                                  .Select(g =>
                                  {
                                      var results = g.Aggregate(new CarStatistics(),
                                                                (acc, c) => acc.Accumulate(c),
                                                                acc => acc.Compute());
                                      return new
                                      {
                                          Name = g.Key.ToUpper(),
                                          Max = results.Average,
                                          Min = results.Min,
                                          Avg = results.Max
                                      };
                                  })
                                 .OrderByDescending(g => g.Max);

            foreach (var result in aggregatedCars)
            {
                Console.WriteLine($"{ result.Name}");
                Console.WriteLine($"\tMax: { result.Max }");
                Console.WriteLine($"\tMin: { result.Min }");
                Console.WriteLine($"\tAvg: { result.Avg }");
            }
        }
    }
}
