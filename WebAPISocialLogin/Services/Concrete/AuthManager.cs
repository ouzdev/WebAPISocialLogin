using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Entities.Dtos;
using WebAPISocialLogin.Models.Dtos;
using WebAPISocialLogin.Services.Abstract;
using WebAPISocialLogin.Utilities.Result;
using WebAPISocialLogin.Utilities.Security.Hashing;
using WebAPISocialLogin.Utilities.Security.JWT;
using WebAPISocialLogin.Utilities.Security.JWT.Abstract;

namespace WebAPISocialLogin.Services.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kullanıcı Kayıt Oldu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheck.Success)
            {
                return new ErrorDataResult<User>(userToCheck.Data, "Kullanıcı Bulunamadı");
            }

            if (!HashingHelper.VerifyPassowrdHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(userToCheck.Data, "Şifre Hatalı");
            }

            return new SuccessDataResult<User>(userToCheck.Data, "Giriş Başarılı. Yönlendiriliyorsunuz...");
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Success)
            {
                return new ErrorResult("Kullanıcı Zaten Mevcut");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Token Oluşturuldu");
        }

        //Refresh Token üretecek metot.
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
