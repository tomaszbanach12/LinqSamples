using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "Forest Gump", Rating = 8.5f, Year = 1994 },
                new Movie { Title = "Avatar", Rating = 7.4f, Year = 2009 },
                new Movie { Title = "Saving Private Ryan", Rating = 8.1f, Year = 1998 },
                new Movie { Title = "Cast Away", Rating = 7.5f, Year = 2000 }
            };
            Console.WriteLine("****Custom Filter [defered execution] operator writed in extension method syntax****");
            // Custom Filter operator which uses deferred execution with yield return
            // that runs the same as Linq query
            // Query does no real work until we force the query to produce a result 
            var query = movies.Filter(x => x.Year > 1999);
            var enumerator = query.GetEnumerator();

            // Produce result that force execution
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.WriteLine("****Count [immediate execution] operator writed in extension method syntax****");
            // Count operator which uses immediate execution with yield return
            Console.WriteLine(query.Count());

            Console.WriteLine("****Where [deferred streaming execution] operator writed in extension method syntax****");
            // Count operator which uses deferred streaming execution with yield return
            query = movies.Where(x => x.Year > 1999);
            enumerator = query.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.WriteLine("****Where [deferred streaming execution] and then ToList [immediate execution] operators writed in extension method syntax****");
            // Where operator which uses deferred streaming execution with yield return command
            // but ended with ToList which uses immediate execution with simple return command
            query = movies.Where(x => x.Year > 1999).ToList();
            enumerator = query.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.WriteLine("****Where [deferred streaming execution] and then OrderByDescending [deferred non-streaming execution] operators writed in extension method syntax****");
            // Where operator which uses deferred streaming execution with yield return command
            // but ended with OrderByDescending which uses deferred non-streaming execution with yield return command
            query = movies.Where(x => x.Year > 1999).OrderByDescending(m => m.Rating);
            enumerator = query.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.WriteLine("****Where [deferred streaming execution] and then order by descending [deferred non-streaming execution] operators writed in query syntax****");
            // Where operator which uses deferred streaming execution with yield return command
            // but ended with order by descending which uses deferred non-streaming execution with yield return command
            query = from movie in movies
                    where movie.Year > 1999
                    orderby movie.Rating descending
                    select movie;
            enumerator = query.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.WriteLine("****Call InfiniteRandom() method which is infinite loop that stopped after taking 10 elements****");

            var numbers = MyLinq.InfiniteRandom().Where(x => x > 50).Take(10);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            // Sum Up
            // 1 [immediate execution] means that the data source is read and the operation 
            // is performed at the point in the code where the query is declared.
            // 2 [deferred execution] means that the operation is not performed at the point in the code
            // where the query is declared. The operation is performed only when the query variable is enumerated 
            // 3 [streaming operators] do not have to read all the source data before they can yield a result element.
            // 4 [non-streaming operators] must read all the source data before they can yield a result element.
        }
    }
}
