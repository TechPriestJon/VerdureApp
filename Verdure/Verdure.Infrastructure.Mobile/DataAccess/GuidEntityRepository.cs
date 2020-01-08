using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.Mobile.DataAccess
{
    public class GuidEntityRepository<T> : BaseRepository<T>, IGuidRepository<T> where T : class, IVerdureGuidEntity
    {
        public GuidEntityRepository(DbContext db) : base(db)
        {   }

        public async Task Delete(Guid id)
        {
            _db.Set<T>().Remove(await Get(id));
            await SaveAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _db.Set<T>().FirstAsync(x => x.Id == id);
        }
    }
}
