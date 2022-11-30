using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NFCReader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGeneralService _generalService;

        public UserController(IGeneralService generalService)
        {
            _generalService = generalService;
        }

        [HttpGet]
        public async Task<Guid> StartNFCReader()
        {
            var id = await _generalService.StartReader();
            return id;

        }
    }
}
