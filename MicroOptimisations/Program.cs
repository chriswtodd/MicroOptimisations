using BenchmarkDotNet.Running;

public class Program 
{
    public static void Main(string[] args) 
    {
        RunBenchmarks();
    }

    public static void RunBenchmarks()
    {
        var summaryForwarding = BenchmarkRunner.Run<MicroOptimisations.Forwarding.Bench>();
        var summaryReferencing = BenchmarkRunner.Run<MicroOptimisations.Referencing.Bench>();
        var summaryCacheLevelsBench = BenchmarkRunner.Run<MicroOptimisations.CpuCaching.CacheLevelsBench>();
        var summaryCacheLineFalseSharing = BenchmarkRunner.Run<MicroOptimisations.CpuCaching.CacheLineFalseSharing>();
        var summaryCacheLineUpdatingBench = BenchmarkRunner.Run<MicroOptimisations.CpuCaching.CacheLineUpdatingBench>();
        var summaryLoops = BenchmarkRunner.Run<MicroOptimisations.Loops.Bench>();
    }
}
