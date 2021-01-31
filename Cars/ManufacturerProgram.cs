using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class ManufacturerProgram
    {
        public static void LinqOnManufacturers()
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

            Console.WriteLine("****List cars count group by manufacturers with query method syntax****");
            var selectedCars = from car in cars
                               group car by car.Manufacturer.ToUpper()
                               into manufacturer orderby manufacturer.Key
                               select manufacturer;

            foreach (var group in selectedCars)
            {
                Console.WriteLine($"{ group.Key } produced { group.Count() } cars");
            }

            Console.WriteLine("****List cars count group by manufacturers with extension method syntax****");
            selectedCars = cars.GroupBy(c => c.Manufacturer.ToUpper()).OrderBy(g => g.Key);

            foreach (var group in selectedCars)
            {
                Console.WriteLine($"{ group.Key } produced { group.Count() } cars");
            }

            Console.WriteLine("****Finding the top 2 most fuel efficent cars grouped by manufacturers****");

            foreach (var group in selectedCars)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{ item.Name } : { item.Combined }");
                }
                
            }
        }
    }
}
