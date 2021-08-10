# qualified-name-benchmarks
small c# project to micro-benchmark a small method to check for valid strings.

# results

results from 2021-08-05


|                      Method |      Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----------:|----------:|----------:|-------:|------:|------:|----------:|
|            IsQualifiedName2 |  58.54 ns |  1.127 ns |  1.298 ns |      - |     - |     - |         - |
|        IsQualifiedNameSplit | 836.87 ns | 16.752 ns | 38.153 ns | 0.3595 |     - |     - |   1,504 B |
| IsQualifiedName_WithScanner | 190.27 ns |  3.482 ns |  2.718 ns |      - |     - |     - |         - |