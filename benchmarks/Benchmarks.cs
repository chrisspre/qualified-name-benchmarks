using BenchmarkDotNet.Attributes;

namespace IsQualifiedName
{

    [MemoryDiagnoser]
    public class Benchmarks
    {
        private static string[] tests = new[] { "aaaa.bbbb", "aaaa.", ".aaaa", "a. b1bbb", "a. .b" };


        [Benchmark]
        public int IsQualifiedName2()
        {
            for (int i = 0; i < tests.Length; i++)
            {
                Program.IsQualifiedName2(tests[i]);
            }
            return 0;
        }

        [Benchmark]
        public int IsQualifiedName_WithScanner()
        {
            for (int i = 0; i < tests.Length; i++)
            {
                Program.IsQualifiedNameScanner(tests[i]);
            }
            return 0;
        }
    }
}
