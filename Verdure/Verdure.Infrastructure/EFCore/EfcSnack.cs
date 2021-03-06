﻿using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.EFCore
{
    public class EfcSnack : Snack
    {
        protected new EfcFoodItem _fooditem;

        public new EfcFoodItem Food => _fooditem;

        public long FoodId { get; set; }

        public new void SetFoodItem(IFoodItem foodItem)
        {
            if (!(foodItem is EfcFoodItem))
            {
                throw new NotImplementedException("Must be compatible with EF Core");
            }

            SetFoodItem(foodItem as EfcFoodItem);
        }

        public void SetFoodItem(EfcFoodItem foodItem)
        {
            _fooditem = foodItem;
        }
        private EfcSnack()
        {   }

        public EfcSnack(VerdureUser user) : base(user)
        {   }


        public new VerdureUser User => _user as VerdureUser;

        public long Calories => _fooditem?.Calories ?? 0;

        public string Name => _fooditem?.Name ?? "";
    }
}
