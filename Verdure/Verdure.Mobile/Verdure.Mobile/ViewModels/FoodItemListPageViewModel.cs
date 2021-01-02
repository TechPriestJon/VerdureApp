using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Verdure.Domain.Entities;
using Verdure.Infrastructure.EFCore;
using Verdure.Infrastructure.Mobile.DataAccess;
using Verdure.Infrastructure.Mobile.Services;
using Verdure.Mobile.Views;
using Xamarin.Forms;

namespace Verdure.Mobile.ViewModels
{
    public class FoodItemListPageViewModel : BaseViewModel
    {
        IIdRepository<EfcFoodItem> _foodItemRepository;

        private IEnumerable<EfcFoodItem> _gooditemlist;
        public IEnumerable<EfcFoodItem> FoodItemList
        {
            get { return _gooditemlist; }
            private set { SetProperty(ref _gooditemlist, value); }
        }


        public ICommand Cancel { get; private set; }


        public FoodItemListPageViewModel(INavigationService navigationService, IIdRepository<EfcFoodItem> idRepository, ISettingService settingService)
    : base(navigationService, settingService)
        {
            Title = "FoodItemListPageViewModel";
            _foodItemRepository = idRepository;
            Cancel = new Command(async () => { await CancelTask(); });
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            FoodItemList = await _foodItemRepository.Get();
        }

        public async Task CancelTask()
        {
            await _navigationService.GoBackAsync();
        }

    }
}
