using Microsoft.AspNetCore.Mvc;

namespace NFCReader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public int GetGuid()
        {
            var a = 15;
            return a;
        }
    }
}
