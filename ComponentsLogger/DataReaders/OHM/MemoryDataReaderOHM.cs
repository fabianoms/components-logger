using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.OHM
{
    public class MemoryDataReaderOHM : OHMDataReader
    {

        public MemoryDataReaderOHM(Computer computer) : base(computer) { }

        public override OpenHardwareMonitor.Hardware.HardwareType GetHardwareType()
        {
            return HardwareType.RAM;
        }

        protected override void EnableHardwareInComputer(Computer computer)
        {
            computer.RAMEnabled = true;
        }
    }
}
