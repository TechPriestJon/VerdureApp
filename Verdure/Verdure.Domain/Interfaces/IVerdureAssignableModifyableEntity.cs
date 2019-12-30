using System;
using Verdure.Domain.Entities;

namespace Verdure.Domain.Interfaces
{
    public interface IVerdureAssignableModifyableEntity : IVerdureModifyableEntity
    {
        IVerdureUser User { get; }
    }
}
