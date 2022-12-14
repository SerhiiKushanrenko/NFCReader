using BLL.DTO;
using BLL.Services.Interfaces;
using System.Management;

namespace BLL.Services
{
    public class UsbDeviceService : IUsbDeviceService
    {
        public List<UsbDeviceInfoDTO> StaticDevices { get; set; }
        private readonly ManagementObjectSearcher _searcher;
        private ManagementObjectCollection _collection { get; set; }


        public UsbDeviceService()
        {
            _searcher = new(@"Select * From Win32_USBHub");
            StaticDevices = GetUSBDevices();

        }
        public List<UsbDeviceInfoDTO> GetUSBDevices()
        {
            var devices = new List<UsbDeviceInfoDTO>();


            using (_searcher)
                _collection = _searcher.Get();

            foreach (var device in _collection)
            {
                devices.Add(new(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PNPDeviceID"),
                    (string)device.GetPropertyValue("Description")
                ));
            }
            _collection.Dispose();

            return devices;
        }
    }
}
