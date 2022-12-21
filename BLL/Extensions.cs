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
            services.AddScoped<IUsbDeviceService, UsbDeviceService>();
            services.AddScoped<IUsbListenerService, UsbListenerService>();
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<HttpClient>();
        }
    }
}
