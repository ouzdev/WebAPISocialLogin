using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Services.Abstract;
using WebAPISocialLogin.Utilities.Result;

namespace WebAPISocialLogin.Services.Concrete
{
    public class SkillManager : ISkillService
    {
        public IResult Add(Skill user)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Skill user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Skill> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Skill> GetByUserIdForSkill(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Skill user)
        {
            throw new NotImplementedException();
        }
    }
}
