using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSGatewayAPI.Services;
using SMSGatewayAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSGatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // /api/auth/register
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result); //Status code : 200
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid"); //Status code : 400
        }
    }
}
