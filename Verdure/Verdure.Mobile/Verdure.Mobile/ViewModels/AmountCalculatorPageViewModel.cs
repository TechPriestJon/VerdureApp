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
    public class AmountCalculatorPageViewModel : BaseViewModel
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

        public List<string> UnitList { get { return new List<string>() { "Oz", "grams", "Kilograms", "FlOz" }; } }

        private string _selectedunit;

        public string SelectedUnit
        {
            get { return _selectedunit; }
            set { SetProperty(ref _selectedunit, value); }
        }


        private long _totalCalories;

        public long TotalCalories
        {
            get { return _totalCalories; }
            set { SetProperty(ref _totalCalories, value); }
        }


        private long _amountCalories;

        public long AmountCalories
        {
            get { return _amountCalories; }
            set { SetProperty(ref _amountCalories, value); }
        }

        private long _totalAmount;

        public long TotalAmount
        {
            get { return _totalAmount; }
            set { SetProperty(ref _totalAmount, value); }
        }

        private long _amount;

        public long Amount
        {
            get { return _amount; }
            set { SetProperty(ref _amount, value); }
        }

        public ICommand Calculate { get; private set; }

        public AmountCalculatorPageViewModel(INavigationService navigationService, IIdRepository<EfcFoodItem> foodItemRepository, ISettingService settingService)
    : base(navigationService, settingService)
        {
            Title = "AmountCalculatorPageViewModel";
            _foodItemRepository = foodItemRepository;
            Submit = new Command(async () => { await SubmitTask(); });
            Cancel = new Command(async () => { await CancelTask(); });
            SelectedUnit = "Oz";
            Calculate = new Command(() => { CalculateTask(); });
        }



        public async Task SubmitTask()
        {
            if (!String.IsNullOrWhiteSpace(_name) && _calories > 0)
            {
                await _foodItemRepository.Create(new EfcFoodItem(_name + " (" + _amount.ToString() + " " + _selectedunit + ")", _calories));
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
                if(_amount > 0 && _totalAmount > 0)
                {
                    AmountCalories = (long)((double)TotalCalories * ((double)Amount / (double)TotalAmount));
                }
                else
                {
                    Amount = (long)((double)TotalAmount * ((double)AmountCalories / (double)TotalCalories));
                }
            }
            else
            {
                if (_amount > 0 && _totalAmount > 0)
                {
                    TotalCalories = (long)((double)AmountCalories * ((double)TotalAmount) / (double)Amount);
                }
                else
                {
                    TotalAmount = (long)((double)Amount * ((double)TotalCalories / (double)AmountCalories));
                }
            }
            Calories = AmountCalories;
            RaisePropertyChanged("AmountCalories"); 
            RaisePropertyChanged("TotalCalories");
            RaisePropertyChanged("Amount");
            RaisePropertyChanged("TotalAmount");
            RaisePropertyChanged("Calories");
        }

    }
}
