# Fowarding

Calling a method via another method is slower vs directly calling a method. This is 
because it requires extra overhead when trying to call the next method. If you are 
using a language with methods on objects, such as C# then it requires looking up the 
address of the class, then the method, then calling the final function. These lookups
require journeys back to main memory to find objects, so they can increase a simple
operations time to completion (string.Length in this example).

## Results

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5737/22H2/2022Update)
Intel Core i5-6400 CPU 2.70GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2


```
| Method    | N     | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD |
|---------- |------ |----------:|----------:|----------:|----------:|------:|--------:|
| **Direct**    | **1**     | **0.0287 ns** | **0.0310 ns** | **0.0331 ns** | **0.0139 ns** |     **?** |       **?** |
| Forwarder | 1     | 3.4379 ns | 0.1086 ns | 0.1250 ns | 3.4083 ns |     ? |       ? |
|           |       |           |           |           |           |       |         |
| **Direct**    | **10**    | **0.0334 ns** | **0.0284 ns** | **0.0416 ns** | **0.0202 ns** |     **?** |       **?** |
| Forwarder | 10    | 3.3775 ns | 0.1069 ns | 0.1390 ns | 3.3527 ns |     ? |       ? |
|           |       |           |           |           |           |       |         |
| **Direct**    | **100**   | **0.0323 ns** | **0.0285 ns** | **0.0399 ns** | **0.0183 ns** |     **?** |       **?** |
| Forwarder | 100   | 3.4756 ns | 0.1109 ns | 0.1277 ns | 3.4638 ns |     ? |       ? |
|           |       |           |           |           |           |       |         |
| **Direct**    | **1000**  | **0.0200 ns** | **0.0215 ns** | **0.0201 ns** | **0.0160 ns** |     **?** |       **?** |
| Forwarder | 1000  | 1.3869 ns | 0.0476 ns | 0.0445 ns | 1.3822 ns |     ? |       ? |
|           |       |           |           |           |           |       |         |
| **Direct**    | **10000** | **0.0127 ns** | **0.0202 ns** | **0.0189 ns** | **0.0000 ns** |     **?** |       **?** |
| Forwarder | 10000 | 2.0302 ns | 0.0784 ns | 0.0962 ns | 2.0586 ns |     ? |       ? |

The results above show the cost of calling an operation directly vs calling a class that then just
calls the other method. I use the word "Forwarder" (`WorkerForwarder` in code) here as a class that is 
a wrapper for another class, that then makes the same method call as the the "Direct" implementation 
does. They both eventually call the `Length` property on a string.