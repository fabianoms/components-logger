using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using ComponentsLogger.DataReaders.DataFormat;
using System.Diagnostics;

namespace ComponentsLogger.DataReaders.Win
{

    public class ProcessorDataReader : ComponentDataReader
    {
        struct CPUData
        {
            public int load;
            public int clockSpeed;
        }
            
        private ComponentData load;
        private ComponentData frequency;

        private PerformanceCounter processorLoad;
        private ManagementObjectSearcher searcher;

        public ProcessorDataReader()
        {

            searcher = new ManagementObjectSearcher("root\\CIMV2",
                "SELECT CurrentClockSpeed, LoadPercentage FROM Win32_Processor");
            load = new ProcessorData();
            frequency = new ProcessorData();
            processorLoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            
        }

        public override string ReadData()
        {
            UpdateData();
            return load.Data.ToString() + DATA_SEPARATOR + frequency.Data.ToString() + DATA_SEPARATOR;
        }

        public override string GetDataHeader()
        {
            return "CPULoad_% \tCPUFrequency_GHz \t";
        }

        public override void UpdateData()
        {
           
            //int currentsp = GetCpuClockSpeed();
            //int loadPercentage = GetLoadPercentage();
            CPUData cpuData = GetCPUData();
            if ((cpuData.clockSpeed != -1) && cpuData.load != -1) //((currentsp != -1) && (loadPercentage != -1))
            {
                this.load.Data = ((float)cpuData.load) / 100f; //((float)loadPercentage) / 100f; //values between 0 and 1
                this.frequency.Data = ((float)cpuData.clockSpeed) / 1000f; //((float)currentsp) / 1000f; //GHz
            }
        }

        private int GetCpuClockSpeed()
        {
            try
            {
               
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return Convert.ToInt32(queryObj["CurrentClockSpeed"]);
                }
            }
            catch (Exception)
            {
                return -1;
            }
            return -1;
        }


        private int GetLoadPercentage()
        {
            try
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    return Convert.ToInt32(queryObj["LoadPercentage"]);
                }
            }
            catch (Exception)
            {
                return -1;
            }
            return -1;
        }

        private CPUData GetCPUData()
        {
            CPUData cpuData = new CPUData();
            try
            {

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    cpuData.clockSpeed = Convert.ToInt32(queryObj["CurrentClockSpeed"]);
                    cpuData.load = Convert.ToInt32(queryObj["LoadPercentage"]);
                    return cpuData;
                }
            }
            catch (Exception)
            {
                cpuData.load = -1;
                cpuData.clockSpeed = -1;
                return cpuData;
            }
            cpuData.load = -1;
            cpuData.clockSpeed = -1;
            return cpuData;
        }
    }


}
