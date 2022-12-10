using AdvertisementApp.Presentation.Models;
using FluentValidation;

namespace AdvertisementApp.Presentation.ValidationRules.UserCreateModeValidator
{
    public class UserCreateModelValidator:AbstractValidator<UserCreateModel>
    {
  
        public UserCreateModelValidator()
        {

         
            //Password
            RuleFor(x=> x.Password).NotEmpty().WithMessage("Şifre Boş olamaz.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Numara Boş olamaz.");
            RuleFor(x => x.Password).MinimumLength(3);
            RuleFor(x=> x.Password).Equal(x=>x.ConfirmPassword).WithMessage("Şifreler uyuşmuyor.");
            RuleFor(x=>x.FirsName).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyisim Boş Olamaz");
            //UserName
            RuleFor(x=> new
            {
                x.UserName,
                x.FirsName
             }).Must(x => CanNotFirstName(x.UserName,x.FirsName)).WithMessage("Kullanıcı adı İsminizi içeremez.").When(x=>x.UserName != null &&x.FirsName !=null );
            RuleFor(x=>x.GenderId).NotEmpty().WithMessage("Cinsiyet Boş Olamaz");
          
           


        }

        private bool CanNotFirstName(string username, string firstname)
        {
            return !username.Contains(firstname);
        }


    }
}
