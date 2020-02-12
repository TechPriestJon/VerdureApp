using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.Mobile.Services
{
    public interface ISettingService
    {
        IVerdureUser CurrentUser { get; }

        void SetUser(IVerdureUser user);
    }
}
