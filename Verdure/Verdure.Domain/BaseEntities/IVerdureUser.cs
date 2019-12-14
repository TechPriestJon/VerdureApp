using System;

namespace Verdure.Domain.Base
{
    public interface IVerdureUser : IVerdureGuidEntity, IVerdureModifyableEntity
    {

        string Name { get; }

    }
}
