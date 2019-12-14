using System;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Base
{
    public abstract class VerdureAssignableModifyableEntity : VerdureModifyableEntity, IVerdureAssignableModifyableEntity
    {
        protected Guid _userId;

        protected VerdureAssignableModifyableEntity(IVerdureUser user) : base()
        {
            _modifiedDate = CreatedDate;
            _userId = user.Id;
        }

        public Guid UserId => _userId;

        public override void Update()
        {
            base.Update();
        }
    }
}
