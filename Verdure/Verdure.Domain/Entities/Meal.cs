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
        protected string _name;

        public Meal(IVerdureUser user) : base(user)
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

        public void SetName(string name)
        {
            _name = name;
        }

        public string Name => _name;

        public virtual long Calories => _fooditems?.Sum(x => x?.Calories ?? 0) ?? 0;
    }
}
