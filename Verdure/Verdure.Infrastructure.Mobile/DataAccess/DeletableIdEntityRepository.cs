using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.Mobile.DataAccess
{
    public class DeletableIdEntityRepository<T> : IdEntityRepository<T>, IIdRepository<T> 
        where T : class, IVerdureIdEntity, IVerdureDeletableEntity
    {
        public DeletableIdEntityRepository(DbContext db) : base(db)
        { }
        public async new Task Delete(long id)
        {
            var entity = await Get(id);
            entity.Delete();
            await SaveAsync();
        }
    }
}
