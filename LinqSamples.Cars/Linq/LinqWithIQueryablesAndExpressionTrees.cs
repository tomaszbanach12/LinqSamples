using System;
using System.Linq.Expressions;

namespace LinqSamples.Cars
{
    public static class LinqWithIQueryablesAndExpressionTrees
    {

        public static void IQueryablesAndExpressionTrees()
        {
            Console.WriteLine("****Execute add****");
            Func<int, int, int> add1 = (x, y) => (x + y);
            Console.WriteLine(add1(3, 5));

            Console.WriteLine("****Show add variable itself (c# turns expression into a method)****");
            Console.WriteLine(add1);

            Console.WriteLine("****To execute add now we must compile that expresion****");
            Expression<Func<int, int, int>> add2 = (x, y) => (x + y);
            Func<int, int, int> addInvokable = add2.Compile();
            Console.WriteLine(addInvokable(3, 5));

            Console.WriteLine("****Show add expression tree itself (that expression tree have a body)****");
            Console.WriteLine(add1);

            // Expression trees represent code in a tree-like data structure, where each node is an expression, 
            // for example, a method call or a binary operation such as x<y.
            // You can compile and run code represented by expression trees. This enables dynamic modification of executable code, 
            // the execution of LINQ queries in various databases, and the creation of dynamic queries.
        }
    }
}