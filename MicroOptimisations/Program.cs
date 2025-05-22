using BenchmarkDotNet.Running;
using MicroOptimisations.CpuCaching;

public class Program 
{
    public static void Main(string[] args) 
    {
        CpuInfo.GetCacheSizes().ForEach(d => Console.WriteLine(d));
        //RunBenchmarks();
    }

    public static void RunBenchmarks()
    {
        var summaryForwarding = BenchmarkRunner.Run<MicroOptimisations.Forwarding.Bench>();
        var summaryReferencing = BenchmarkRunner.Run<MicroOptimisations.Referencing.Bench>();
        var summaryCacheLevelsBench = BenchmarkRunner.Run<MicroOptimisations.CpuCaching.CacheLevelsBench>();
        var summaryCacheLineFalseSharing = BenchmarkRunner.Run<MicroOptimisations.CpuCaching.CacheLineFalseSharingBench>();
        var summaryCacheLineUpdatingBench = BenchmarkRunner.Run<MicroOptimisations.CpuCaching.CacheLineUpdatingBench>();
        var summaryLoops = BenchmarkRunner.Run<MicroOptimisations.Loops.Bench>();
    }
}
