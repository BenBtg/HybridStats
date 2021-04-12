using System;
using System.Collections.Generic;
using System.Text;

namespace HybridStats.Core.Services
{
    public interface IDeviceInfo
    {
        public string DeviceName {get; }
        public string DeviceModel { get; }
        public string OsVersion { get; }
    }
}
