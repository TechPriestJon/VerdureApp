using System;
using System.Collections.Generic;
using System.Text;

namespace Verdure.Domain.Interfaces
{
    public interface IMeal : IVerdureAssignableModifyableEntity, IVerdureIdEntity
    {
        IList<IFoodItem> Food { get; }

        void AddFoodItem(IFoodItem foodItem);

    }
}
