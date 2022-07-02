using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LinqSamples.Cars
{
    class LinqWithXml
    {
        public static void LinqOnXml()
        {
            Console.WriteLine("****LINQ WITH XML****");

            var records = LinqWithCarsMethods.ProcessCarFileByExtensionMethod("fuel.csv");

            Console.WriteLine("****Build element oriented xml file with functional construction (foreach version)****");
            var fileName = "fuel.xml";
            LinqWithXmlMethods.CreateXmlByForeachMethod(records, fileName);

            Console.WriteLine("****Build element oriented xml file with functional construction (query method version)****");
            fileName = "fuel_by_query_method.xml";
            LinqWithXmlMethods.CreateXmlByQueryMethod(records, fileName);

            Console.WriteLine("****Build element oriented xml file with functional construction (extension method version)****");
            fileName = "fuel_by_extension_method.xml";
            LinqWithXmlMethods.CreateXmlByExtensionMethod(records, fileName);
            
            Console.WriteLine("****Build element oriented xml file with functional construction and namespace (extension method version)****");
            var ns = "http://github.com/cars/2021";
            var ex = "http://github.com/cars/2021/ex";
            fileName = "fuel_with_namespace_by_extension_method.xml";
            LinqWithXmlMethods.CreateXmlWithNamespaceByExtensionMethod(records, fileName, ns, ex);

            Console.WriteLine("****Get xml attribute by elements and namespace where manufacturer is BMW (query method version)****");
            fileName = "fuel_with_namespace_by_extension_method.xml";
            var xAttributes = LinqWithXmlMethods.GetXmlAttributesByElementsByNamespaceUsingQueryMethod(fileName, "BMW", ns, ex);
            foreach (var name in xAttributes)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("****Get xml attribute by elements where manufacturer is BMW (query method version)****");
            fileName = "fuel.xml";
            xAttributes = LinqWithXmlMethods.GetXmlAttributesByElementsUsingQueryMethod(fileName, "BMW");
            foreach (var name in xAttributes)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("****Get xml attribute by descendants where manufacturer is BMW (query method version)****");
            fileName = "fuel.xml";
            xAttributes = LinqWithXmlMethods.GetXmlAttributesByDescendantsUsingQueryMethod(fileName, "BMW");
            foreach (var name in xAttributes)
            {
                Console.WriteLine(name);
            }
        }
    }
}
