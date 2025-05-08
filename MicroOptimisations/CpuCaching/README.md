# CPU Caching effects

There are a bunch of cpu caching effects, some of which listed here with the benches in the package to accompany.

I've written these benches in C# because I am most familiar, but the concepts largely apply to other languages
since an array of data is represented as a contiguous set of memory addresses from the starting point in most 
good languages (note specifically *arrays*). These examples demonstrate how that decision can affect operations
on arrays of data in specific circumstances.

CPU's have caches that help them perform operations faster, so they do not need to go back to main memory. Theres
a bunch of theory about how to predict what CPU's will do next and the easiest and most likely bet is actually 
that the CPU requires the same data again, so keeping it in the cache is a good idea. I am again, no expert, so I 
won't comment directly, but I will touch again on this later in this example.

Heres some effects that these caches can have on your code (I'm focusing on bad here but they clearly provide a lot
 of benefit since they exist... But thats no fun!)

## CPU Cache Levels

### Results

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5737/22H2/2022Update)
Intel Core i5-6400 CPU 2.70GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]                    : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  CacheLineUpdatingBenchJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2

Job=CacheLineUpdatingBenchJob  InvocationCount=1  IterationCount=5  
LaunchCount=1  UnrollFactor=1  WarmupCount=3  

```
| Method    | Mean      | Error     | StdDev    | Ratio | RatioSD |
|---------- |----------:|----------:|----------:|------:|--------:|
| Size1kB   |  55.04 ms |  1.344 ms |  0.349 ms |  1.00 |    0.01 |
| Size2kB   |  54.33 ms |  1.560 ms |  0.241 ms |  0.99 |    0.01 |
| Size4kB   |  54.21 ms |  2.175 ms |  0.565 ms |  0.98 |    0.01 |
| Size8kB   |  53.50 ms |  1.613 ms |  0.250 ms |  0.97 |    0.01 |
| Size16kB  |  54.32 ms |  2.363 ms |  0.366 ms |  0.99 |    0.01 |
| Size32kB  |  55.17 ms |  3.600 ms |  0.935 ms |  1.00 |    0.02 |
| Size64kB  |  78.01 ms |  4.347 ms |  1.129 ms |  1.42 |    0.02 |
| Size128kB |  76.78 ms |  7.492 ms |  1.946 ms |  1.40 |    0.03 |
| Size256kB |  75.11 ms |  4.508 ms |  1.171 ms |  1.36 |    0.02 |
| Size512kB | 128.16 ms |  6.831 ms |  1.774 ms |  2.33 |    0.03 |
| Size1MB   | 126.37 ms |  1.418 ms |  0.219 ms |  2.30 |    0.01 |
| Size2MB   | 130.55 ms |  9.216 ms |  2.393 ms |  2.37 |    0.04 |
| Size4MB   | 147.93 ms | 14.881 ms |  2.303 ms |  2.69 |    0.04 |
| Size8MB   | 239.19 ms | 17.324 ms |  4.499 ms |  4.35 |    0.08 |
| Size16MB  | 312.76 ms | 48.258 ms | 12.533 ms |  5.68 |    0.21 |
| Size32MB  | 379.43 ms | 79.886 ms | 20.746 ms |  6.89 |    0.35 |
| Size64MB  | 382.36 ms | 20.994 ms |  3.249 ms |  6.95 |    0.07 |
| Size128MB | 420.43 ms | 30.892 ms |  8.023 ms |  7.64 |    0.14 |

Each cache level has a different size and speed to access from the CPU. Closer to CPU
faster and smaller. Knowing this, we can guess from the above what size each of the 
cache levels are from the large jumps between groups of times taken to perform an 
operation.

There are jumps between 32kb-64kb (~40% increase), and 4MB-8MB (~60), which are the 
sizes of the L1 and L2 caches on my machine.

## CPU Cache Lines

### Results

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5737/22H2/2022Update)
Intel Core i5-6400 CPU 2.70GHz (Skylake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.203
  [Host]              : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  CacheLevelsBenchJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2

Job=CacheLevelsBenchJob  InvocationCount=1  IterationCount=5  
LaunchCount=1  UnrollFactor=1  WarmupCount=3  

```
| Method   | Mean        | Error      | StdDev      | Ratio | RatioSD |
|--------- |------------:|-----------:|------------:|------:|--------:|
| Size2    | 35,903.3 μs | 3,261.7 μs |   504.76 μs |  1.00 |    0.02 |
| Size4    | 25,202.0 μs | 1,565.8 μs |   406.64 μs |  0.70 |    0.01 |
| Size8    | 22,376.8 μs | 4,698.9 μs | 1,220.29 μs |  0.62 |    0.03 |
| Size16   | 21,997.5 μs | 6,023.8 μs | 1,564.37 μs |  0.61 |    0.04 |
| Size32   | 18,096.0 μs | 1,595.1 μs |   246.85 μs |  0.50 |    0.01 |
| Size64   | 12,126.8 μs | 1,794.4 μs |   466.01 μs |  0.34 |    0.01 |
| Size128  |  6,982.0 μs |   953.3 μs |   247.57 μs |  0.19 |    0.01 |
| Size256  |  3,878.3 μs |   735.1 μs |   190.89 μs |  0.11 |    0.01 |
| Size512  |  1,996.5 μs |   781.9 μs |   121.00 μs |  0.06 |    0.00 |
| Size1024 |    788.3 μs |   324.1 μs |    84.16 μs |  0.02 |    0.00 |

Cache lines are populated at particular sizes depending on the cache level. From above, 
we see a drop in mean operation time at Size16 (or 16 ints), and can therefore derive the
cache line sizes in this machine: 4 * 16 = 64 bytes.

## CPU False Sharing

