using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;

namespace BankApp.Web.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {

        private readonly BankContext _context;

        public UnitOfWork (BankContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T: class, new()
        {
            return new Repository<T>(_context);
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }



    }
}
