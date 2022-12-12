using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules.AdvertisementAppUserRules
{
   public class AdvertisementAppUserCreateDtoValidator: AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            this.RuleFor(x => x.AdvertisementAppUserStatusId).NotEmpty();
            this.RuleFor(x=>x.AdvertisementId).NotEmpty();
            this.RuleFor(x=>x.AppUserId).NotEmpty();
            this.RuleFor(x=>x.CvPath).NotEmpty();
            this.RuleFor(x=>x.EndDate).NotEmpty().When(x=>x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli);
            this.RuleFor(x=>x.WorkExperience).NotEmpty();
        }
    }
}
