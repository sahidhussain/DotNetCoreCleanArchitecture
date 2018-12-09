using DotnetCore.Core.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCore.Infrastructure.Data
{
   public class ApplicationIdentityDbContext : IdentityDbContext<AppUsers, AppRole, long>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<InstituteDetail> InstituteDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.Entity<AppUsers>().ToTable("ApplicationUser");
            builder.Entity<IdentityUserRole<long>>().ToTable("UserRole");
            builder.Entity<IdentityUserLogin<long>>().ToTable("UserLogin");
            builder.Entity<IdentityUserClaim<long>>().ToTable("UserClaim");
            builder.Entity<AppRole>().ToTable("Role");
            builder.Entity<IdentityUserToken<long>>().ToTable("UserToken");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaim");
        }
    }
}
