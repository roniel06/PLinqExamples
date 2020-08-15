using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plinq1.Services
{
    /// <summary>
    /// This is a Static class with methods
    /// based on Microsoft Documentation 
    /// <see cref="https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/introduction-to-plinq?source=docs"/>   
    /// </summary>
    public sealed class PlinqFunctions
    {
        private static IEnumerable<int> sourceRange = Enumerable.Range(1, 10000); //Global Range for Testing

        public static void ExecutionExample()
        {
            var watch = new System.Diagnostics.Stopwatch();
            var evenNums = from num in sourceRange.AsParallel()
                           where num % 2 == 0
                           select num;
            watch.Stop();
            Console.WriteLine($"{evenNums.Count()} even numbers out of  {sourceRange.Count()} total \n");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }

        /// <summary>
        /// This Method uses a grade of Parallelism
        /// that means that you can set the ammount 
        /// of processors of the host computer to use
        /// </summary>
        /// <param name="numberOfProcessors"></param>
        public static void UseDegreeOfParallelism(int numberOfProcessors)
        {
            var watch = new System.Diagnostics.Stopwatch();
            var result = from item in sourceRange.AsParallel().WithDegreeOfParallelism(numberOfProcessors)
                         where item > 42
                         select item;
            watch.Stop();
            Console.WriteLine($"{result.Count()}");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }

        public static void EvenNumbersOrderedOrUnordered()
        {
            var watch = new System.Diagnostics.Stopwatch();
            var evenNums = from num in sourceRange.AsParallel()
                           .AsOrdered()
                           //.AsUnordered()
                           where num % 2 == 0
                           select num;
            watch.Stop();
            Console.WriteLine($"{evenNums.Count()} even numbers out of  {sourceRange.Count()} total");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }



    }
}
