using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Cars
{
    class XmlProgram
    {
        public static void LinqWithXml()
        {
            Console.WriteLine("****LINQ WITH XML****");

            var records = ProcessMethods.ProcessCarFileByExtensionMethod("fuel.csv");

            Console.WriteLine("****Build element oriented xml file with functional construction (foreach version)****");
            var fileName = "fuel.xml";
            XmlMethods.CreateXmlByExtensionMethod(records, fileName);

            Console.WriteLine("****Build element oriented xml file with functional construction (query method version)****");
            var fileName2 = "fuel_by_query_method.xml";
            XmlMethods.CreateXmlByQueryMethod(records, fileName2);

            Console.WriteLine("****Build element oriented xml file with functional construction (extension method version)****");
            var fileName3 = "fuel_by_extension_method.xml";
            XmlMethods.CreateXmlByExtensionMethod(records, fileName3);

            var document = XDocument.Load(fileName);
        }
    }
}
