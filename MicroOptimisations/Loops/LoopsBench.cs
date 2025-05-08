using BenchmarkDotNet.Attributes;

namespace MicroOptimisations.Loops
{
    public class Bench
    {
        private static readonly int _length = 64;
        private static readonly int[] _arr = Enumerable
            .Range(0, _length)
            .ToArray();
        private static readonly List<int> _list = Enumerable
            .Range(0, _length)
            .ToList();
        private static readonly Dictionary<int, int> _dict = Enumerable
            .Range(0, _length)
            .ToDictionary(key => key);

        [Benchmark]
        public void IterateForeachOnDict() => Loops.IterateForeachOnDict(_dict);

        [Benchmark]
        public void IterateForeachOnKeysInDict() => Loops.IterateForeachOnKeysInDict(_dict);

        [Benchmark(Baseline = true)]
        public void IterateForeachOnList() => Loops.IterateForeachOnList(_list);

        [Benchmark]
        public void IterateForOnListWithoutCountOptimization() => Loops.IterateForOnListWithoutCountOptimization(_list);

        [Benchmark]
        public void IterateForOnListWithCountOptimization() => Loops.IterateForOnListWithCountOptimization(_list);

        [Benchmark]
        public void IterateForeachOnArray() => Loops.IterateForeachOnArray(_arr);

        [Benchmark]
        public void IterateForOnArrayWithoutCountOptimization() => Loops.IterateForOnArrayWithoutCountOptimization(_arr);

        [Benchmark]
        public void IterateForOnArrayWithCountOptimization() => Loops.IterateForOnArrayWithCountOptimization(_arr);
    }
}