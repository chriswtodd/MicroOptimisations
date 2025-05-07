using BenchmarkDotNet.Attributes;

namespace MicroOptimisations.Referencing
{
    public class Bench
    {
        private Director _director = new Director(); 
        private ClassReferencer _classReferencer = new ClassReferencer();
        private StructReferencer _structReferencer = new StructReferencer();
        private ClassReferencerWithParameter _classReferencerWithParameter = new ClassReferencerWithParameter();
        private Random _random = new Random();
        private int _input = 0;

        [GlobalSetup]
        public void Setup() 
        {
            _input = _random.Next();
        }

        [Benchmark(Baseline = true)]
        public int Director() => _director.Get(_input);

        [Benchmark]
        public int ClassReferencer() => _classReferencer.Get(_input);

        [Benchmark]
        public int StructReferencer() => _structReferencer.Get(_input);

        [Benchmark]
        public int ClassReferencerWithParameterResult() => _classReferencerWithParameter.Get(_input);
    }
}