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
            getUser = _mapper.Map<User>(userDto);

            throw new NotImplementedException();
        }
    }
}
