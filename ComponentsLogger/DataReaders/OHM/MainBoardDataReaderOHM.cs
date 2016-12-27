using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.OHM
{
    public class MainBoardDataReaderOHM : OHMDataReader
    {

        public MainBoardDataReaderOHM(Computer computer) : base(computer) { }

        public override OpenHardwareMonitor.Hardware.HardwareType GetHardwareType()
        {
            return HardwareType.Mainboard;
        }

        protected override void EnableHardwareInComputer(OpenHardwareMonitor.Hardware.Computer computer)
        {
            computer.MainboardEnabled = true;
        }
    }
}
