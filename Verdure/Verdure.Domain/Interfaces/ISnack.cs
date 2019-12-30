using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Entities;

namespace Verdure.Domain.Interfaces
{
    public interface ISnack : IVerdureAssignableModifyableEntity, IVerdureIdEntity
    {
        IFoodItem Food { get; }

        void SetFoodItem(IFoodItem foodItem);

    }
}
