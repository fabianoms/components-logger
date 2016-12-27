using ComponentsLogger.DataReaders.DataFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace ComponentsLogger.DataReaders.Win
{
    public class CPUFanDataReader : ComponentDataReader
    {
        private SelectQuery query;
        private ManagementObjectSearcher searcher;

        private ComponentData desiredSpeed; //in RPM

        public CPUFanDataReader()
        {
            this.query = new SelectQuery(@"Select DesiredSpeed from Win32_Fan");
            this.searcher = new ManagementObjectSearcher(query);
            this.desiredSpeed = new RPMData();
        }

        public override string ReadData()
        {
            UpdateData();
            return this.desiredSpeed.ToString() + DATA_SEPARATOR;
        }

        public override string GetDataHeader()
        {
            return "Fan_Speed \t";
        }

        public override void UpdateData()
        {
            this.desiredSpeed.Data = GetFanSpeed();
        }

        private float GetFanSpeed()
        {
            try
            {
                foreach (ManagementObject process in searcher.Get())
                {
                    string ds = process["DesiredSpeed"].ToString();
                    return UInt64.Parse(ds);
                }
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
