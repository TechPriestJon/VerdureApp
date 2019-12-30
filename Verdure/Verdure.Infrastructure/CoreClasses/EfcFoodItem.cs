﻿using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Entities;

namespace Verdure.Infrastructure.CoreClasses
{
    public class EfcFoodItem : FoodItem
    {
        private EfcFoodItem()  : base("",0)
        {  }

        public EfcFoodItem(string name, long calories) : base(name, calories)
        {  }
    }
}
