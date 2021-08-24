using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISocialLogin.Entities.Dtos
{
    public class UserForSetUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string ProfileAvatarUrl { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address { get; set; }
        public string EducationInfo { get; set; }
        public List<Skill> skills { get; set; }
    }
}
