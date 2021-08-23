using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Entities.Dtos;
using WebAPISocialLogin.Services.Abstract;

namespace WebAPISocialLogin.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost("get-user")]
        public IActionResult GetUser([FromBody] UserForInformationDto user)
        {
            return Ok(_userService.GetByMail(user.Email));
        }
        [HttpPost("set-user")]
        public IActionResult SetUser([FromBody] UserForSetUserDto user)
        {
            var result = _userService.SetUserUpdate(user);
            return Ok(/*_userService.Update(user.Email)*/);
        }
    }
}
