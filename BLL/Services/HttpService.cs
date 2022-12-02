using BLL.DTO;
using BLL.Services.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace BLL.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient client;

        public HttpService()
        {
            client = new HttpClient();
        }
        public async Task CallCloudBackEnd(UserAuthDTO user)
        {
            var url = await CreateProductAsync(user);
        }

        async Task<HttpStatusCode> CreateProductAsync(UserAuthDTO user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "http://localhost:8080/api/UserInfo", user);

            // return URI of the created resource.
            return response.StatusCode;
        }
    }
}
