using System;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

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


        public Guid Id => _id;
        public string Name => _name;

    }
}
