using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Entities
{
    public class Meal : VerdureAssignableModifyableEntity, IMeal
    {
        protected IList<IFoodItem> _fooditems;
        protected long _id;

        public Meal(IVerdureUser _user) : base(_user)
        {
            _fooditems = new List<IFoodItem>();
        }

        protected Meal() : base(null)
        { }

        public IEnumerable<IFoodItem> Food => _fooditems;

        public long Id => _id;

        public void AddFoodItem(IFoodItem foodItem)
        {
            _fooditems.Add(foodItem);
            base.Update();
        }

        public void RemoveFoodItem(long id)
        {
            _fooditems.Remove(_fooditems.First(x => x.Id == id));
            base.Update();
        }
    }
}
