using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SMSGatewayAPI.Models;
using SMSGatewayAPI.Services;
using SMSGatewayAPI.Exceptions;
using SMSGatewayAPI.Shared;
using SMSGatewayProject.Shared.V1.Responses;
using SMSGatewayProject.Shared.V1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SMSGatewayProject.Shared;

namespace SMSGatewayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private IMailService _mailService;
        private IConfiguration _configuration;

        public AuthController(IUserService userService, IMailService mailService,IConfiguration configuration)
        {
            _userService = userService;
            _mailService = mailService;
            _configuration = configuration;
        }

        // /api/auth/register
        [HttpPost("Register")]
        [ProducesResponseType(200, Type = typeof(ApiResponse))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
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

            return BadRequest("Internal Server Error"); //Status code : 400
         }

        // /api/auth/login
        [HttpPost("Login")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AccessTokenResult>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        public async Task<IActionResult> LoginAsync([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    await _mailService.SendEmailAsync(model.Email, "New login", "<h1>New login to your account noticed<h1><p>New login to your account at " + DateTime.Now + "<p>");
                    return Ok(result);
                }

                return BadRequest(result);

            }

            return BadRequest("Internal Server Error"); //Status code : 400
        }

        // /api/auth/confirmemail?userId&token
        [HttpGet("ConfirmEmail")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AccessTokenResult>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(string.IsNullOrWhiteSpace(userId) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            var result = await _userService.ConfirmEmailAsync(userId, token);

            if (result.IsSuccess)
            {
                //TO DO : Redirect to main page of client
                return Redirect($"{_configuration["AppUrl"]}/ConfirmEmail.html");
            }

            return BadRequest(result);
        }

        // api/auth/forgetpassword
        [HttpPost("ForgetPassword")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AccessTokenResult>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return NotFound();
            }

            var result = await _userService.ForgetPasswordAsync(email);

            if (result.IsSuccess)
            {
                return Ok(result); //200
            }

            return BadRequest("Internal Server Error"); //Status code : 400
        }

        // api/auth/resetpassword
        [HttpPost("ResetPassword")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AccessTokenResult>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        public async Task<IActionResult> ResetPassword([FromForm]ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ResetPasswordAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Internal Server Error"); //Status code : 400
        }


    }
}
