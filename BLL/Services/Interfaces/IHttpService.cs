using BLL.DTO;
using System.Net;

namespace BLL.Services.Interfaces
{
    public interface IHttpService
    {
        Task<HttpStatusCode> CallCloudBackEnd(UserAuthDTO user);
    }
}
