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
    public class UserCreationPageViewModel : BaseViewModel
    {
        IGuidRepository<VerdureUser> _userRepository;

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand Submit { get; private set; }

        public UserCreationPageViewModel(INavigationService navigationService, IGuidRepository<VerdureUser> userRepository, ISettingService settingService)
            : base(navigationService, settingService)
        {
            Title = "UserCreationPageViewModel";
            _userRepository = userRepository;
            Submit = new Command(async () => { await SubmitTask(); });
        }

        public async Task SubmitTask()
        {
            await _userRepository.Create(new VerdureUser(_username));
            await _userRepository.SaveAsync();
            await _navigationService.NavigateAsync("/" + typeof(UserSelectionPage).Name);
        }

    }
}
