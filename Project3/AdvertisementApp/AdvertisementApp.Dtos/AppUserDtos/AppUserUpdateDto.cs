using AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Dtos
{
    public class AppUserUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
     
        public string PhoneNumber { get; set; }

        public int GenderId { get; set; }



    }
}
