using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Cars
{
    public static class XmlMethods
    {
        public static void GetXmlAttributeByQueryMethod(string path, string manufacturer)
        {
            var document = XDocument.Load(path);

            var query =
                from element in document.Element("Cars").Elements("Car")
                where element.Attribute("Manufacturer").Value == manufacturer
                select element.Attribute("Name");
        }


        public static void CreateXmlByForeachMethod(List<Car> records, string path)
        {
            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var record in records)
            {
                var car = new XElement("Car",
                                       new XAttribute("Name", record.Name),
                                       new XAttribute("Combined", record.Combined),
                                       new XAttribute("Manufacturer", record.Manufacturer));

                cars.Add(car);
            }
            document.Add(cars);
            document.Save(path);
        }
        public static void CreateXmlByQueryMethod(List<Car> records, string path)
        {
            var document = new XDocument();
            var cars = new XElement("Cars");

            var elements = from record in records
                           select new XElement("Car",
                                               new XAttribute("Name", record.Name),
                                               new XAttribute("Combined", record.Combined),
                                               new XAttribute("Manufacturer", record.Manufacturer));

            cars.Add(elements);

            document.Add(cars);
            document.Save(path);
        }
        public static void CreateXmlByExtensionMethod(List<Car> records, string path)
        {
            var document = new XDocument();
            var cars = new XElement("Cars");

            var elements = records.Select(record => new XElement("Car",
                                                             new XAttribute("Name", record.Name),
                                                             new XAttribute("Combined", record.Combined),
                                                             new XAttribute("Manufacturer", record.Manufacturer)));


            cars.Add(elements);

            document.Add(cars);
            document.Save(path);
        }
    }
}