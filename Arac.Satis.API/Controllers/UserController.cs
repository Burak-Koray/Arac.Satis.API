using Arac.Satis.API.Controllers.Base;
using Arac.Satis.Model.UserDtos;
using Arac.Satis.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arac.Satis.API.Controllers
{
    
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        public LoginDto Login([FromBody] LoginInputDto loginInputDto)
        {
            UserManager userManager = new();
            Shared shared = new();
            UserDto userDto = userManager.LoginCheck(loginInputDto.Username, loginInputDto.Password);

            if (userDto != null)
            {
                return new LoginDto()
                {
                    Webtoken = shared.GenerateToken(userDto),
                };
            }

            return new LoginDto();
        }

        [HttpGet("GetNameSurname")]
        public string GetNameSurname()
        {
            Shared shared = new();
            string token = HttpContext.Request.Headers["Authorization"];

            return shared.GetNameSurname(token);
        }
    }
}
