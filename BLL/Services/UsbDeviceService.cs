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
            using (_collection = _searcher.Get())
            {
                foreach (var device in _collection)
                {
                    devices.Add(new(
                        (string)device.GetPropertyValue("DeviceID"),
                        (string)device.GetPropertyValue("PNPDeviceID"),
                        (string)device.GetPropertyValue("Description")
                    ));
                }

                return devices;
            }
        }

        //public List<UsbDeviceInfoDTO> Test()
        //{
        //    WqlEventQuery query = new WqlEventQuery(
        //            "SELECT * FROM Win32_USBHub");

        //    ManagementObject

        //        ManagementEventWatcher watcher = new ManagementEventWatcher(query);
        //        Console.WriteLine("Waiting for an event...");


        //}

    }
}
