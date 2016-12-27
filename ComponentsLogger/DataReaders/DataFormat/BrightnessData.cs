using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.DataFormat
{
    public class BrightnessData : ComponentData
    {
        public override string GetDefaultStringFormat()
        {
            return "0.00";
        }
    }
}
