using System;
using System.Collections.Generic;
using System.Text;

namespace Verdure.Domain.Interfaces
{
    public interface IVerdureDeletableEntity
    {
        bool Deleted { get; }

        void Delete();
    }
}
