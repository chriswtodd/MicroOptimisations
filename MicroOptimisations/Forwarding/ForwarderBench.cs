using BenchmarkDotNet.Attributes;

namespace MicroOptimisations.Forwarding
{
    public class Bench
    {
        private Worker _workerDirect = new WorkerDirect(); 
        private Worker _workerForwarder = new WorkerForwarder();
        private static Random _random = new Random();
        private string _input = "";

        [Params(1, 10, 100, 1000, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup() 
        {
            _input = RandomString(N);
        }

        [Benchmark(Baseline = true)]
        public int Direct() => _workerDirect.Do(_input);

        [Benchmark]
        public int Forwarder() => _workerForwarder.Do(_input);

        // https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}