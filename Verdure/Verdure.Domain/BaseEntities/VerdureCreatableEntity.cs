using System;

namespace Verdure.Domain.Base
{
    public abstract class VerdureCreatableEntity
    {
        protected DateTimeOffset _createdDate;
        protected long _id;

        protected VerdureCreatableEntity()
        {
            _createdDate = DateTimeOffset.UtcNow;
        }

        public long Id => _id;
        public DateTimeOffset CreatedDate => _createdDate;
    }
}
