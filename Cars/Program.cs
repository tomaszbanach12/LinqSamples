using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Show 30 car names with extension method syntax****");
            var cars = ProcessFileByExtensionMethod("fuel.csv");

            foreach (var car in cars.Take(30))
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("****Show 30 car names with query method syntax****");
            cars = ProcessFileByQueryMethod("fuel.csv");

            foreach (var car in cars.Take(30))
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars with extension method syntax****");
            var query =
                cars.OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars with query method syntax****");
            query =
                from car in cars
                orderby car.Combined descending, car.Name ascending
                select car;

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars by manufacturer with extension method syntax****");
            query =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars by manufacturer and year with query method syntax****");
            query =
                from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name ascending
                select car;

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }

            Console.WriteLine("****Finding the best most fuel efficent car by manufacturer and year with extension method syntax****");
            var selectedCar =
                cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name).FirstOrDefault();

            if (selectedCar != null)
                Console.WriteLine($"{selectedCar.Name}: {selectedCar.Combined}");

            Console.WriteLine("****Is there any car manufactured by Ford****");
            var isCarManufacturedByFord = cars.Any(cars => cars.Manufacturer == "Ford");

            Console.WriteLine(isCarManufacturedByFord);

            Console.WriteLine("****Is there every car manufactured by Ford****");
            var isEveryCarManufacturedByFord = cars.All(cars => cars.Manufacturer == "Ford");

            Console.WriteLine(isEveryCarManufacturedByFord);

            Console.WriteLine("****Is there any car manufactured by BMW and produced in 2016****");
            var isCarBMWProducedIn2016 = cars.Contains(selectedCar);

            Console.WriteLine(isCarBMWProducedIn2016);
        }
        private static List<Car> ProcessFileByExtensionMethod(string path)
        {
            return
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .Select(Car.ParseFromCsv)
                    .ToList();
        }
        private static List<Car> ProcessFileByQueryMethod(string path)
        {
            var query = from l in File.ReadAllLines(path)
                        .Skip(1)
                        where l.Length > 1
                        select Car.ParseFromCsv(l);
            return query.ToList();
        } 
        private static List<Car> ProcessFileByExtensionMethodMostFuelEfficent(string path)
        {
            return
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .Select(Car.ParseFromCsv)
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name).Take(10)
                    .ToList();
        }
        private static List<Car> ProcessFileByQueryMethodMostFuelEfficent(string path)
        {
            var query = from l in File.ReadAllLines(path)
                        .Skip(1)
                        .Take(30)
                        where l.Length > 1
                        select Car.ParseFromCsv(l);
            return query.ToList();
        }
    }
}
