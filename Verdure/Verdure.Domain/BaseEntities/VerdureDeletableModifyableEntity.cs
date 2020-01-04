using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Base
{
    public abstract class VerdureDeletableModifyableEntity : VerdureModifyableEntity, IVerdureDeletableEntity
    {
        protected bool _deleted;
        public VerdureDeletableModifyableEntity() : base()
        {   }

        public bool Deleted => _deleted;

        public void Delete()
        {
            _deleted = true;
        }
    }
}
