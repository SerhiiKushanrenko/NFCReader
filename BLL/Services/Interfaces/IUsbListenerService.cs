using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IUsbListenerService
    {
        public UsbDeviceInfoDTO StartListen();
    }
}
