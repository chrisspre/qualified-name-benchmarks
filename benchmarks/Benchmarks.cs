using BenchmarkDotNet.Attributes;

namespace IsQualifiedName
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Params("aaaa.bbbb", "aaaa.", ".aaaa", "a. b1bbb", "a. .b")]
        public string Text;

        [Benchmark]
        public bool IsQualifiedName2() => Program.IsQualifiedName2(Text);

        [Benchmark]
        public bool IsQualifiedName_WithScanner() => Program.IsQualifiedNameScanner(Text);
    }
}
