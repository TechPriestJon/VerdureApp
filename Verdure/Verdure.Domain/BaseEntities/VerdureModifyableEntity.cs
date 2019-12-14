﻿using System;

namespace Verdure.Domain.Base
{
    public abstract class VerdureModifyableEntity : VerdureCreatableEntity
    {
        protected DateTimeOffset _modifiedDate;

        protected VerdureModifyableEntity() : base()
        {
            _modifiedDate = CreatedDate;
        }

        public DateTimeOffset ModifiedDate => _modifiedDate;

        public void Update()
        {
            _modifiedDate = DateTimeOffset.UtcNow;
        }
    }
}
