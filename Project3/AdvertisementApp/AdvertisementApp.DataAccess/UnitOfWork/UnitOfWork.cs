using AdvertisementApp.DataAccess.Contexts;
using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.DataAccess.Repositories;
using AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.UnitOfWork
{
  public class UnitOfWork:IUnitOfWork
    {

        private readonly AdvertisementAppContext _context;

        public UnitOfWork(AdvertisementAppContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
