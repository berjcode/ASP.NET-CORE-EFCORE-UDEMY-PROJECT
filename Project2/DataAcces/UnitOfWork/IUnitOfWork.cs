using DataAcces.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.UnitOfWork
{
    public interface IUnitOfWork
    {

        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChanges();
    }
}
