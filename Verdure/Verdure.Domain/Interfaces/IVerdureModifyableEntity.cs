using System;

namespace Verdure.Domain.Interfaces
{
    public interface IVerdureModifyableEntity : IVerdureCreatableEntity
    {
        DateTime ModifiedDate { get; }

        void Update();
    }
}
