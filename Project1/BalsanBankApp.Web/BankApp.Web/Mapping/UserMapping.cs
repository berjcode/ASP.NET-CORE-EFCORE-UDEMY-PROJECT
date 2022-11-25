using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public class UserMapping :IUserMapper
    {


    public List<UserListModel> MapToIfUserList(List<User> users)
        {
            return users.Select(x => new UserListModel
            {
                Id= x.Id,
                Name= x.Name,   
                Surname= x.Surname,
            }).ToList();
        }




        public UserListModel MapToUserList(User user)
        {
            return new UserListModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
            };
        }
    }
}
