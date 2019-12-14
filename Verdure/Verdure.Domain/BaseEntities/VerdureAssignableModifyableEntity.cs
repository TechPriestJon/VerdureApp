using System;

namespace Verdure.Domain.Base
{
    public abstract class VerdureAssignableModifyableEntity : VerdureModifyableEntity
    {
        protected DateTimeOffset _modifiedDate;

        protected VerdureAssignableModifyableEntity() : base()
        {
            _modifiedDate = CreatedDate;
        }

        public DateTimeOffset ModifiedDate => _modifiedDate;

        public override void Update()
        {
            base.Update();
        }
    }
}
