using System;
using System.Collections.Generic;
using System.Text;

namespace CarsEF
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Headquater { get; set; }
        public int Year { get; set; }

        internal static Manufacturer ParseFromCsv(string line)
        {
            var columns = line.Split(',');

            return new Manufacturer
            {
                Name = columns[0],
                Headquater = columns[1],
                Year = int.Parse(columns[2])
            };
        }
    }
}
