using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Entities.Dtos;
using WebAPISocialLogin.Models.Dtos;
using WebAPISocialLogin.Services.Abstract;
using WebAPISocialLogin.Utilities.Result;
using WebAPISocialLogin.Utilities.Security.JWT;

namespace WebAPISocialLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;

        public AuthController(IAuthService authService,IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        [AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
               var user = _userService.GetById(userToLogin.Data.Id);
                user.Data.RefreshToken = result.Data.RefreshToken;
                user.Data.RefreshTokenEndDate = result.Data.Expiration.AddMinutes(5);
                _userService.Update(user.Data);
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }
            var registerResult = _authService.Register(userForRegisterDto);
            if (registerResult.Success)
            {
                return Ok(registerResult);
            }
            return BadRequest(registerResult);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest data)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

            // Change this to your google client ID
            settings.Audience = new List<string>() { "801016782283-784v61mh7evldvf035t0o6k6fefhvovs.apps.googleusercontent.com" };

            GoogleJsonWebSignature.Payload payload = GoogleJsonWebSignature.ValidateAsync(data.IdToken, settings).Result;
            var result = _userService.GetByMail(payload.Email);
            if (result.Success)
            {
                return Ok(new { AuthToken = _authService.CreateAccessToken(new User { Email = payload.Email }) });

            }
            else
            {
                return Ok(result);
            }
        }
    }
}
