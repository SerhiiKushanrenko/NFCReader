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
        public async Task<IActionResult> StartNfcReader([FromBody] string id)
        {
            await _userAuthService.StartUserAuth(id);
            return Ok();
        }
    }
}
