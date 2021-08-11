using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPISocialLogin.Entities;

namespace WebAPISocialLogin.Models.Context
{
    public class SocialLoginContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Scaffold - DbContext "server=DESKTOP-51P73VP; database=OG.RecapProjectDb; integrated security=true;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models
            optionsBuilder.UseSqlServer(@"server=DESKTOP-51P73VP; database=OG.SocialLoginDb; integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
