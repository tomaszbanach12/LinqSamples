using System;
using System.Linq;

namespace Cars
{
    class CarProgram
    {
        public static void LinqOnCars()
        {
            Console.WriteLine("****LINQ ON CARS****");
            Console.WriteLine("****Show 15 car names with extension method syntax****");
            var cars = ProcessMethods.ProcessCarFileByExtensionMethod("fuel.csv");

            foreach (var car in cars.Take(15))
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("****Show 15 car names with query method syntax****");
            cars = ProcessMethods.ProcessCarFileByQueryMethod("fuel.csv");

            foreach (var car in cars.Take(15))
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
                Console.WriteLine($"{car.Manufacturer} {car.Name}: {car.Combined}");
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars by manufacturer and year with query method syntax****");
            query =
                from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name ascending
                select car;

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name}: {car.Combined}");
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

            Console.WriteLine("****Show 15 car names with custom extension method ToCar****");
            cars = ProcessMethods.ProcessCarFileByExtensionMethodCalledToCar("fuel.csv");

            foreach (var car in cars.Take(15))
            {
                Console.WriteLine(car.Name);
            }

            Console.WriteLine("****Finding the top 10 most fuel efficent cars by manufacturer and year by projection with anonymous type****");
            var queryFromProjection =
                    from car in cars
                    where car.Manufacturer == "BMW" && car.Year == 2016
                    orderby car.Combined descending, car.Name ascending
                    select new
                    {
                        car.Manufacturer,
                        car.Name,
                        car.Combined
                    };

            foreach (var car in queryFromProjection.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name}: {car.Combined}");
            }

            Console.WriteLine("****Show 15 car names by projection with anonymous type****");
            queryFromProjection =
                cars.Select(c => new
                {
                    c.Manufacturer,
                    c.Name,
                    c.Combined
                });

            foreach (var car in query.Take(15))
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name}: {car.Combined}");
            }

            Console.WriteLine("****Show 2 car names and split it by characters by two foreach loops****");
            var queryTwoLoops = cars.Select(c => c.Name);

            foreach (var name in queryTwoLoops.Take(2))
            {
                foreach (var character in name)
                {
                    Console.WriteLine(character);
                }
            }

            Console.WriteLine("****Show 2 car names and split it by characters by flat data with SelectMany****");
            var querySelectMany = cars.Take(2).SelectMany(c => c.Name);

            foreach (var character in querySelectMany)
            {
                Console.WriteLine(character);
            }
        }
    }
}
