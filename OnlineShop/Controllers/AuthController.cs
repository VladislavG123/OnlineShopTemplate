using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;

namespace OnlineShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService userService;

        public AuthController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(string phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await userService.Authenticate(phoneNumber);

            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

        [HttpPost]
        public async Task<IActionResult> Registrate(string fullName, string phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await userService.Registrate(fullName, phoneNumber);

            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}