using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verdure.Domain.Entities;
using Verdure.Infrastructure.Mobile;
using Verdure.Infrastructure.Mobile.Services;

namespace Verdure.Mobile.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService _navigationService { get; private set; }
        protected ISettingService _settingService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public BaseViewModel(INavigationService navigationService, ISettingService settingService)
        {
            _navigationService = navigationService;
            _settingService = settingService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingFrom(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
