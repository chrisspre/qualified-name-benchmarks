# qualified-name-benchmarks
small c# project to micro-benchmark a small method to check for valid strings.

# results

results from 2021-08-05

```

|                      Method |      Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----------:|----------:|----------:|-------:|------:|------:|----------:|
|            IsQualifiedName2 |  63.17 ns |  0.299 ns |  0.249 ns |      - |     - |     - |         - |
|        IsQualifiedNameSplit | 839.96 ns | 15.444 ns | 17.786 ns | 0.0868 |     - |     - |   1,504 B |
| IsQualifiedName_WithScanner | 158.76 ns |  2.543 ns |  2.254 ns |      - |     - |     - |         - |
```