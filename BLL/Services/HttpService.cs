﻿using BLL.DTO;
using BLL.Services.Interfaces;
using System.Net;
using System.Net.Http.Json;

namespace BLL.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient client;

        public HttpService(HttpClient httpClient)
        {
            client = httpClient;
        }
        public async Task<HttpStatusCode> UserAuthOnCloudBackEndAsync(UserAuthDTO user)
        {
            return await SendUserDataCredAsync(user);
        }

        private async Task<HttpStatusCode> SendUserDataCredAsync(UserAuthDTO user)
        {
            var response = await client.PostAsJsonAsync(
                "https://localhost:7079/api/UserInfo", user);
            //"https://cloudnfc.tk/api/UserInfo", user);
            // https://localhost:7079/api/UserInfo
            // 
            // return URI of the created resource.
            return response.StatusCode;
        }
    }
}
