using System;
using System.Linq;


namespace Plinq1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceRange = Enumerable.Range(1, 10000);
            var evenNums = from num in sourceRange.AsParallel()
                           where num % 2 == 0
                           select num;
            Console.WriteLine($"{evenNums.Count()} even numbers out of  {sourceRange.Count()} total");
        }
    }
}
