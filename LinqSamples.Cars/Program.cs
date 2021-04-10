using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqSamples.Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqWithEntityFramework.InsertData();

            LinqWithEntityFramework.LinqWithQueryMethodSyntax();

            LinqWithEntityFramework.LinqWithExtensionMethodSyntax();    

            LinqWithEntityFramework.LinqWithManufacturerWithExtensionMethodSyntax();
            LinqWithCars.LinqOnCars();

            LinqWithCarsAndManufacturers.LinqOnCarsAndManufacturers();

            LinqWithXml.LinqOnXml();
        }

        
    }
}
