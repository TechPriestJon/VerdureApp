using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class MealCreationPageViewModel : BaseViewModel
    {

        IIdRepository<EfcMeal> _mealRepository;
        IIdRepository<EfcFoodItem> _foodItemRepository;

        EfcMeal _meal;

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        private EfcFoodItem _fooditem;
        public EfcFoodItem FoodItem
        {
            get { return _fooditem; }
            set { SetProperty(ref _fooditem, value); }
        }


        private ObservableCollection<EfcFoodItem> _fooditemlist;
        public ObservableCollection<EfcFoodItem> FoodItemList
        {
            get { return _fooditemlist; }
            private set { SetProperty(ref _fooditemlist, value); }
        }

        private ObservableCollection<EfcFoodItem> _fooditemselectedlist;
        public ObservableCollection<EfcFoodItem> FoodItemSelectList
        {
            get { return _fooditemselectedlist; }
            private set { SetProperty(ref _fooditemselectedlist, value); }
        }

        public ICommand Cancel { get; private set; }
        public ICommand Submit { get; private set; }
        public ICommand AddFoodItem { get; private set; }
        //public EfcFoodItem FoodItem { get; set; }


        public MealCreationPageViewModel(INavigationService navigationService, IIdRepository<EfcFoodItem> foodItemRepository, IIdRepository<EfcMeal> mealRepository, ISettingService settingService)
    : base(navigationService, settingService)
        {
            _foodItemRepository = foodItemRepository;
            _mealRepository = mealRepository;
            Submit = new Command(async () => { await SubmitTask(); });
            Cancel = new Command(async () => { await CancelTask(); });
            AddFoodItem = new Command(async () => { AddFoodItemTask(); });
            Title = "MealCreationPageViewModel";
            _meal = new EfcMeal(_settingService.CurrentUser as VerdureUser);
            _fooditemselectedlist = new ObservableCollection<EfcFoodItem>();
        }


        public async Task SubmitTask()
        {
            foreach(var fooditem in _fooditemselectedlist)
            {
                _meal.AddFoodItem(fooditem);
            }

            if (_meal != null && _meal?.MealFoodItemIds != null && !String.IsNullOrWhiteSpace(_name) && !(_meal?.MealFoodItemIds?.Count() == 0))
            {
                _meal.SetName(_name);
                foreach (var fooditem in _fooditemselectedlist)
                {
                    _mealRepository.GetVerdureContext().Set<EfcFoodItem>().Attach(fooditem);
                }
                _mealRepository.GetVerdureContext().Set<VerdureUser>().Attach(_settingService.CurrentUser as VerdureUser);
                await _mealRepository.Create(_meal);
                await _mealRepository.SaveAsync();
                await _navigationService.NavigateAsync("/" + typeof(CentralPage).Name);

            }

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            FoodItemList = new ObservableCollection<EfcFoodItem>((await _foodItemRepository.Get()).Where(x => x.Calories != 0));
        }

        public async Task CancelTask()
        {
            await _navigationService.GoBackAsync();
        }
        public void AddFoodItemTask()
        {
            if(FoodItem != null)
            {
                FoodItemSelectList.Add(FoodItem);
                var foodItemForRemoval = FoodItemList.FirstOrDefault(x => x.Id == FoodItem.Id);
                FoodItemList.Remove(foodItemForRemoval);
                FoodItem = null;
            }
            //var foodItemSelectListToAdd = FoodItemSelectList;
            //foodItemSelectListToAdd.Add(FoodItem);
            //FoodItemSelectList = foodItemSelectListToAdd;

        }
    }
}
