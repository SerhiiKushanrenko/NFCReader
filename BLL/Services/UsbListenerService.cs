using BLL.DTO;
using BLL.Services.Interfaces;
using System.Diagnostics;

namespace BLL.Services
{
    public class UsbListenerService : IUsbListenerService
    {
        private IUsbDeviceService _usbService;
        private List<UsbDeviceInfoDTO> _staticDevices;

        private readonly TimeSpan WaitTime = TimeSpan.FromSeconds(20);

        public UsbListenerService(IUsbDeviceService deviceService)
        {
            _usbService = deviceService;
            _staticDevices = _usbService.GetUSBDevices();
        }

        public UsbDeviceInfoDTO StartListen()
        {
            var watch = Stopwatch.StartNew();
            var newDevices = new List<UsbDeviceInfoDTO>();
            while (true)
            {
                newDevices = _usbService.GetUSBDevices();

                newDevices = newDevices.ExceptBy(
                        _staticDevices.Select(e => e.DeviceId), e => e.DeviceId)
                    .ToList();

                if (newDevices.Any())
                {
                    return newDevices.First();
                }

                if (watch.Elapsed > WaitTime)
                    return new();
            }
        }
    }
}
