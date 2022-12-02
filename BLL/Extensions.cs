using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class Extensions
    {
        public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserAuthService, UserAuthService>();
            services.AddScoped<INfcReaderService, NfcReaderService>();
            services.AddTransient<IHttpService, HttpService>();
        }
    }
}
