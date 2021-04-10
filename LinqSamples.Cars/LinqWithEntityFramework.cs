using System;
using System.Linq;

namespace LinqSamples.Cars
{
    public static class LinqWithEntityFramework
    {
        public static void InsertData()
        {
            Console.WriteLine("****Inserting data into Cars table with extension method syntax****");

            var cars = ProcessMethods.ProcessCarFileByExtensionMethod("fuel.csv");
            var appDBContext = new AppDbContext();

            foreach (var car in cars)
            {
                var exist = appDBContext.Cars
                        .Any(e => e.Manufacturer == car.Manufacturer &&
                        e.Name == car.Name &&
                        e.Year == car.Year);

                if (!exist)
                {
                    appDBContext.Cars.Add(car);
                }
            }

            if (appDBContext.ChangeTracker.HasChanges())
                appDBContext.SaveChanges();
        }

        public static void LinqWithExtensionMethodSyntax()
        {
            Console.WriteLine("****Finding the top 10 most fuel efficent cars with extension method syntax****");

            var appDBContext = new AppDbContext();

            var query = appDBContext.Cars
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name)
                .Take(10);

            foreach (var car in query)
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }
        }

        public static void LinqWithManufacturerWithExtensionMethodSyntax()
        {
            Console.WriteLine("****Finding the top 10 most fuel efficent cars by manufacturer with extension method syntax****");

            var appDBContext = new AppDbContext();

            var query = appDBContext.Cars
                .Where(c => c.Manufacturer == "BMW")
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name)
                .Take(10);

            foreach (var car in query)
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }
        }

        public static void LinqWithQueryMethodSyntax()
        {
            Console.WriteLine("****Finding the top 10 most fuel efficent cars with query method syntax****");

            var appDBContext = new AppDbContext();

            var query = from car in appDBContext.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }
        }
    }
}
