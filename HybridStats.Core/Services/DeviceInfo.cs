using System.Diagnostics;

namespace HybridStats.Core.Services
{
    public class DeviceInfo : IDeviceInfo
    {
        public string DeviceName => "TestDevice";

        public string DeviceModel => "TestModel";

        public string OsVersion => "TestVersion";
    }
}
