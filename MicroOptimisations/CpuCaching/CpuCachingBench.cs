using BenchmarkDotNet.Attributes;

namespace MicroOptimisations.CpuCaching
{
    [SimpleJob(launchCount: 1, warmupCount: 3, iterationCount: 5, invocationCount:1, id: "CacheLineUpdatingBenchJob")]
    public class CacheLineUpdatingBench
    {
        // Cache Lines Benchmark
        [Benchmark(Baseline = true)]
        public void Size2() => CacheLines.ModifyEveryKElement(2);

        [Benchmark]
        public void Size4() => CacheLines.ModifyEveryKElement(4);

        [Benchmark]
        public void Size8() => CacheLines.ModifyEveryKElement(8);

        [Benchmark]
        public void Size16() => CacheLines.ModifyEveryKElement(16);

        [Benchmark]
        public void Size32() => CacheLines.ModifyEveryKElement(32);

        [Benchmark]
        public void Size64() => CacheLines.ModifyEveryKElement(64);

        [Benchmark]
        public void Size128() => CacheLines.ModifyEveryKElement(128);

        [Benchmark]
        public void Size256() => CacheLines.ModifyEveryKElement(256);

        [Benchmark]
        public void Size512() => CacheLines.ModifyEveryKElement(512);

        [Benchmark]
        public void Size1024() => CacheLines.ModifyEveryKElement(1024);
    }

    [SimpleJob(launchCount: 1, warmupCount: 3, iterationCount: 5, invocationCount:1, id: "CacheLineFalseSharingBenchJob")]
    public class CacheLineFalseSharingBench
    {
        
        // Cpu Cache Line False Sharing
        [Benchmark]
        public void IntsInvalidated()
        {
            Thread thread1 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(1));
            Thread thread2 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(2));
            Thread thread3 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(3));
            Thread thread4 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(4));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        }

        [Benchmark]
        public void IntsMaybeInvalidated()
        {
            Thread thread1 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(8));
            Thread thread2 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(16));
            Thread thread3 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(32));
            Thread thread4 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(64));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        }

        [Benchmark]
        public void IntsNotInvalidated()
        {
            Thread thread1 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(512));
            Thread thread2 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(1024));
            Thread thread3 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(2048));
            Thread thread4 = new Thread(() => new CacheLineFalseSharing().UpdateCounter(4096));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        }
    }

    [SimpleJob(launchCount: 1, warmupCount: 3, iterationCount: 5, invocationCount:1, id: "CacheLevelsBenchJob")]
    public class CacheLevelsBench 
    {
        
        [Benchmark(Baseline = true)] // 256 * 4b = 1kB
        public void Size1kB() => CacheLevels.ModifyEvery16thInteger(256);


        [Benchmark]
        public void Size2kB() => CacheLevels.ModifyEvery16thInteger(512);


        [Benchmark]
        public void Size4kB() => CacheLevels.ModifyEvery16thInteger(1024);

        [Benchmark]
        public void Size8kB() => CacheLevels.ModifyEvery16thInteger(2048);

        [Benchmark]
        public void Size16kB() => CacheLevels.ModifyEvery16thInteger(4096);

        [Benchmark]
        public void Size32kB() => CacheLevels.ModifyEvery16thInteger(8192);

        [Benchmark]
        public void Size64kB() => CacheLevels.ModifyEvery16thInteger(16384);

        [Benchmark]
        public void Size128kB() => CacheLevels.ModifyEvery16thInteger(32768);

        [Benchmark]
        public void Size256kB() => CacheLevels.ModifyEvery16thInteger(65536);

        [Benchmark]
        public void Size512kB() => CacheLevels.ModifyEvery16thInteger(131072);

        [Benchmark]
        public void Size1MB() => CacheLevels.ModifyEvery16thInteger(262144);

        [Benchmark]
        public void Size2MB() => CacheLevels.ModifyEvery16thInteger(524288);

        [Benchmark]
        public void Size4MB() => CacheLevels.ModifyEvery16thInteger(1048576);

        [Benchmark]
        public void Size8MB() => CacheLevels.ModifyEvery16thInteger(2097152);

        [Benchmark]
        public void Size16MB() => CacheLevels.ModifyEvery16thInteger(4194304);

        [Benchmark]
        public void Size32MB() => CacheLevels.ModifyEvery16thInteger(8388608);

        [Benchmark]
        public void Size64MB() => CacheLevels.ModifyEvery16thInteger(16777216);

        [Benchmark]
        public void Size128MB() => CacheLevels.ModifyEvery16thInteger(33554432);
    }
}