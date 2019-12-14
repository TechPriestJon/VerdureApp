using System;

namespace Verdure.Domain.Interfaces
{
    public interface IVerdureModifyableEntity : IVerdureCreatableEntity
    {
        DateTimeOffset ModifiedDate { get; }

        void Update();
    }
}
