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
    public class CentralPageViewModel : BaseViewModel
    {
        public ICommand NavigateToAddMeal { get; private set; }
        public ICommand NavigateToAddSnack { get; private set; }
        public ICommand NavigateToAddFoodItem { get; private set; }
        public ICommand NavigateToFoodItemList { get; private set; }
        public ICommand NavigateToSettings { get; private set; }
        public ICommand NavigateToSelectUser { get; private set; }
        public ICommand NavigateToDiary { get; private set; }

        public ICommand SelectUser { get; private set; }

        public string WelcomeUserString { get; private set; }

        public CentralPageViewModel(INavigationService navigationService, ISettingService settingService)
            : base(navigationService, settingService)
        {
            Title = "CentralPageViewModel";
            NavigateToSelectUser = new Command(async () => { await SelectUserNavigationTask(); });
            NavigateToDiary = new Command(async () => { await DiaryNavigationTask(); });
            NavigateToAddFoodItem = new Command(async () => { await FoodItemCreationNavigationTask(); });
            NavigateToFoodItemList = new Command(async () => { await FoodItemListNavigationTask(); });
            NavigateToAddMeal = new Command(async () => { await MealCreationNavigationTask(); });
            NavigateToAddSnack = new Command(async () => { await SnackCreationNavigationTask(); });
            NavigateToSettings = new Command(async () => { await SettingsNavigationTask(); });

            var userName = settingService.CurrentUser.Name;

            WelcomeUserString = "Welcome " + userName + "!";

        }



        public async Task SelectUserNavigationTask()
        {
            await _navigationService.NavigateAsync(typeof(UserSelectionPage).Name);
        }

        public async Task DiaryNavigationTask()
        {
            await _navigationService.NavigateAsync(typeof(DiaryPage).Name);
        }

        public async Task FoodItemCreationNavigationTask()
        {
            await _navigationService.NavigateAsync(typeof(FoodItemCreationPage).Name);
        }

        public async Task FoodItemListNavigationTask()
        {
            await _navigationService.NavigateAsync(typeof(FoodItemListPage).Name);
        }

        public async Task MealCreationNavigationTask()
        {
            await _navigationService.NavigateAsync(typeof(MealCreationPage).Name);
        }
        public async Task SettingsNavigationTask()
        {
            await _navigationService.NavigateAsync(typeof(SettingsPage).Name);
        }

        public async Task SnackCreationNavigationTask()
        {
            await _navigationService.NavigateAsync(typeof(SnackCreationPage).Name);
        }



    }
}
