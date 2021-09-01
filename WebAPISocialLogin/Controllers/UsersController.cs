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
        private readonly ISkillService _skillService;

        public UsersController(IUserService userService, IMapper mapper,ISkillService skillService)
        {
            _userService = userService;
            _mapper = mapper;
            _skillService = skillService;
        }
        [HttpPost("get-user")]
        public IActionResult GetUser([FromBody] UserForInformationDto user)
            {
            var getUserInfo = _userService.GetByMail(user.Email);
            if (getUserInfo.Success)
            {
               var userSkills = _skillService.GetByUserIdForSkill(getUserInfo.Data.Id);
                return Ok(new UserForSetUserDto { User = getUserInfo.Data, Skill = userSkills.Data });
            }
            return Ok();
        }
        [HttpPost("set-user")]
        public IActionResult SetUser([FromBody] User user)
        {
            var result = _userService.SetUserUpdate(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
