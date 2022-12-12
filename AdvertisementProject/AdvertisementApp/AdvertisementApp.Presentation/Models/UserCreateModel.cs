using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvertisementApp.Presentation.Models
{
    public class UserCreateModel
    {
        public string FirsName { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }

        public int GenderId { get; set; }

        public SelectList Genders { get; set; }
    }
}
