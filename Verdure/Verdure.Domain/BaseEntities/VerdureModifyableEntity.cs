using System;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Base
{
    public abstract class VerdureModifyableEntity : VerdureCreatableEntity, IVerdureModifyableEntity
    {
        protected DateTimeOffset _modifiedDate;

        protected VerdureModifyableEntity() : base()
        {
            _modifiedDate = CreatedDate;
        }

        public DateTimeOffset ModifiedDate => _modifiedDate;

        public virtual void Update()
        {
            _modifiedDate = DateTimeOffset.UtcNow;
        }
    }
}
