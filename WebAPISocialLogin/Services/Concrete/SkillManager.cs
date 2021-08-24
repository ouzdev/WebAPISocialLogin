using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Models.Abstract;
using WebAPISocialLogin.Services.Abstract;
using WebAPISocialLogin.Utilities.Result;

namespace WebAPISocialLogin.Services.Concrete
{
    public class SkillManager : ISkillService
    {
        private readonly ISkillDal _skillDal;
        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }
        public IResult Add(Skill user)
        {
            var skillResult = _skillDal.Add(user);
            return new SuccessResult("Yetenek Eklendi");
        }

        public IResult AddRange(List<Skill> user)
        {
            _skillDal.AddRange(user);
            return new SuccessResult();
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
