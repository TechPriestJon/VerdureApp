using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Entities
{
    public class Snack : VerdureAssignableModifyableEntity, ISnack
    {
        public Snack(IVerdureUser user, long id) : base(user) 
        { }

        public IFoodItem Food => throw new NotImplementedException();

        public long Id => throw new NotImplementedException();

        public void SetFoodItem(IFoodItem foodItem)
        {
            throw new NotImplementedException();
        }

    }
}
