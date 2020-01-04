using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.EFCore
{
    public class EfcMealFoodItem
    {
        public long MealId { get; set; }
        public EfcMeal Meal { get; set; }

        public long FoodItemId { get; set; }
        public EfcFoodItem FoodItem { get; set; }
    }
}
