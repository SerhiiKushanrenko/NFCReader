using BLL.DTO;
using BLL.Services.Interfaces;
using System.Management;

namespace BLL.Services
{
    public class UsbDeviceService : IUsbDeviceService
    {
        public List<UsbDeviceInfoDTO> GetUSBDevices()
        {
            var devices = new List<UsbDeviceInfoDTO>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                devices.Add(new(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PNPDeviceID"),
                    (string)device.GetPropertyValue("Description")
                ));
            }
            collection.Dispose();

            return devices;
        }
    }
}
