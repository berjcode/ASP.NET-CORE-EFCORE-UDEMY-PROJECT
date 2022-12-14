using AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {

        IRepository<T> GetRepository<T>() where T : BaseEntity;
         Task SaveChangesAsync();
    }
}
