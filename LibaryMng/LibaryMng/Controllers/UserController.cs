using LibaryMng.Entities;
using LibaryMng.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibaryMng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get([FromQuery] string userName, string password)
        {

            if (_userService.getUser(userName, password) != null)
            {
                User user = await _userService.getUser(userName, password);
                return Ok(user);
            }

            return NotFound();
        }


    }
}



  