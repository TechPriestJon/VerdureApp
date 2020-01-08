using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.Mobile.DataAccess
{
    public interface IGuidRepository<T> : IRepository<T> where T : class, IVerdureGuidEntity
    {
        Task<T> Get(Guid id);

        Task Delete(Guid id);

    }
}
