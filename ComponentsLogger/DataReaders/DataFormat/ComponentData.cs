using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.DataFormat
{
    public abstract class ComponentData
    {
        public float Data { get; set; }

        public abstract string GetDefaultStringFormat();

        public string ToString(string format)
        {
            return Data.ToString(format);
        }

        public override string ToString()
        {
            return Data.ToString(this.GetDefaultStringFormat());
        }
    }
}
