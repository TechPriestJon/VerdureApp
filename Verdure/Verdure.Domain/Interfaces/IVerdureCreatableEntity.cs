using System;

namespace Verdure.Domain.Interfaces
{
    public interface IVerdureCreatableEntity
    {
        DateTimeOffset CreatedDate { get; }
    }
}
