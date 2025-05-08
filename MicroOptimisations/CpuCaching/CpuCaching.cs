namespace MicroOptimisations.CpuCaching
{
    public class CacheLines
    {
        private static readonly int _length = 64 * 1024 * 1024;
        private static readonly int[] _arr = new int[_length];
        public static void ModifyEveryKElement(int k) 
        {
            if (k <= 0) throw new ArgumentException("Value provided cannot be less than 1.");
            for (int i = 0; i < _arr.Length; i += k)
            {
                _arr[i] *= 3;
            }
        }
    }


    public static class CacheLevels
    {
        public static void ModifyEvery16thInteger(int length) 
        {
            int[] _arr = new int[length];
            int steps =  64 * 1024 * 1024;
            int lengthMod = _arr.Length - 1;
            for (int i = 0; i < steps; i++)
            {
                _arr[i * 16 & lengthMod]++; // (x & lengthMod) is equal to (x % arr.Length)
            }
        }
    }

    /// <summary>
    /// This example shows "False Sharing" between L1 caches.
    /// 
    /// Cache lines are shared between cpu processors, and when one of the processors update a
    /// value in a cache line, it invalidates the entire line.
    /// 
    /// </summary>
    public class CacheLineFalseSharing
    {
        private static int[] _counter = new int[1024];
        public void UpdateCounter(int position)
        {
            for (int i = 0; i < 100000000; i++)
            {
                _counter[position] = _counter[position] + 3;
            }
        }
    }
}