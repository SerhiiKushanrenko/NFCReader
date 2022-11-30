namespace BLL.Services.Interfaces
{
    public interface IGeneralService
    {
        public Task<Guid> StartReader();
    }
}
