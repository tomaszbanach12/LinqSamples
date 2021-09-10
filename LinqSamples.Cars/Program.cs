using LinqSamples.Cars.Linq;
using System;
using System.Linq.Expressions;

namespace LinqSamples.Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqWithCars.LinqOnCars();

            LinqWithCarsAndManufacturers.LinqOnCarsAndManufacturers();

            LinqWithXml.LinqOnXml();

            LinqWithEntityFramework.InsertData();

            LinqWithEntityFramework.LinqWithQueryMethodSyntax();

            LinqWithEntityFramework.LinqWithExtensionMethodSyntax();

            LinqWithEntityFramework.LinqWithManufacturerWithExtensionMethodSyntax();

            LinqWithIQueryablesAndExpressionTrees.IQueryablesAndExpressionTrees();

            LinqWithCaveatsAndPitfalls.LinqOnCaveatsAndPitfalls();

            LinqWithAdvancedLinqQuery.LinqOnAdvancedLinqQuery();
        }
    }
}
