using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Configurations
{
    public class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(new UserRole
            {
               RoleId= 1,
               UserId= 1,

            });
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasOne(x=>x.Role).WithMany(x=>x.Roles).HasForeignKey(x=>x.RoleId);
            builder.HasOne(x => x.User).WithMany(x => x.Roles).HasForeignKey(x=>x.UserId);
        }
    }
}
