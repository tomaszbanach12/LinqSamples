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
            XmlMethods.CreateXmlByForeachMethod(records, fileName);

            Console.WriteLine("****Build element oriented xml file with functional construction (query method version)****");
            fileName = "fuel_by_query_method.xml";
            XmlMethods.CreateXmlByQueryMethod(records, fileName);

            Console.WriteLine("****Build element oriented xml file with functional construction (extension method version)****");
            fileName = "fuel_by_extension_method.xml";
            XmlMethods.CreateXmlByExtensionMethod(records, fileName);
            
            Console.WriteLine("****Build element oriented xml file with functional construction and namespace (extension method version)****");
            var ns = "http://github.com/cars/2021";
            var ex = "http://github.com/cars/2021/ex";
            fileName = "fuel_with_namespace_by_extension_method.xml";
            XmlMethods.CreateXmlWithNamespaceByExtensionMethod(records, fileName, ns, ex);

            Console.WriteLine("****Get xml attribute by elements and namespace where manufacturer is BMW (query method version)****");
            fileName = "fuel_with_namespace_by_extension_method.xml";
            var xAttributes = XmlMethods.GetXmlAttributesByElementsByNamespaceUsingQueryMethod(fileName, "BMW", ns, ex);
            foreach (var name in xAttributes)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("****Get xml attribute by elements where manufacturer is BMW (query method version)****");
            fileName = "fuel.xml";
            xAttributes = XmlMethods.GetXmlAttributesByElementsUsingQueryMethod(fileName, "BMW");
            foreach (var name in xAttributes)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("****Get xml attribute by descendants where manufacturer is BMW (query method version)****");
            fileName = "fuel.xml";
            xAttributes = XmlMethods.GetXmlAttributesByDescendantsUsingQueryMethod(fileName, "BMW");
            foreach (var name in xAttributes)
            {
                Console.WriteLine(name);
            }
        }
    }
}
