using BankApp.Web.Data.Entities;

namespace BankApp.Web.Data.Interfaces
{
    public interface IUserRepository
    {

        List<User> GetAll();
        User GetById(int id);
    }
}
