using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.Win
{
    public class CurrentTimeDataReader : ComponentDataReader
    {
        DateTime dateTime;

        public override string ReadData()
        {
            UpdateData();
            return this.dateTime.ToString("dd-MM-yyyy HH:mm:ss") + DATA_SEPARATOR;
        }

        public override string GetDataHeader()
        {
            return "DATE_TIME " + DATA_SEPARATOR + DATA_SEPARATOR;
        }

        public override void UpdateData()
        {
            this.dateTime = DateTime.Now;
        }
    }
}
