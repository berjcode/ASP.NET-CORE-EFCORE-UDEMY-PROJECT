using AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Configurations
{
    public class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x=>x.FirsName).HasMaxLength(200).IsRequired();
            builder.Property(X=> X.SurName).HasMaxLength(200).IsRequired();
            builder.Property(X => X.UserName).HasMaxLength(100).IsRequired();
            builder.Property(X => X.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(X => X.Password).HasMaxLength(50).IsRequired();


            //iLİŞKİ

            builder.HasOne(x => x.Gender).WithMany(x => x.AppUsers).HasForeignKey(x => x.GenderId);
        }
    }
}
