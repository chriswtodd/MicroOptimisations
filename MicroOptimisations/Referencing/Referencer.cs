namespace MicroOptimisations.Referencing
{
    public struct StructReferencerResult
    {
        public int Get(int i) 
        {
            return i % 2;
        }
    }

    public class ClassReferencerResult 
    {
        public int Get(int i) 
        {
            return i % 2;
        }
    }

    public class ClassReferencerWithParameterResult 
    {
        public int Get(ref int i) 
        {
            return i % 2;
        }
    }

    public class StructReferencer
    {
        private readonly StructReferencerResult _r = new StructReferencerResult();

        public int Get(int i)
        {
            return _r.Get(i);
        }
    }

    public class ClassReferencer 
    {
        private readonly ClassReferencerResult _r = new ClassReferencerResult();

        public int Get(int i)
        {
            return _r.Get(i);
        }
    }

    public class ClassReferencerWithParameter
    {
        private readonly ClassReferencerWithParameterResult _r = new ClassReferencerWithParameterResult();

        public int Get(int i)
        {
            return _r.Get(ref i);
        }
    }

    public class Director
    {
        public int Get(int i)
        {
            return i % 2;
        }
    }
}