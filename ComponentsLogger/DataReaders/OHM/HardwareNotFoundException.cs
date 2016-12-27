using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.OHM
{
    public class HardwareNotFoundException : Exception
    {
        public HardwareNotFoundException(string hardwareName) : base("Hardware não encontrado:" + hardwareName)
        { }
    }
}
