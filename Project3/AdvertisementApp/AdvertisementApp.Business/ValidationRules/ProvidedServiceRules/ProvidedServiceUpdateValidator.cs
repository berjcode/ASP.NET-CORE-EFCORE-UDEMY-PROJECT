using AdvertisementApp.Dtos.ProvidedServicesDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules.ProvidedServiceRules
{
   public class ProvidedServiceUpdateValidator : AbstractValidator<ProvidedServiceUpdateDto>
    {

        public ProvidedServiceUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x=> x.Description).NotEmpty();
            RuleFor(x=> x.Title).NotEmpty();
            RuleFor(x=> x.ImagePath).NotEmpty();
        }
    }

}
