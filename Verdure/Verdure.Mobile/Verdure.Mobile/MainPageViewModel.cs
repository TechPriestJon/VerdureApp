using Microsoft.EntityFrameworkCore;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verdure.Domain.Entities;
using Verdure.Infrastructure;
using Verdure.Infrastructure.Mobile;

namespace Verdure.Mobile
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Blank";


        }
    }


    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual async void OnNavigatedTo(INavigationParameters parameters)
        {

            using(var context = new VerdureEfcSqliteContext())
            {
                context.Database.EnsureCreated();
                context.Database.Migrate();

                var user = context.Users.ToList();

                if(user == null || user.Count == 0)
                {
                    context.Users.Add(new VerdureUser("Mike"));
                    await context.SaveChangesAsync();
                    user = context.Users.ToList();
                }

                Title = user.First().Name + " - " + user.First().Id.ToString();
            }
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
