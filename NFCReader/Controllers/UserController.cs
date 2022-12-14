using BLL.DTO;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace NFCReader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;

        public UserController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        [HttpPost]
        public async Task<IActionResult> StartNfcReader([FromBody] WebGuidDTO id)
        {
            await _userAuthService.StartReader(id.Id);
            return Ok();
        }
    }
}
