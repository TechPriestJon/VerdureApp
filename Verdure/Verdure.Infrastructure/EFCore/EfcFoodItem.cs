using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Entities;

namespace Verdure.Infrastructure.EFCore
{
    public class EfcFoodItem : FoodItem
    {
        private EfcFoodItem()  : base()
        {  }

        public EfcFoodItem(string name, long calories) : base(name, calories)
        {  }
    }
}
