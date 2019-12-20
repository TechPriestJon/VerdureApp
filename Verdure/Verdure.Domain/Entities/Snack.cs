﻿using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Entities
{
    public class Snack : VerdureAssignableModifyableEntity, ISnack
    {
        protected IFoodItem _fooditem;
        protected long _id;


        public Snack(IVerdureUser user, long id) : base(user) 
        {
            _id = id;
        }

        public IFoodItem Food => _fooditem;

        public long Id => _id;

        public void SetFoodItem(IFoodItem foodItem)
        {
            _fooditem = foodItem;
        }

    }
}
