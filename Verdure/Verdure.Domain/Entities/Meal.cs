using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Entities
{
    public class Meal : VerdureAssignableModifyableEntity, IMeal
    {
        public IList<IFoodItem> _fooditems;

        public Meal(IVerdureUser _user, long id) : base(_user)
        {   }

        public IList<IFoodItem> Food => _fooditems;

        public long Id => throw new NotImplementedException();

        public void AddFoodItem(IFoodItem foodItem)
        {
            _fooditems.Add(foodItem);
            base.Update();
        }
    }
}
