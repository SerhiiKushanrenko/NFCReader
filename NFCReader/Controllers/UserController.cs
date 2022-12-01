using BLL.DTO;
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

        [HttpPost]
        public async Task<IActionResult> StartNFCReader([FromBody] GuidDTO id)
        {
            await _generalService.StartReader(id.Id);
            return Ok();
        }
    }
}
