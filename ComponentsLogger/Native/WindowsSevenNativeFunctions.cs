using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ComponentsLogger.Native
{
    public class WindowsSevenNativeFunctions
    {
        [DllImportAttribute("powrprof.dll", EntryPoint = "PowerGetActiveScheme")]
        public static extern uint PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll", SetLastError = true, EntryPoint =
            "PowerReadACValueIndex")]
        public static extern uint PowerReadACValueIndex(
            IntPtr RootPowerKey,
            ref Guid SchemeGuid,
            ref Guid SubGroupOfPowerSettingsGuid,
            ref Guid PowerSettingGuid,
            ref uint AcValueIndex);

        [DllImport("powrprof.dll", SetLastError = true, EntryPoint =
            "PowerReadDCValueIndex")]
        public static extern uint PowerReadDCValueIndex(
            IntPtr RootPowerKey,
            ref Guid SchemeGuid,
            ref Guid SubGroupOfPowerSettingsGuid,
            ref Guid PowerSettingGuid,
            ref uint DcValueIndex);
    }
}
