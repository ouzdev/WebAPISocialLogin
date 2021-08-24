using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillsController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpPost("add-skill")]
        public IActionResult SetUser([FromBody] SkillDto skill)
        {
            var result = _skillService.Add(_mapper.Map<Skill>(skill));
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
    }
}
