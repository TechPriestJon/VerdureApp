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
    public class UserSelectionPageViewModel : BaseViewModel
    {
        IGuidRepository<VerdureUser> _userRepository;

        
        private IEnumerable<VerdureUser> _userlist;
        public IEnumerable<VerdureUser> UserList
        {
            get { return _userlist; }
            private set { SetProperty(ref _userlist, value); }
        }

        public ICommand AddNewUser { get; private set; }

        public ICommand SelectUser { get; private set; }

        public ICommand Cancel { get; private set; }

        public UserSelectionPageViewModel(INavigationService navigationService, IGuidRepository<VerdureUser> userRepository, ISettingService settingService)
            : base(navigationService, settingService)
        {
            Title = "UserSelectionPageViewModel";
            _userRepository = userRepository;
            AddNewUser = new Command(async () => { await AddNewUserNavigationTask(); });
            SelectUser = new Command<VerdureUser>(async user => { await UserSelectedTask(user); });
            Cancel = new Command(async () => { await CancelTask(); });
        }

        public async Task AddNewUserNavigationTask()
        {
            await _navigationService.NavigateAsync(typeof(UserCreationPage).Name);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            UserList = await _userRepository.Get();
        }

        public async Task UserSelectedTask(VerdureUser user)
        {
            _settingService.SetUser(user);
            await _navigationService.NavigateAsync(typeof(CentralPage).Name);
        }

        public async Task CancelTask()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
