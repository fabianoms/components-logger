using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ComponentsLogger.DataReaders.DataFormat;

namespace ComponentsLogger.DataReaders.Win
{
    public class HardDiskDataReader : ComponentDataReader
    {
        private ComponentData bytesPerSec;
        private PerformanceCounter hdPCounter;
        private string identifier;

        public HardDiskDataReader(string instanceName, string identifier)
        {
            this.identifier = identifier;
            bytesPerSec = new HardDiskIOData();
            hdPCounter = new PerformanceCounter("PhysicalDisk", "Disk Bytes/sec", instanceName);
        }

        public override string ReadData()
        {
            UpdateData();
            return bytesPerSec.ToString() + DATA_SEPARATOR;
        }

        public override string GetDataHeader()
        {
            return this.identifier + "_IO_Bytes/sec \t";
        }

        public override void UpdateData()
        {
            bytesPerSec.Data = hdPCounter.NextValue();
        }
    }
}
