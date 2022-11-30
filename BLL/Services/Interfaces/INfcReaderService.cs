using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface INfcReaderService
    {
        public NfcReaderDTO GetDataFromReader();

    }
}
