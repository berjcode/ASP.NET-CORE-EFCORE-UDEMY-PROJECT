using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.Interfaces;

namespace BankApp.Web.Data.Repositories
{
    public class UserRepository :IUserRepository
    {

        private readonly BankContext _context;

        public UserRepository(BankContext context)
        {
            _context = context;
        }

        public List<User> GetAll() 
        { 
            return  _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x=>x.Id ==id);
        }
    }
}
