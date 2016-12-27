using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentsLogger.Native;
using System.Windows.Forms;
using ComponentsLogger.DataReaders.DataFormat;

namespace ComponentsLogger.DataReaders.Win
{
    public class LCDDataReader : ComponentDataReader
    {
        private Guid GUID_VIDEO_SUBGROUP = new Guid(
            0x7516b95f, 0xf776, 0x4464, 0x8c, 0x53, 0x06, 0x16, 0x7f, 0x40,
            0xcc, 0x99
            );

        private Guid GUID_VIDEO_BRIGHTNESS = new Guid(
            0xaded5e82, 0xb909, 0x4619, 0x99, 0x49, 0xf5, 0xd7, 0x1d, 0xac,
            0x0b, 0xcb
            );

        private Guid currentPowerScheme;

        private ComponentData brightness;
        
        public LCDDataReader()
        {
            brightness = new BrightnessData();
            this.currentPowerScheme = PowerSettings.GetActivePowerScheme();
        }

        public override string ReadData()
        {
            UpdateData();
            return this.brightness.ToString() + DATA_SEPARATOR;
        }

        public override string GetDataHeader()
        {
            return "LCD_Brightness \t";
        }

        public override void UpdateData()
        {
            this.brightness.Data = GetBrightness();
        }

        public float GetBrightness()
        {
            uint percentage;
            if (PowerSettings.GetPowerSource() == PowerLineStatus.Offline)
                percentage = ReadDCBrightness();
            else
                percentage = ReadACBrightness();
            return ((float)percentage) / 100;
        }

        private uint ReadACBrightness()
        {
            uint val = 0;
            WindowsSevenNativeFunctions.PowerReadACValueIndex(
                IntPtr.Zero,
                ref currentPowerScheme,
                ref this.GUID_VIDEO_SUBGROUP,
                ref this.GUID_VIDEO_BRIGHTNESS,
                ref val);

            return val;
        }

        private uint ReadDCBrightness()
        {
            uint val = 0;
            WindowsSevenNativeFunctions.PowerReadDCValueIndex(
                IntPtr.Zero,
                ref currentPowerScheme,
                ref this.GUID_VIDEO_SUBGROUP,
                ref this.GUID_VIDEO_BRIGHTNESS,
                ref val);

            return val;
        }
    }
}