using BLL.DTO;
using BLL.Services.Interfaces;
using System.Diagnostics;

namespace BLL.Services
{
    public class UsbListenerService : IUsbListenerService
    {
        private IUsbDeviceService _usbService;


        private readonly TimeSpan WaitTime = TimeSpan.FromSeconds(10);

        public UsbListenerService(IUsbDeviceService deviceService)
        {
            _usbService = deviceService;
        }

        public UsbDeviceInfoDTO StartListen()
        {
            var watch = Stopwatch.StartNew();
            var newDevices = new List<UsbDeviceInfoDTO>();
            while (true)
            {
                newDevices = _usbService.GetUSBDevices();

                newDevices = newDevices.ExceptBy(
                        _usbService.StaticDevices.Select(e => e.DeviceId), e => e.DeviceId)
                    .ToList();

                if (newDevices.Any())
                {
                    return newDevices.First();
                }

                if (watch.Elapsed > WaitTime)
                    return new();
                Task.Delay(20).Wait();
            }
        }
    }
}
