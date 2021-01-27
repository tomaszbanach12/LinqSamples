using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            CarProgram.LinqOnCars();

            ManufacturerProgram.LinqOnManufacturers();
        }
    }
}
