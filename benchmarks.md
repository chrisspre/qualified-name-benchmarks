BenchmarkDotNet=v0.13.0, OS=Windows 10.0.22000
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.7.21377.35
  [Host]     : .NET 6.0.0 (6.0.21.37712), X64 RyuJIT
  Job-KHSLZJ : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  Job-TYHWZH : .NET 6.0.0 (6.0.21.37712), X64 RyuJIT
  Job-RICJQR : .NET Core 3.1.18 (CoreCLR 4.700.21.35901, CoreFX 4.700.21.36305), X64 RyuJIT
  Job-NSCMYT : .NET Framework 4.8 (4.8.4400.0), X64 RyuJIT


|                      Method |            Runtime |      Text |      Mean | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------------------- |---------- |----------:|------:|------:|------:|------:|----------:|
|            IsQualifiedName2 |           .NET 5.0 |     .aaaa |  3.075 ns |  0.70 |     - |     - |     - |         - |
|            IsQualifiedName2 |           .NET 6.0 |     .aaaa |  2.597 ns |  0.62 |     - |     - |     - |         - |
|            IsQualifiedName2 |      .NET Core 3.1 |     .aaaa |  3.262 ns |  0.75 |     - |     - |     - |         - |
|            IsQualifiedName2 | .NET Framework 4.8 |     .aaaa |  4.704 ns |  1.00 |     - |     - |     - |         - |
|                             |                    |           |           |       |       |       |       |           |
| IsQualifiedName_WithScanner |           .NET 5.0 |     .aaaa |  6.890 ns |  0.33 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |           .NET 6.0 |     .aaaa |  6.782 ns |  0.32 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |      .NET Core 3.1 |     .aaaa |  7.339 ns |  0.35 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner | .NET Framework 4.8 |     .aaaa | 21.549 ns |  1.00 |     - |     - |     - |         - |
|                             |                    |           |           |       |       |       |       |           |
|            IsQualifiedName2 |           .NET 5.0 |     a. .b | 10.284 ns |  0.87 |     - |     - |     - |         - |
|            IsQualifiedName2 |           .NET 6.0 |     a. .b | 10.131 ns |  0.77 |     - |     - |     - |         - |
|            IsQualifiedName2 |      .NET Core 3.1 |     a. .b |  9.743 ns |  0.79 |     - |     - |     - |         - |
|            IsQualifiedName2 | .NET Framework 4.8 |     a. .b | 12.385 ns |  1.00 |     - |     - |     - |         - |
|                             |                    |           |           |       |       |       |       |           |
| IsQualifiedName_WithScanner |           .NET 5.0 |     a. .b | 29.222 ns |  0.53 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |           .NET 6.0 |     a. .b | 26.557 ns |  0.49 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |      .NET Core 3.1 |     a. .b | 31.024 ns |  0.56 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner | .NET Framework 4.8 |     a. .b | 55.415 ns |  1.00 |     - |     - |     - |         - |
|                             |                    |           |           |       |       |       |       |           |
|            IsQualifiedName2 |           .NET 5.0 |  a. b1bbb | 12.262 ns |  0.46 |     - |     - |     - |         - |
|            IsQualifiedName2 |           .NET 6.0 |  a. b1bbb | 17.674 ns |  0.67 |     - |     - |     - |         - |
|            IsQualifiedName2 |      .NET Core 3.1 |  a. b1bbb | 22.939 ns |  0.86 |     - |     - |     - |         - |
|            IsQualifiedName2 | .NET Framework 4.8 |  a. b1bbb | 26.462 ns |  1.00 |     - |     - |     - |         - |
|                             |                    |           |           |       |       |       |       |           |
| IsQualifiedName_WithScanner |           .NET 5.0 |  a. b1bbb | 40.198 ns |  0.48 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |           .NET 6.0 |  a. b1bbb | 39.722 ns |  0.49 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |      .NET Core 3.1 |  a. b1bbb | 43.136 ns |  0.52 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner | .NET Framework 4.8 |  a. b1bbb | 83.661 ns |  1.00 |     - |     - |     - |         - |
|                             |                    |           |           |       |       |       |       |           |
|            IsQualifiedName2 |           .NET 5.0 |     aaaa. | 11.461 ns |  0.64 |     - |     - |     - |         - |
|            IsQualifiedName2 |           .NET 6.0 |     aaaa. | 11.406 ns |  0.63 |     - |     - |     - |         - |
|            IsQualifiedName2 |      .NET Core 3.1 |     aaaa. | 14.984 ns |  0.84 |     - |     - |     - |         - |
|            IsQualifiedName2 | .NET Framework 4.8 |     aaaa. | 17.682 ns |  1.00 |     - |     - |     - |         - |
|                             |                    |           |           |       |       |       |       |           |
| IsQualifiedName_WithScanner |           .NET 5.0 |     aaaa. | 25.990 ns |  0.48 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |           .NET 6.0 |     aaaa. | 24.998 ns |  0.46 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |      .NET Core 3.1 |     aaaa. | 28.249 ns |  0.52 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner | .NET Framework 4.8 |     aaaa. | 54.650 ns |  1.00 |     - |     - |     - |         - |
|                             |                    |           |           |       |       |       |       |           |
|            IsQualifiedName2 |           .NET 5.0 | aaaa.bbbb | 20.044 ns |  0.67 |     - |     - |     - |         - |
|            IsQualifiedName2 |           .NET 6.0 | aaaa.bbbb | 19.847 ns |  0.67 |     - |     - |     - |         - |
|            IsQualifiedName2 |      .NET Core 3.1 | aaaa.bbbb | 26.991 ns |  0.92 |     - |     - |     - |         - |
|            IsQualifiedName2 | .NET Framework 4.8 | aaaa.bbbb | 30.160 ns |  1.00 |     - |     - |     - |         - |
|                             |                    |           |           |       |       |       |       |           |
| IsQualifiedName_WithScanner |           .NET 5.0 | aaaa.bbbb | 38.504 ns |  0.48 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |           .NET 6.0 | aaaa.bbbb | 39.918 ns |  0.49 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner |      .NET Core 3.1 | aaaa.bbbb | 38.461 ns |  0.47 |     - |     - |     - |         - |
| IsQualifiedName_WithScanner | .NET Framework 4.8 | aaaa.bbbb | 80.874 ns |  1.00 |     - |     - |     - |         - |
