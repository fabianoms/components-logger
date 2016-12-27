using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Management;
using ComponentsLogger.DataReaders.DataFormat;

namespace ComponentsLogger.DataReaders.Win
{
    public class MemoryDataReader : ComponentDataReader
    {
        private ComponentData usedMemory;
        private PerformanceCounter memoryPCounter;

        ObjectQuery winQuery;
        ManagementObjectSearcher searcher;

        public MemoryDataReader()
        {
            usedMemory = new PrimaryMemoryData();
            memoryPCounter = new PerformanceCounter("Memory", "Available MBytes");
            winQuery = new ObjectQuery("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem");
            searcher = new ManagementObjectSearcher(winQuery);
        }

        public override string ReadData()
        {
            UpdateData();
            return usedMemory.ToString() + DATA_SEPARATOR;
        }

        public override string GetDataHeader()
        {
            return "UsedMemory_MB \t";
        }

        public override void UpdateData()
        {
            usedMemory.Data = GetUsedMemory();
        }

        private float GetUsedMemory()
        {
            float totalMemory = 0;
            float freeMemory = memoryPCounter.NextValue();
            foreach (ManagementObject item in searcher.Get())
            {
                totalMemory = UInt64.Parse(item["TotalVisibleMemorySize"].ToString()) / 1024.0F;
            }
            return totalMemory - freeMemory;
        }
    }
}