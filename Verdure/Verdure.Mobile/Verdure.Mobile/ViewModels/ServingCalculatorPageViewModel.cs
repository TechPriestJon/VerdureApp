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
    public class ServingCalculatorPageViewModel : BaseViewModel
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

        private long _totalCalories;

        public long TotalCalories
        {
            get { return _totalCalories; }
            set { SetProperty(ref _totalCalories, value); }
        }


        private long _servingCalories;

        public long ServingCalories
        {
            get { return _servingCalories; }
            set { SetProperty(ref _servingCalories, value); }
        }

        private long _totalservings;

        public long TotalServings
        {
            get { return _totalservings; }
            set { SetProperty(ref _totalservings, value); }
        }


        public ICommand Calculate { get; private set; }

        public ServingCalculatorPageViewModel(INavigationService navigationService, IIdRepository<EfcFoodItem> foodItemRepository, ISettingService settingService)
    : base(navigationService, settingService)
        {
            Title = "ServingCalculatorViewModel";
            _foodItemRepository = foodItemRepository;
            Submit = new Command(async () => { await SubmitTask(); });
            Cancel = new Command(async () => { await CancelTask(); });
            Calculate = new Command(() => { CalculateTask(); });
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

        public void CalculateTask()
        {
            if (_totalCalories > 0)
            {
                if (_totalservings > 0)
                {
                    ServingCalories = (long)((double)TotalCalories / (double)TotalServings);
                }
            }
            else
            {
                if (_totalservings > 0)
                {
                    TotalCalories = (long)((double)ServingCalories * (double)TotalServings);
                }
            }
            Calories = ServingCalories;
            RaisePropertyChanged("TotalCalories");
            RaisePropertyChanged("ServingCalories");
            RaisePropertyChanged("TotalServings");
            RaisePropertyChanged("Calories");
        }

    }
}
