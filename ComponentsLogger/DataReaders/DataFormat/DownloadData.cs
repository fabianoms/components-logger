using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.DataFormat
{
    public class DownloadData : ComponentData
    {
        public override string GetDefaultStringFormat()
        {
            return "000000.0000";
        }
    }
}
