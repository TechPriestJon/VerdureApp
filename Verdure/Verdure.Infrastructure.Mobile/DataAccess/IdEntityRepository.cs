using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.Mobile.DataAccess
{
    public class IdEntityRepository<T> : BaseRepository<T>, IIdRepository<T> where T : class, IVerdureIdEntity
    {
        public IdEntityRepository(DbContext db) : base(db)
        { }
        public async Task Delete(long id)
        {
            _db.Set<T>().Remove(await Get(id));
            await SaveAsync();
        }

        public async Task<T> Get(long id)
        {
            return await _db.Set<T>().FirstAsync(x => x.Id == id);
        }
    }
}
