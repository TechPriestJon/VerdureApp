using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SnackCreationPageViewModel : BaseViewModel
    {
        IIdRepository<EfcFoodItem> _foodItemRepository;

        IIdRepository<EfcSnack> _snackRepository;

        EfcSnack _snack;

        private IList<EfcFoodItem> _fooditemlist;
        public IList<EfcFoodItem> FoodItemList
        {
            get { return _fooditemlist; }
            private set { SetProperty(ref _fooditemlist, value); }
        }

        public EfcFoodItem FoodItem { get; set; }

        public ICommand Cancel { get; private set; }
        public ICommand Submit { get; private set; }


        public SnackCreationPageViewModel(INavigationService navigationService, IIdRepository<EfcFoodItem> foodItemRepository, IIdRepository<EfcSnack> snackRepository, ISettingService settingService)
    : base(navigationService, settingService)
        {
            Title = "SnackCreationPageViewModel";
            _foodItemRepository = foodItemRepository;
            _snackRepository = snackRepository;
            Submit = new Command(async () => { await SubmitTask(); });
            Cancel = new Command(async () => { await CancelTask(); });
            _snack = new EfcSnack(_settingService.CurrentUser as VerdureUser);
        }



        public async Task SubmitTask()
        {
            _snack.SetFoodItem(FoodItem);

            if (_snack != null && _snack.Food != null)
            {
                _snackRepository.GetVerdureContext().Set<EfcFoodItem>().Attach(FoodItem);
                _snackRepository.GetVerdureContext().Set<VerdureUser>().Attach(_settingService.CurrentUser as VerdureUser);
                await _snackRepository.Create(_snack);

                await _snackRepository.SaveAsync();
                await _navigationService.NavigateAsync("/" + typeof(CentralPage).Name);
            }

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            FoodItemList = (await _foodItemRepository.Get()).Where(x => x.Calories != 0).ToList();
        }

        public async Task CancelTask()
        {
            await _navigationService.GoBackAsync();
        }

    }
}
