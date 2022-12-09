using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IUsbDeviceService
    {
        public List<UsbDeviceInfoDTO> GetUSBDevices();
    }
}
