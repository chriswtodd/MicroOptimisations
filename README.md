# MicroOptimisiations

When writing code in any programming language, to achieve the highest performance possible for a 
given machine and task requires knowledge of both language implementation and computer architecture 
/ operation. The language and how it interacts with hardware as well as the implementation details 
of how CPU's process bytes, addresses and blocks of data can have an effect on the performance of 
an application.

Modern compilers can do a lot of the work that removes the need for some large percentage (I dare 
not speculate on a number) of developers to ever understand these complexities. For a lot of 
production or distributed software, what the compiler does and not worrying about writing your code
in a specific, nice to handle way for the CPU either will not give you meaningful performance 
impacts (eg your application relies heavily on network connections for communication, and 
hence the network is probably the bottleneck) or it is not a key feature, and time / resources are 
better spent on higher value work items.

But, for some key use cases, a compiler is just not good enough (yet? I'm absolutely not a expert in
this area, perhaps this is an improvement that is feasible). See 
[FFmpeg](https://ffmpeg.org/developer.html#SIMD_002fDSP-1) as a real example of this.

## Inspiration

I got the idea for this project off the back of Matt Holidays excellent Go course [here](https://www.youtube.com/watch?v=7QLoOd9HinY&list=PLoILbKo9rG3skRCj37Kn5Zj803hhiuRK6&index=35&t=1302s&ab_channel=MattK%C3%98DVB).
The course is high quality and I would recommend it to anyone that has a bit of programming 
experience and does not currently know a lot about Go.

## What it does

This repo uses the [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) package to time
a number of implementations that perform operations demonstrating langauge and caching effects, 
each producing a artifacts related to time / other information related to the implementations 
run in the /BenchmarkDotNet.Artifacts folder.

### Requirements

You will need the .NET SDK 9.x to run the test suite which produces the results. Any type of machine
is fine.

### Running the full suite

```
dotnet run -c Release
```