using System;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Entities
{
    public class VerdureUser : VerdureDeletableModifyableEntity, IVerdureUser
    {
        Guid _id;
        string _name;

        public VerdureUser(string name) : base()
        {
            _id = Guid.NewGuid();
            _name = name;
        }

        protected VerdureUser()
        {   }

        public Guid Id => _id;
        public string Name => _name;

    }
}
