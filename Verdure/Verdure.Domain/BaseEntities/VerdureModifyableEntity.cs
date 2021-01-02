using System;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Base
{
    public abstract class VerdureModifyableEntity : VerdureCreatableEntity, IVerdureModifyableEntity
    {
        protected DateTime _modifiedDate;

        protected VerdureModifyableEntity() : base()
        {
            if (_modifiedDate == null || _modifiedDate == DateTime.MinValue)
                _modifiedDate = CreatedDate;
        }

        public DateTime ModifiedDate => _modifiedDate;

        public virtual void Update()
        {
            _modifiedDate = DateTime.UtcNow;
        }
    }
}
