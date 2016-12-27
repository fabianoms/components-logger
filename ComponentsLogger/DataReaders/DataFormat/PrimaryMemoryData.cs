using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.DataFormat
{
    public class PrimaryMemoryData : ComponentData
    {
        public override string GetDefaultStringFormat()
        {
            return "0000.0000";
        }
    }
}
