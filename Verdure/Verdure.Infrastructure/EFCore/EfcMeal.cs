using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.EFCore
{
    public class EfcMeal : Meal
    {
        protected IList<EfcMealFoodItem> _efcMealFoodItem;

        private EfcMeal()
        {
            _efcMealFoodItem = new List<EfcMealFoodItem>();
        }

        public EfcMeal(VerdureUser user) : base(user)
        {
            _efcMealFoodItem = new List<EfcMealFoodItem>();
        }

        public IEnumerable<EfcMealFoodItem> MealFoodItemIds => _efcMealFoodItem;

        public new IEnumerable<EfcFoodItem> Food => _efcMealFoodItem.Select(x => x.FoodItem).ToList();

        public new VerdureUser User => _user as VerdureUser;

        public new void AddFoodItem(IFoodItem fooditem)
        {
            if(!(fooditem is EfcFoodItem))
            {
                throw new NotImplementedException("Must be compatible with EF Core");
            }
            AddFoodItem(fooditem as EfcFoodItem);
        }

        public void AddFoodItem(EfcFoodItem foodItem)
        {
            _efcMealFoodItem.Add(new EfcMealFoodItem()
            {
                FoodItem = foodItem,
                Meal = this
            });
            Update();
        }

        public new void RemoveFoodItem(long id)
        {
            _efcMealFoodItem.Remove(_efcMealFoodItem.First(x => x.FoodItemId == id));
            Update();
        }

        public override long Calories => _efcMealFoodItem.Sum(x => x?.FoodItem?.Calories ?? 0);
    }
}
