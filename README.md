# qualified-name-benchmarks
small c# project to micro-benchmark a small method to check for valid strings.

# results

results from 2021-08-05 on Intel(R) Core(TM) i7-10610U CPU @ 1.80GHz, 2304 Mhz, 4 Core(s), 8 Logical Processor(s)



|                       Method |      Mean |     Error |     StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |----------:|----------:|-----------:|-------:|------:|------:|----------:|
|             IsQualifiedName2 |  56.43 ns |  0.921 ns |   0.719 ns |      - |     - |     - |         - |
|         IsQualifiedNameSplit | 917.22 ns | 50.991 ns | 142.143 ns | 0.3595 |     - |     - |   1,504 B |
|  IsQualifiedName_WithScanner | 204.25 ns |  4.624 ns |  12.890 ns |      - |     - |     - |         - |
| IsQualifiedName_WithScanner2 | 247.56 ns |  5.007 ns |   9.404 ns |      - |     - |     - |         - |