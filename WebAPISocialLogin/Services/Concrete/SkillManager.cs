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
            _skillDal.Delete(user);
            return new SuccessResult("Yetenek Silindi.");
        }

        public IDataResult<Skill> GetById(int id)
        {
            var result = _skillDal.Get(u => u.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Skill>(result, "Yetenek Bulunamadı");

            }
            return new SuccessDataResult<Skill>(result, "Yetenek Bulundu");
        }

        public IDataResult<List<Skill>> GetByUserIdForSkill(int id)
        {
            List<Skill> userSkills = _skillDal.GetAll(x => x.UserId == id);
            return new SuccessDataResult<List<Skill>>(userSkills, "Yetenekler Listelendi");
        } 

        public IResult Update(Skill user)
        {
            throw new NotImplementedException();
        }
    }
}
