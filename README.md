# qualified-name-benchmarks
small c# project to micro-benchmark a small method to check for valid strings.

# results

results from 2021-08-05 on Intel(R) Core(TM) i7-10610U CPU @ 1.80GHz, 2304 Mhz, 4 Core(s), 8 Logical Processor(s)


|                       Method |        Mean |     Error |    StdDev |      Median |  Gen 0 |  Allocated |
|----------------------------- |------------:|----------:|----------:|------------:|-------:|-----------:|
|             IsQualifiedName2 |    68.16 ns |  0.437 ns |  0.341 ns |    68.08 ns |      - |          - |
|         IsQualifiedNameSplit | 1,140.59 ns | 34.925 ns | 97.934 ns | 1,111.17 ns | 0.5932 |    2,488 B |
|  IsQualifiedName_WithScanner |   285.35 ns | 13.754 ns | 40.337 ns |   271.05 ns |      - |          - |
| IsQualifiedName_WithScanner2 |   235.36 ns |  2.546 ns |  1.987 ns |   234.68 ns |      - |          - |
