using System;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Base
{
    public abstract class VerdureAssignableModifyableEntity : VerdureModifyableEntity, IVerdureAssignableModifyableEntity
    {
        protected IVerdureUser _user;

        protected VerdureAssignableModifyableEntity(IVerdureUser user) : base()
        {
            _modifiedDate = CreatedDate;
            _user = user;
        }

        public IVerdureUser User => _user;

        public override void Update()
        {
            base.Update();
        }
    }
}
