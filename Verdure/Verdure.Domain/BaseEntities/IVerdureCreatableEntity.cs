using System;

namespace Verdure.Domain.Base
{
    public interface IVerdureCreatableEntity
    {
        DateTimeOffset CreatedDate { get; }
    }
}
