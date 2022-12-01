using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IHttpService
    {
        Task CallCloudBackEnd(UserAuthDTO user);
    }
}
