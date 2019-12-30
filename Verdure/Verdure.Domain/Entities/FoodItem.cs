using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Entities
{
    public class FoodItem : VerdureModifyableEntity, IFoodItem
    {
        protected long _id;
        protected long _calories;
        protected string _name;

        public FoodItem(string name, long calories) : base()
        {
            _name = name;
            _calories = calories;
        }

        private FoodItem()
        {  }

        public string Name => _name;

        public long Calories => _calories;

        public long Id => _id;
    }
}
