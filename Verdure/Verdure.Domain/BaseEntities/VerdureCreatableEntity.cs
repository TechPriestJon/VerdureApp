using System;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Base
{
    public abstract class VerdureCreatableEntity : IVerdureCreatableEntity
    {
        protected DateTimeOffset _createdDate;

        protected VerdureCreatableEntity()
        {
            _createdDate = DateTimeOffset.UtcNow;
        }

        public DateTimeOffset CreatedDate => _createdDate;
    }
}
