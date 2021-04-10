using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqSamples.Cars
{
    public static class LinqWithCarsMethods
    {
        public static List<Car> ProcessCarFileByExtensionMethod(string path)
        {
            var query = File.ReadAllLines(path)
                            .Skip(1)
                            .Where(l => l.Length > 1)
                            .Select(Car.ParseFromCsv);

            return query.ToList();
        }
        public static List<Manufacturer> ProcessManufacturersFileByExtensionMethod(string path)
        {
            var query = File.ReadAllLines(path)
                            .Skip(1)
                            .Where(l => l.Length > 1)
                            .Select(Manufacturer.ParseFromCsv);

            return query.ToList();
        }
        public static List<Car> ProcessCarFileByExtensionMethodCalledToCar(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

            return query.ToList();
        }
        public static List<Car> ProcessCarFileByQueryMethod(string path)
        {
            var query = from l in File.ReadAllLines(path)
                        .Skip(1)
                        where l.Length > 1
                        select Car.ParseFromCsv(l);

            return query.ToList();
        }
    }
}