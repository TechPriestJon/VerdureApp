using System;

namespace Verdure.Domain.Interfaces
{
    public interface IVerdureUser : IVerdureGuidEntity, IVerdureModifyableEntity, IVerdureDeletableEntity
    {

        string Name { get; }

    }
}
