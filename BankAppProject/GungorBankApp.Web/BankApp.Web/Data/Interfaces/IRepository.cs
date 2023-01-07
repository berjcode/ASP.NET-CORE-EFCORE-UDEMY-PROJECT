namespace BankApp.Web.Data.Interfaces
{
    public interface IRepository<T> where T : class,new()
    {
        void Create(T entity);
        void Remove(T entity);
        List<T> GetAll();
        T GetByID(object id);
        void Update(T entity);

        IQueryable<T> GetQueryAble();

    }
}
