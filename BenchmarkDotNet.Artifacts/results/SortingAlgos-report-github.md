```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.1.1 (23B81) [Darwin 23.1.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 7.0.16 (7.0.1624.6629), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 7.0.16 (7.0.1624.6629), Arm64 RyuJIT AdvSIMD


```
| Method             | Mean         | Error     | StdDev    | Allocated |
|------------------- |-------------:|----------:|----------:|----------:|
| InsertionSort      |     964.2 ns |   2.98 ns |   2.79 ns |         - |
| SelectionSort      | 329,143.9 ns | 321.69 ns | 251.16 ns |         - |
| QuickSort          |   3,945.3 ns |  13.81 ns |  12.24 ns |         - |
| QuickSortClassical |  41,928.2 ns |  74.49 ns |  69.68 ns |         - |
