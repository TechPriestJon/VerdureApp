using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.Mobile.DataAccess
{
    public class DeletableGuidEntityRepository<T> : GuidEntityRepository<T>, IGuidRepository<T> 
        where T : class, IVerdureGuidEntity, IVerdureDeletableEntity
    {
        public DeletableGuidEntityRepository(DbContext db) : base(db)
        { }
        public async new Task Delete(Guid id)
        {
            var entity = await Get(id);
            entity.Delete();
            await SaveAsync();
        }
    }
}
