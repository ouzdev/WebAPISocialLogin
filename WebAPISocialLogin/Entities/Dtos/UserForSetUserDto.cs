using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISocialLogin.Entities.Dtos
{
    public class UserForSetUserDto
    {
        public User User { get; set; }
        public List<Skill> Skill { get; set; }
    }
}
