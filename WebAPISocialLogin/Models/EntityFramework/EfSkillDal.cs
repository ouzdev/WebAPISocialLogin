using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Models.Abstract;
using WebAPISocialLogin.Models.Context;

namespace WebAPISocialLogin.Models.EntityFramework
{
    public class EfSkillDal: EfEntityRepositoryBase<Skill, SocialLoginContext>, ISkillDal
    {
    }
}
