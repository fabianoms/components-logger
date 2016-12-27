using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentsLogger.DataReaders.DataFormat;

namespace ComponentsLogger.DataReaders
{
    public abstract class ComponentDataReader
    {
        protected const string DATA_SEPARATOR = " \t\t";

        public abstract string ReadData();
        public abstract string GetDataHeader();
        public abstract void UpdateData();
    }
}
