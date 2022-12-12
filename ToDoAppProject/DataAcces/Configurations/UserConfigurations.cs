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
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id= 1,
                UserName="Abdullah",
                Password="123456"
            }); 
            builder.Property(x=>x.Password).HasMaxLength(100).IsRequired();
            builder.Property(x =>x.UserName).HasMaxLength(100).IsRequired();
        }
    }
}
