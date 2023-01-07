using BankApp.Web.Data.Interfaces;

namespace BankApp.Web.Data.UnitOfWork
{
    public interface IUnitOfWork
    {

        IRepository<T> GetRepository<T>() where T : class, new();
        void SaveChanges();
    }
}
