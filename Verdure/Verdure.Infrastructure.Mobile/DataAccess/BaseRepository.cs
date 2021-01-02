using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verdure.Domain.Interfaces;
using Verdure.Infrastructure.EFCore;

namespace Verdure.Infrastructure.Mobile.DataAccess
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;

        public BaseRepository(DbContext db)
        {
            _db = db;
        }

        public async Task Create(T entity)
        {
            _db.Set<T>().Add(entity);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public VerdureEfcContext GetVerdureContext()
        {
            return _db as VerdureEfcContext;
        }
    }
}
