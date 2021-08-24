using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Utilities.Result;

namespace WebAPISocialLogin.Services.Abstract
{
    public interface ISkillService
    {
        IResult Add(Skill user);
        IResult AddRange(List<Skill> user);

        IResult Update(Skill user);
        IResult Delete(Skill user);
        IDataResult<Skill> GetById(int id);
        IDataResult<Skill> GetByUserIdForSkill(int id);

    }
}
