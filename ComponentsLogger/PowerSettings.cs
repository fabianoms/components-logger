using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ComponentsLogger.Native;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ComponentsLogger
{
    public class PowerSettings
    {
        public static Guid GetActivePowerScheme()
        {
            IntPtr ptrActiveGuid = IntPtr.Zero;
            uint res = WindowsSevenNativeFunctions.PowerGetActiveScheme(IntPtr.Zero, ref ptrActiveGuid);
            if (res != 0)
                throw new Exception("Error reading current power scheme. Native Win32 error code = " + res);

            var activeSchemeGuid = (Guid)Marshal.PtrToStructure(ptrActiveGuid, typeof(Guid));
            return activeSchemeGuid;
        }

        public static PowerLineStatus GetPowerSource()
        {
            return SystemInformation.PowerStatus.PowerLineStatus;
        }
    }

    
}
