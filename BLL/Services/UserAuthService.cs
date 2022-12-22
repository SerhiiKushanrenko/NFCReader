using BLL.DTO;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class UserAuthService : IUserAuthService
    {

        private readonly IHttpService _httpService;
        private readonly IUsbListenerService _usbListenerService;


        public UserAuthService(IHttpService httpService, IUsbListenerService usbListenerService)
        {

            _httpService = httpService;
            _usbListenerService = usbListenerService;
        }

        public async Task StartUserAuth(string id)
        {
            var deviceId = _usbListenerService.StartListenUsbPosts();

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
