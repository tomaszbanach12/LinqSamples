using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queries
{
    public static class MyLinq
    {
        //Infinite method which uses deffered execution with yield return
        public static IEnumerable<int> InfiniteRandom()
        {
            var random = new Random();
            while (true)
            {
                yield return random.Next();
            }
        }

        // Custom Filter operator which uses deffered execution with yield return
        public static IEnumerable<T> Filter<T> (this IEnumerable<T> source,
                                                Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if(predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
