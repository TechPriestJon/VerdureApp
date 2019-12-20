using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Entities
{
    public class FoodItem : IFoodItem
    {
        public FoodItem(string name, long calories, long id) : base()
        {

        }

        public string Name => throw new NotImplementedException();

        public int Calories => throw new NotImplementedException();

        public DateTimeOffset ModifiedDate => throw new NotImplementedException();

        public DateTimeOffset CreatedDate => throw new NotImplementedException();

        public long Id => throw new NotImplementedException();

        long IFoodItem.Calories => throw new NotImplementedException();

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
