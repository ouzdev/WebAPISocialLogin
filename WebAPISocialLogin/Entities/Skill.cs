using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities.Abstract;

namespace WebAPISocialLogin.Entities
{
    public class Skill:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }

    }
}
