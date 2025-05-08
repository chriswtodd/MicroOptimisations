namespace MicroOptimisations.Loops
{
    public class Loops
    {
        public static void IterateForeachOnDict(Dictionary<int, int> dict)
        {
            foreach (var i in dict) { var j = i; }
        }
        public static void IterateForeachOnKeysInDict(Dictionary<int, int> dict)
        {
            foreach (int k in dict.Keys) { var j = dict[k]; }
        }
        public static void IterateForeachOnList(List<int> list)
        {
            foreach (var i in list) { int j = i; }
        }
        public static void IterateForOnListWithoutCountOptimization(List<int> list)
        {
            for (var i = 0; i < list.Count; i++) { var j = list[i]; }
        }
        public static void IterateForOnListWithCountOptimization(List<int> list)
        {
            var count = list.Count;
            for (var i = 0; i < count; i++) { var j = list[i]; }
        }
        public static void IterateForeachOnArray(int[] array)
        {
            foreach (var i in array) { var j = i; }
        }
        public static void IterateForOnArrayWithoutCountOptimization(int[] array)
        {
            for (var i = 0; i < array.Length; i++) { var j = array[i]; }
        }
        public static void IterateForOnArrayWithCountOptimization(int[] array)
        {
            var length = array.Length;
            for (var i = 0; i < length; i++) { var j = array[i]; }
        }
    }
}