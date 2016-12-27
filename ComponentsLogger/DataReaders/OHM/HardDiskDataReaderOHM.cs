using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.OHM
{
    public class HardDiskDataReaderOHM : OHMDataReader
    {

        public HardDiskDataReaderOHM(Computer computer) : base(computer) { }

        public override OpenHardwareMonitor.Hardware.HardwareType GetHardwareType()
        {
            return HardwareType.HDD;
        }

        protected override void EnableHardwareInComputer(OpenHardwareMonitor.Hardware.Computer computer)
        {
            computer.HDDEnabled = true;
        }
    }
}
