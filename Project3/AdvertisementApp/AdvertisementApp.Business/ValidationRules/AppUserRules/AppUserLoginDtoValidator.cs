using AdvertisementApp.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules.AppUserRules
{
    public class AppUserLoginDtoValidator: AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
             RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş olamaz");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Kullanıcı Adı Boş olamaz");
        }
    }
}
