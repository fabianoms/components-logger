using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ComponentsLogger.DataReaders.DataFormat;
using System.Management;

namespace ComponentsLogger.DataReaders.Win
{
    public class NetworkDataReader : ComponentDataReader
    {
        private ComponentData download;
        private ComponentData upload;
        private ComponentData isActive;

        private PerformanceCounter downloadPerfCounter;
        private PerformanceCounter uploadPerfCounter;
        private ObjectQuery oQuery;
        private ManagementObjectSearcher devicesSearcher;

        private bool logDownload;
        private bool logUpload;
        private bool logStatus;
        private string networkInterfaceName;
        private string networkInterfaceMappedName;

        private NetworkDeviceType deviceType;

        public NetworkDataReader(string instanceName, NetworkDeviceType type, bool logDownload, bool logUpload, bool logStatus)
        {
            this.networkInterfaceName = instanceName; //contains invalid characters
            this.networkInterfaceMappedName = ConvertToInstanceName(this.networkInterfaceName); //replaces invalid characters
            this.logDownload = logDownload;
            this.logUpload = logUpload;
            this.deviceType = type;
            this.logStatus = logStatus;

            if (logUpload)
            {
                uploadPerfCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instanceName);
                upload = new UploadData();
            }
            if (logDownload)
            {
                downloadPerfCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", instanceName);
                download = new DownloadData();
            }
            if (logStatus)
            {
                oQuery = new System.Management.ObjectQuery("select * from Win32_PnPEntity ");
                devicesSearcher = new ManagementObjectSearcher(oQuery);
                isActive = new StatusData();
            }
        }

        public override string ReadData()
        {
            UpdateData();
            string readValue = "";
            if (logDownload)
                readValue += download.ToString() + DATA_SEPARATOR;
            if (logUpload)
                readValue += upload.ToString() + DATA_SEPARATOR;
            if (logStatus)
                readValue += isActive.ToString() + DATA_SEPARATOR;
            return readValue;
        }

        public override string GetDataHeader()
        {
            string header = "";
            string devType = (deviceType == NetworkDeviceType.Ethernet) ? "Ethernet" : "Wireless";
            if (logDownload)
                header += devType + "Download_B/s \t";
            if (logUpload)
                header += devType + "Upload_B/s \t";
            if (logStatus)
                header += devType + "Status \t";

            return header;
        }

        public override void UpdateData()
        {
            if (logDownload)
                download.Data = downloadPerfCounter.NextValue();
            if (logUpload)
                upload.Data = uploadPerfCounter.NextValue();
            if (logStatus)
                isActive.Data = IsNetworkInterfaceEnabled();
        }

        private float IsNetworkInterfaceEnabled()
        {
            try
            {
                string name;
                foreach (ManagementObject oReturn in devicesSearcher.Get())
                {
                    name = oReturn["Name"].ToString();
                    if ((!string.IsNullOrEmpty(name)) && name.StartsWith(this.networkInterfaceMappedName))
                    {
                        string result = oReturn["Status"].ToString();
                        return result.Equals("OK") ? 1 : 0;
                    }
                }
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// Converts a device name to an instance name, according the mapping at
        /// http://msdn.microsoft.com/pt-br/library/system.diagnostics.performancecounter.instancename.aspx
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        public string ConvertToInstanceName(string deviceName)
        {
            deviceName = deviceName.Replace('[', '(');
            deviceName = deviceName.Replace(']', ')');
            int indexOfInvalidChar = deviceName.IndexOf('-');
            if (indexOfInvalidChar != -1)
                deviceName = deviceName.Substring(0, indexOfInvalidChar);
            return deviceName;
        }
    }

    public enum NetworkDeviceType
    {
        Ethernet, Wireless
    }
}
