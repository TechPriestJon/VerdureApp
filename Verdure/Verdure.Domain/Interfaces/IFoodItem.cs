using System;
using System.Collections.Generic;
using System.Text;

namespace Verdure.Domain.Interfaces
{
    public interface IFoodItem : IVerdureModifyableEntity, IVerdureIdEntity, IVerdureDeletableEntity
    {
        string Name { get; }
        long Calories { get; }

    }
}
