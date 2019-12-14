using System;

namespace Verdure.Domain.Base
{
    public interface IVerdureModifyableEntity : IVerdureCreatableEntity
    {
        DateTimeOffset ModifiedDate { get; }

        void Update();
    }
}
