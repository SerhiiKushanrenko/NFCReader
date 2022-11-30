using BLL.DTO;
using BLL.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BLL.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly INfcReaderService _nfcReaderService;
        static HttpClient client = new();
        public GeneralService(INfcReaderService nfcReaderService)
        {
            _nfcReaderService = nfcReaderService;
        }

        public async Task<Guid> StartReader()
        {
            var id = Guid.NewGuid();

            var nfcReaderResult = _nfcReaderService.GetDataFromReader();

            var user = new UserDTO()
            {
                Password = nfcReaderResult.Password,
                Email = nfcReaderResult.Email,
                Id = id,
                Name = "Name"
            };

            // await CallCloudBackEnd(user);
            return id;
        }

        private async Task CallCloudBackEnd(UserDTO user)
        {
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var url = await CreateProductAsync(user);
        }

        static async Task<HttpStatusCode> CreateProductAsync(UserDTO user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/products", user);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.StatusCode;
        }

    }
}
