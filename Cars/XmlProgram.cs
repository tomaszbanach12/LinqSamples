using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Cars
{
    class XmlProgram
    {
        public static void LinqWithXml()
        {
            Console.WriteLine("****LINQ WITH XML****");

            Console.WriteLine("****Build element oriented xml file (longer version)****");
            var records = ProcessMethods.ProcessCarFileByExtensionMethod("fuel.csv");
            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var item in records)
            {
                var car = new XElement("Car");
                var name = new XElement("Name", item.Name);
                var combined = new XElement("Combine", item.Combined);

                cars.Add(car);
                cars.Add(name);
                cars.Add(combined);
            }
            document.Add(cars);
            document.Save("fuel.xml");
                
        }
    }
}
