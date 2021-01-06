using System;
using System.Collections.Generic;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "Forest Gump", Rating = 8.9f, Year = 1994 },
                new Movie { Title = "Léon", Rating = 8.1f, Year = 1994 },
                new Movie { Title = "Saving Private Ryan", Rating = 8.1f, Year = 1998 },
                new Movie { Title = "Cast Away", Rating = 7.5f, Year = 2000 }
            };
        }
    }
}
