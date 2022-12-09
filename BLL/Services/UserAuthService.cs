using BLL.DTO;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly INfcReaderService _nfcReaderService;
        private readonly IHttpService _httpService;
        private readonly IUsbListenerService _usbListenerService;


        public UserAuthService(INfcReaderService nfcReaderService, IHttpService httpService, IUsbListenerService usbListenerService)
        {
            _nfcReaderService = nfcReaderService;
            _httpService = httpService;
            _usbListenerService = usbListenerService;
        }

        public async Task StartReader(string id)
        {
            // First Version of Data
            //var nfcReaderResult = await _nfcReaderService.GetDataFromReader();
            var deviceId = _usbListenerService.StartListen();
            var resultId = deviceId.GetUniqueDeviceID();

            var user = new UserAuthDTO()
            {
                UsbDeviceId = deviceId.GetUniqueDeviceID(),
                DeviceId = Guid.Parse(id),
                Name = "Sam"
            };




            await Task.Delay(1000);
            await _httpService.CallCloudBackEnd(user);
        }


    }
}
