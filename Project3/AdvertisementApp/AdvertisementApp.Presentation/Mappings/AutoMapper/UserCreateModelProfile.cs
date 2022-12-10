using AdvertisementApp.Dtos;
using AdvertisementApp.Presentation.Models;
using AutoMapper;

namespace AdvertisementApp.Presentation.Mappings.AutoMapper
{
    public class UserCreateModelProfile:Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>();
        }
    }
}
