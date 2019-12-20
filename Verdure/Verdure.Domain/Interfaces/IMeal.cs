using System;
using System.Collections.Generic;
using System.Text;

namespace Verdure.Domain.Interfaces
{
    public interface IMeal : IVerdureAssignableModifyableEntity, IVerdureIdEntity
    {
        IEnumerable<IFoodItem> Food { get; }

        void AddFoodItem(IFoodItem foodItem);

    }
}
