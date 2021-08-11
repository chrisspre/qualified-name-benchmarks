using BenchmarkDotNet.Running;


namespace IsQualifiedName
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Benchmarks).Assembly);
        }
    }

}