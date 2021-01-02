using Microsoft.EntityFrameworkCore;
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
    public class DiaryPageViewModel : BaseViewModel
    {
        IIdRepository<EfcSnack> _snackRepository;

        private IEnumerable<EfcSnack> _snacklist;
        public IEnumerable<EfcSnack> SnackList
        {
            get { return _snacklist; }
            private set { SetProperty(ref _snacklist, value); }
        }


        IIdRepository<EfcMeal> _mealRepository;

        private IEnumerable<EfcMeal> _meallist;
        public IEnumerable<EfcMeal> MealList
        {
            get { return _meallist; }
            private set { SetProperty(ref _meallist, value); }
        }


        private IList<object> _objectlist;
        public IList<object> ObjectList
        {
            get { return _objectlist; }
            private set { SetProperty(ref _objectlist, value); }
        }


        private DateTime _diaryDate;

        public DateTime DiaryDateTime
        {
            get { return _diaryDate; }
            set
            {
                _diaryDate = value;
                RaisePropertyChanged("DiaryDate");
            }
        }

        public string DiaryDate
        {
            get { return _diaryDate.ToString("yyyy-MM-dd"); }
        }




        public ICommand MinusOneDay { get; private set; }
        public ICommand PlusOneDay { get; private set; }

        public ICommand Cancel { get; private set; }


        public DiaryPageViewModel(INavigationService navigationService, IIdRepository<EfcSnack> snackRepository, IIdRepository<EfcMeal> mealRepository, ISettingService settingService)
    : base(navigationService, settingService)
        {
            _diaryDate = DateTime.Now.ToLocalTime();
            _snackRepository = snackRepository;
            _mealRepository = mealRepository;
            Title = " DiaryPageViewModel";
            Cancel = new Command(async () => { await CancelTask(); });

            MinusOneDay = new Command(async() => { await MinusOneDayTask(); });
            PlusOneDay = new Command(async() => { await PlusOneDayTask(); });
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await LoadDiary();
        }


        private async Task LoadDiary()
        {
            var beginningOfDay = _diaryDate.Date.AddSeconds(-1).ToUniversalTime();
            var endOfDay = _diaryDate.Date.AddDays(1).AddSeconds(1).ToUniversalTime();
            var dairyDate = _diaryDate.Date;

            SnackList = await _snackRepository.GetVerdureContext().Snacks.Where(x => x.CreatedDate > beginningOfDay).Where(x => x.CreatedDate < endOfDay).Include(sn => sn.Food).OrderBy(x => x.Id).ToListAsync();
            MealList = await _mealRepository.GetVerdureContext().Meals.Where(x => x.CreatedDate > beginningOfDay).Where(x => x.CreatedDate < endOfDay).Include(ml => ml.MealFoodItemIds).ThenInclude(mlfi => mlfi.FoodItem).OrderBy(x => x.Id).ToListAsync();
            var combinedList = new List<object>();
            combinedList.AddRange(SnackList);
            combinedList.AddRange(MealList);
            ObjectList = combinedList;
        }

        public async Task CancelTask()
        {
            await _navigationService.GoBackAsync();
        }

        public async Task MinusOneDayTask()
        {
            DiaryDateTime = _diaryDate.AddDays(-1);
            await LoadDiary();
        }

        public async Task PlusOneDayTask()
        {
            DiaryDateTime = _diaryDate.AddDays(1);
            await LoadDiary();
        }


        
    }
}
