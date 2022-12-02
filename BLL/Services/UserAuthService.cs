using BLL.DTO;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly INfcReaderService _nfcReaderService;
        private readonly IHttpService _httpService;


        public UserAuthService(INfcReaderService nfcReaderService, IHttpService httpService)
        {
            _nfcReaderService = nfcReaderService;
            _httpService = httpService;
        }

        public async Task StartReader(string id)
        {
            var nfcReaderResult = await _nfcReaderService.GetDataFromReader();

            var user = new UserAuthDTO()
            {
                Password = nfcReaderResult.Password,
                Email = nfcReaderResult.Email,
                Id = Guid.Parse(id),
                Name = "Name"
            };

            await Task.Delay(1000);
            await _httpService.CallCloudBackEnd(user);
        }


    }
}
