using System;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Base
{
    public abstract class VerdureCreatableEntity : IVerdureCreatableEntity
    {
        protected DateTimeOffset _createdDate;

        protected VerdureCreatableEntity()
        {
            if(_createdDate == null || _createdDate == DateTimeOffset.MinValue)
                _createdDate = DateTimeOffset.UtcNow;
        }

        public DateTimeOffset CreatedDate => _createdDate;
    }
}
