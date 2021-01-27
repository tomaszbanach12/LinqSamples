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

            var query = from car in cars
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
        }
    }
}
