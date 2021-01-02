using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Entities;

namespace Verdure.Domain.Interfaces
{
    public interface IMeal : IVerdureAssignableModifyableEntity, IVerdureIdEntity
    {
        IEnumerable<IFoodItem> Food { get; }

        void AddFoodItem(IFoodItem foodItem);

        void RemoveFoodItem(long id);

        string Name { get; }

    }
}
