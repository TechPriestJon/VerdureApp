using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verdure.Domain.Entities;
using Verdure.Infrastructure.Mobile.DataAccess;
using Verdure.Infrastructure.Mobile.Services;
using Verdure.Mobile.Views;
using Xamarin.Forms;

namespace Verdure.Mobile.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        IGuidRepository<VerdureUser> _userRepository;


        public SettingsPageViewModel(INavigationService navigationService, IGuidRepository<VerdureUser> userRepository, ISettingService settingService)
    : base(navigationService, settingService)
        {
            Title = "SettingsPageViewModel";
            _userRepository = userRepository;
        }
    }
}
