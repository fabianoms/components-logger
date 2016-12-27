using ComponentsLogger.DataReaders.DataFormat;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.OHM
{
    public class ProcessorDataReaderOHM : OHMDataReader
    {
        public ProcessorDataReaderOHM(Computer computer) : base(computer) { }

        public override HardwareType GetHardwareType()
        {
            return HardwareType.CPU;
        }

        protected override void EnableHardwareInComputer(Computer computer)
        {
            computer.CPUEnabled = true;
        }

    }
}
