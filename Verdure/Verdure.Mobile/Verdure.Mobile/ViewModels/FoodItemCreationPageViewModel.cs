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
    public class FoodItemCreationPageViewModel : BaseViewModel
    {
        IIdRepository<EfcFoodItem> _foodItemRepository;

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private long _calories;
        public long Calories
        {
            get { return _calories; }
            set { SetProperty(ref _calories, value); }
        }
        public ICommand Submit { get; private set; }

        public ICommand Cancel { get; private set; }


        public FoodItemCreationPageViewModel(INavigationService navigationService, IIdRepository<EfcFoodItem> foodItemRepository, ISettingService settingService)
    : base(navigationService, settingService)
        {
            Title = "FoodItemCreationPageViewModel";
            _foodItemRepository = foodItemRepository;
            Submit = new Command(async () => { await SubmitTask(); });
            Cancel = new Command(async () => { await CancelTask(); });
        }



        public async Task SubmitTask()
        {
            if (!String.IsNullOrWhiteSpace(_name) && _calories > 0)
            {
                await _foodItemRepository.Create(new EfcFoodItem(_name, _calories));
                await _foodItemRepository.SaveAsync();
                await _navigationService.NavigateAsync("/" + typeof(CentralPage).Name);
            }

        }
        public async Task CancelTask()
        {
            await _navigationService.GoBackAsync();
        }

    }
}
