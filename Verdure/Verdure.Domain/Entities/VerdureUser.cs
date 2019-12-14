using System;
using Verdure.Domain.Base;

namespace Verdure.Domain.Entities
{
    public class VerdureUser : VerdureModifyableEntity, IVerdureUser
    {
        Guid _id;
        string _name;

        public VerdureUser(string Name) : base()
        {
            _id = Guid.NewGuid();
            _name = Name;
        }


        public Guid Id { get => _id;  }
        public string Name { get => _name; }

    }
}
