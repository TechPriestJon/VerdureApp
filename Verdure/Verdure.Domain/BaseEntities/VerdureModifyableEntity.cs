using System;

namespace Verdure.Domain.Base
{
    public abstract class VerdureModifyableEntity : VerdureCreatableEntity
    {
        protected DateTimeOffset _modifiedDate;

        protected VerdureModifyableEntity() : base()
        {
            _modifiedDate = DateTimeOffset.UtcNow;
        }

        public DateTimeOffset ModifiedDate => _modifiedDate;
    }
}
