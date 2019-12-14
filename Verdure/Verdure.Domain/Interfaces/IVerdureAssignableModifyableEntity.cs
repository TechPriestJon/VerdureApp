using System;

namespace Verdure.Domain.Interfaces
{
    public interface IVerdureAssignableModifyableEntity : IVerdureModifyableEntity
    {
        Guid UserId { get; }
    }
}
