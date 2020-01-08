using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.Mobile.DataAccess
{
    public interface IIdRepository<T> : IRepository<T> where T : class, IVerdureIdEntity
    {
        Task<T> Get(long id);

        Task Delete(long id);
    }
}
