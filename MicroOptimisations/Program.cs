using BenchmarkDotNet.Running;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

    public static void SerializerStuff() 
    {
        // var b = new BinarySerializerStrategy();
        // var d = new DataContractSerializerStrategy();
        // var p = new ProtoBufSerializationStrategy();

        // b.Do();
        // d.Do();
        // p.Do();
    }
}
