using BLL.DTO;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NFCReader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAuthService _generalService;

        public UserController(IUserAuthService generalService)
        {
            _generalService = generalService;
        }

        [HttpPost]
        public async Task<IActionResult> StartNfcReader([FromBody] WebGuidDTO id)
        {
            await _generalService.StartReader(id.Id);
            return Ok();
        }
    }
}
