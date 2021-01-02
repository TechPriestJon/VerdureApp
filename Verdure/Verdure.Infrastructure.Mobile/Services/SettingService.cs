 using System;
using System.Collections.Generic;
using System.Text;
using Verdure.Domain.Interfaces;

namespace Verdure.Infrastructure.Mobile.Services
{
    public class SettingService : ISettingService
    {
        protected static IVerdureUser _user;

        public IVerdureUser CurrentUser => _user;

        public void SetUser(IVerdureUser user)
        {
            _user = user;
        }
    }
}
