using System.Management;

namespace MicroOptimisations.CpuCaching
{
    public enum CacheLevel : ushort
    {
        Unknown,
        
        Level1 = 3,
        Level2 = 4,
        Level3 = 5,
    }

    public class CacheInfo 
    {
        public CacheLevel CacheLevel { get; set; }
        /// <summary>
        /// Size of Cache in kB. 
        /// </summary>
        public uint MaxCacheSize { get; set; }
        /// <summary>
        /// Size of single block in bytes
        /// </summary>
        public ulong BlockSize { get; set; }
        /// <summary>
        /// Number of blocks
        /// </summary>
        public ulong NumberOfBlocks { get; set; }

        public override string ToString()
        {
            return $"{{\n\tCacheLevel: {CacheLevel},\n\tCacheSize: {MaxCacheSize}kB,\n\tBlockSize: {BlockSize}B,\n\tNumberOfBlocks: {NumberOfBlocks}\n}} ";
        }
    }

    public static class CpuInfo
    {
        // https://learn.microsoft.com/en-gb/windows/win32/cimwin32prov/win32-cachememory
        public static List<CacheInfo> GetCacheSizes()
        {
#pragma warning disable CA1416 // Validate platform compatibility
            var mc = new ManagementClass("Win32_CacheMemory");
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
            var moc = mc.GetInstances();
#pragma warning restore CA1416 // Validate platform compatibility
#pragma warning disable CA1416 // Validate platform compatibility
            var cacheSizes = new List<CacheInfo>(moc.Count);
#pragma warning restore CA1416 // Validate platform compatibility

#pragma warning disable CA1416 // Validate platform compatibility
            cacheSizes.AddRange(moc
                .Cast<ManagementObject>()
                .Select(mo => new CacheInfo { 
                    CacheLevel = (CacheLevel)mo.Properties["Level"].Value, 
                    MaxCacheSize = (uint)mo.Properties["MaxCacheSize"].Value,
                    BlockSize = (ulong)mo.Properties["BlockSize"].Value,
                    NumberOfBlocks = (ulong)mo.Properties["NumberOfBlocks"].Value
                })
            );
#pragma warning restore CA1416 // Validate platform compatibility

            return cacheSizes;
        }
    }
}