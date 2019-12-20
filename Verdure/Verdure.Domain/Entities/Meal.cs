using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Entities
{
    public class Meal : VerdureAssignableModifyableEntity, IMeal
    {
        protected IList<IFoodItem> _fooditems;
        protected long _id;

        public Meal(IVerdureUser _user, long id) : base(_user)
        {
            _id = id;
            _fooditems = new List<IFoodItem>();
        }

        public IEnumerable<IFoodItem> Food => _fooditems;

        public long Id => _id;

        public void AddFoodItem(IFoodItem foodItem)
        {
            _fooditems.Add(foodItem);
            base.Update();
        }
    }
}
