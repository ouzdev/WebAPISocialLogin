using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;
using WebAPISocialLogin.Entities.Dtos;
using WebAPISocialLogin.Models.Abstract;
using WebAPISocialLogin.Models.Context;
using WebAPISocialLogin.Utilities.Result;

namespace WebAPISocialLogin.Models.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, SocialLoginContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new SocialLoginContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public IResult SetUserUpdate(User user)
        {
            using (var context = new SocialLoginContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                try
                {
                        var resultUser = context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                        context.Entry(resultUser).CurrentValues.SetValues(user);
                        context.SaveChanges();

                       

                }
                catch (Exception ex)
                {

                    throw;
                }
                }
            }
            return null;
        }
    }
}
