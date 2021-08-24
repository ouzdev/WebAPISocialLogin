using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Entities.Dtos;
using WebAPISocialLogin.Models.Abstract;
using WebAPISocialLogin.Services.Abstract;
using WebAPISocialLogin.Utilities.Result;

namespace WebAPISocialLogin.Services.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper, ISkillService skillService)
        {
            _userDal = userDal;
            _mapper = mapper;
            _skillService = skillService;
        }
        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result, "");
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<User>(result, "Kullanıcı Bulunamadı");

            }
            return new SuccessDataResult<User>(result, "Kullanıcı Getirildi");
        }
        public IDataResult<User> GetByMail(string mail)
        {
            User user = _userDal.Get(p => p.Email == mail);
            if (user == null)
            {
                return new ErrorDataResult<User>(user, "");
            }
            else
            {
                return new SuccessDataResult<User>(user, "");
            }
        }
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("");
        }
        //[SecuredOperation("user.add,administrator")]
        //[ValidationAspect(typeof(UserValidator))]
        //[CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("");
        }

        public IResult SetUserUpdate(UserForSetUserDto userDto)
        {
            User getUser = _userDal.Get(x => x.Id == userDto.Id);
            getUser.Address = userDto.Address;
            getUser.City = userDto.City;
            getUser.County = userDto.County;
            getUser.EducationInfo = userDto.EducationInfo;
            getUser.ProfileAvatarUrl = userDto.ProfileAvatarUrl;
            getUser.Tel = userDto.Tel;
            getUser.FirstName = userDto.FirstName;
            getUser.LastName = userDto.LastName;
            var entity = _userDal.Update(getUser);
            if (entity !=null)
            {
                List<Skill> items = new();
                foreach (Skill item in userDto.skills)
                {
                 var skill =   new Skill { SkillDescription = item.SkillDescription, SkillName = item.SkillName, UserId = entity.Id };
                 _skillService.Add(skill);
                }
                return new SuccessResult("Kayit Güncelleştirildi");
            }
            return new ErrorResult();
        }
    }
}
