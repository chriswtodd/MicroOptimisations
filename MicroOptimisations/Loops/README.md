# Loops

The way things are looped have an effect on the performance as well. Enumeration (using links) is
slower than contiguous blocks of memory being accessed, which this example demonstrates.

Dictionaries, with their enumerator requiring looking up for uniqueness and having to find two 
objects in this example are slower than lists, both of which use links between the elements to 
iterate. Lists are slower than arrays, since arrays are all stored in continguous memory in the 
CPU. Theres a lot of caveats to this, including the most glaring being that Lists in C# use 
arrays under the hood. 

The same actually goes for dictionaries as well, the naive implementation is very poor but the newer
faster. How? 

Dictionaries are sped up because they use both an array and a hashset. All of these optimisations
mean the results below are actually exceedingly close in performance.

I threw in keys in a dictionary because its funny (its a double list enumeration, showing the cost of
double looping a list).

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5737/22H2/2022Update)
Intel Core i5-6400 CPU 2.70GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2


```
| Method                                    | Mean      | Error    | StdDev   | Ratio | RatioSD |
|------------------------------------------ |----------:|---------:|---------:|------:|--------:|
| IterateForeachOnDict                      |  60.97 ns | 0.743 ns | 0.658 ns |  2.00 |    0.02 |
| IterateForeachOnKeysInDict                | 368.54 ns | 1.518 ns | 1.346 ns | 12.06 |    0.08 |
| IterateForeachOnList                      |  30.55 ns | 0.174 ns | 0.163 ns |  1.00 |    0.01 |
| IterateForOnListWithoutCountOptimization  |  40.15 ns | 0.813 ns | 0.936 ns |  1.31 |    0.03 |
| IterateForOnListWithCountOptimization     |  38.15 ns | 0.424 ns | 0.376 ns |  1.25 |    0.01 |
| IterateForeachOnArray                     |  23.34 ns | 0.224 ns | 0.198 ns |  0.76 |    0.01 |
| IterateForOnArrayWithoutCountOptimization |  23.11 ns | 0.486 ns | 0.499 ns |  0.76 |    0.02 |
| IterateForOnArrayWithCountOptimization    |  22.53 ns | 0.480 ns | 0.533 ns |  0.74 |    0.02 |