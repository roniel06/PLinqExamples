using Plinq1.Services;


namespace Plinq1
{
    class Program
    {
        static void Main(string[] args)
        {
            //PlinqFunctions.ExecutionExample();

            PlinqFunctions.UseDegreeOfParallelism(1);
        }
    }
}
