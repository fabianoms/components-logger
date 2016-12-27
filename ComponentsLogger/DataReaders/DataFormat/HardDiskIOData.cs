using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.DataFormat
{
    public class HardDiskIOData : ComponentData
    {
        public override string GetDefaultStringFormat()
        {
            return "00000000.0000";
        }
    }
}
