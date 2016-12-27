using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentsLogger.DataReaders.OHM
{
    public abstract class OHMDataReader : ComponentDataReader
    {
        protected IHardware hardware;

        
        public OHMDataReader(Computer computer)
        {
            if (computer != null)
            {
                EnableHardwareInComputer(computer);
                foreach (IHardware computerHardware in computer.Hardware)
                {
                    if (computerHardware.HardwareType == GetHardwareType())
                    {
                        this.hardware = computerHardware;
                        break;
                    }
                }
            }
            if (computer == null || this.hardware == null)
                throw new HardwareNotFoundException(GetHardwareType().ToString());
            
        }

        public abstract HardwareType GetHardwareType();

        protected abstract void EnableHardwareInComputer(Computer computer);

        public override void UpdateData()
        {
            if (hardware != null)
                hardware.Update();
        }

        public override string ReadData()
        {
            if (hardware == null)
                return string.Empty;

            UpdateData();

            string values = "";
            foreach (ISensor sensor in hardware.Sensors)
            {
                values += sensor.Value + DATA_SEPARATOR;
            }
            return values;
        }

        public override string GetDataHeader()
        {
            if (hardware == null)
                return string.Empty;

            string header = "";
            foreach (ISensor sensor in hardware.Sensors)
            {
                header += hardware.HardwareType + "_" + sensor.SensorType + "_" + sensor.Name + DATA_SEPARATOR;
            }
            return header.Replace(" ", "");
        }

        public IHardware GetHardware()
        {
            return this.hardware;
        }
    }
}
