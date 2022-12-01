using BLL.DTO;
using BLL.Services.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace BLL.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly INfcReaderService _nfcReaderService;
        private readonly HttpClient client;
        public GeneralService(INfcReaderService nfcReaderService)
        {
            _nfcReaderService = nfcReaderService;
            client = new HttpClient();
        }

        public async Task StartReader(string id)
        {
            //var id = Guid.NewGuid();

            var nfcReaderResult = await _nfcReaderService.GetDataFromReader();

            var user = new UserDTO()
            {
                Password = nfcReaderResult.Password,
                Email = nfcReaderResult.Email,
                Id = Guid.Parse(id),
                Name = "Name"
            };

            await CallCloudBackEnd(user);

        }

        private async Task CallCloudBackEnd(UserDTO user)
        {


            var url = await CreateProductAsync(user);
        }

        async Task<HttpStatusCode> CreateProductAsync(UserDTO user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:7079/api/UserInfo", user);

            // return URI of the created resource.
            return response.StatusCode;
        }
    }
}
