using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.Mobile.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);

        Task<IEnumerable<T>> Get();

        Task SaveAsync();

        VerdureEfcContext GetVerdureContext();
    }
}
