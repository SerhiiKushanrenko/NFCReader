using BLL.DTO;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class NfcReaderService : INfcReaderService
    {
        public async Task<NfcReaderDTO> GetDataFromReader()
        {
            var newNfcDto = new NfcReaderDTO()
            {
                Email = "Test@gmail.com",
                Password = "11111"
            };
            return newNfcDto;
        }
    }
}
