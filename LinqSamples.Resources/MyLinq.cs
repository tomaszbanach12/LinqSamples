using System;
using System.Collections.Generic;

namespace LinqSamples.Resources
{
    public static class MyLinq
    {
        public static int MineCount<T>(this IEnumerable<T> sequence)
        {
            var count = 0;
            foreach (var item in sequence)
            {
                count += 1;
            }

            return count;
        }

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
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
                                                Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
