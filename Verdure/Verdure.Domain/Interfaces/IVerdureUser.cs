using System;

namespace Verdure.Domain.Interfaces
{
    public interface IVerdureUser : IVerdureGuidEntity, IVerdureModifyableEntity
    {

        string Name { get; }

    }
}
