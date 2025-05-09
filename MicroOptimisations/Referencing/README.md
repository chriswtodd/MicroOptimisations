# Referencing

Referencing in any programming language vs storing the information in the stack
will affect the time taken to access data. An int vs an int property on an 
object, for example.

This is largely because the stack is for short term items in memory, for the 
scope of methods etc. The heap however stores objects and using the `new` 
keyword in C# dynamically assigns memory on the heap (malloc c, new c++,
it goes on).

Storing references on the stack to items on the heap (e.g. with `ref`) 
prevents a lookup from the heap (thats random or 'disorganised') and therefore
increases the speed at which we can perform operations. This is demonstrated 
by the last example `ClassReferencerWithParameterResult`.

## Results

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5737/22H2/2022Update)
Intel Core i5-6400 CPU 2.70GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2


```
| Method                             | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD |
|----------------------------------- |----------:|----------:|----------:|----------:|------:|--------:|
| Director                           | 0.3468 ns | 0.0437 ns | 0.0408 ns | 0.3385 ns |  1.01 |    0.16 |
| ClassReferencer                    | 0.2931 ns | 0.0412 ns | 0.0385 ns | 0.2947 ns |  0.86 |    0.14 |
| StructReferencer                   | 0.0328 ns | 0.0290 ns | 0.0272 ns | 0.0176 ns |  0.10 |    0.08 |
| ClassReferencerWithParameterResult | 0.0125 ns | 0.0076 ns | 0.0059 ns | 0.0143 ns |  0.04 |    0.02 |
