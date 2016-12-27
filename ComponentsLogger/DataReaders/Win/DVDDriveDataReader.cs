using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using ComponentsLogger.DataReaders.DataFormat;

namespace ComponentsLogger.DataReaders.Win
{
    public class DVDDriveDataReader : ComponentDataReader
    {
        private bool logIO;
        private bool logStatus;

        private SelectQuery query;
        private ManagementObjectSearcher searcher;

        private ComponentData bytesPerSec;
        private ComponentData status;

        public DVDDriveDataReader(bool logIO, bool logStatus)
        {
            this.logIO = logIO;
            this.logStatus = logStatus;

            if (logIO)
            {
                //TODO
                this.bytesPerSec = new HardDiskIOData();
            }
            if (logStatus)
            {
                this.query = new SelectQuery(@"Select Status from Win32_CDROMDrive");
                this.searcher = new ManagementObjectSearcher(query);
                this.status = new StatusData();
            }
            
        }

        public override string ReadData()
        {
            UpdateData();
            string readValue = "";
            if (logIO)
                readValue += this.bytesPerSec.Data + DATA_SEPARATOR;
            if (logStatus)
                readValue += this.status.Data + DATA_SEPARATOR;
            return readValue;
        }

        public override string GetDataHeader()
        {
            string header = "";
            if (logIO)
                header += "DVD_IO \t";
            if (logStatus)
                header += "DVD_Status \t";
            return header;
        }

        public override void UpdateData()
        {
            if (logIO)
            {
                //TODO
            }
            if (this.logStatus)
            {
                this.status.Data = GetDVDStatus();
            }

        }

        private float GetDVDStatus()
        {
            try
            {
                foreach (ManagementObject process in searcher.Get())
                {
                    string status = process["Status"].ToString();
                    return (status.Equals("OK")) ? 1 : 0;
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
