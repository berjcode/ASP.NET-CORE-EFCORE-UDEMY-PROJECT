using BankApp.Web.Data.Entities;
using BankApp.Web.Models;

namespace BankApp.Web.Mapping
{
    public interface IUserMapper
    {

        List<UserListModel> MapToIfUserList(List<User> users);
        UserListModel MapToUserList(User user);
    }
}
