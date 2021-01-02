using System;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Base
{
    public abstract class VerdureCreatableEntity : IVerdureCreatableEntity
    {
        protected DateTime _createdDate;

        protected VerdureCreatableEntity()
        {
            if(_createdDate == null || _createdDate == DateTime.MinValue)
                _createdDate = DateTime.UtcNow;
        }

        public DateTime CreatedDate => _createdDate;
    }
}
