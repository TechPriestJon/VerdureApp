using System;

namespace Verdure.Domain.Base
{
    public abstract class VerdureModifyableEntity : VerdureCreatableEntity, IVerdureModifyableEntity
    {
        protected DateTimeOffset _modifiedDate;

        protected VerdureModifyableEntity() : base()
        {
            _modifiedDate = CreatedDate;
        }

        public DateTimeOffset ModifiedDate { get => _modifiedDate; }

        public virtual void Update()
        {
            _modifiedDate = DateTimeOffset.UtcNow;
        }
    }
}
