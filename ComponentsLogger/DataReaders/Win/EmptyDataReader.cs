using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.Win
{
    public class EmptyDataReader : ComponentDataReader
    {
        public override string ReadData()
        {
            return String.Empty;
        }

        public override string GetDataHeader()
        {
            return String.Empty;
        }

        public override void UpdateData() { }
    }
}