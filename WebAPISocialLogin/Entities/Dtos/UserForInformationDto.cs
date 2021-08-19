using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities.Abstract;

namespace WebAPISocialLogin.Entities.Dtos
{
    public class UserForInformationDto:IDto
    {
        public string Email { get; set; }

    }
}
