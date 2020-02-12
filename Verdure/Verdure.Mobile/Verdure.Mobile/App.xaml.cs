
using Microsoft.EntityFrameworkCore;
using Prism;
using Prism.Ioc;
using System;
using System.Linq;
using Verdure.Domain.Entities;
using Verdure.Infrastructure;
using Verdure.Infrastructure.EFCore;
using Verdure.Infrastructure.Mobile;
using Verdure.Infrastructure.Mobile.DataAccess;
using Verdure.Infrastructure.Mobile.Services;
using Verdure.Mobile.ViewModels;
using Verdure.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Verdure.Mobile
{
    public partial class App
    {
        public App() : this(null) { }

        protected bool _hasUsers { get; private set; }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            if (_hasUsers)
                await NavigationService.NavigateAsync("UserSelectionPage");
            else
                await NavigationService.NavigateAsync("UserCreationPage");
        }

        protected override async void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<DbContext, VerdureEfcSqliteContext>();
            containerRegistry.Register<IGuidRepository<VerdureUser>, DeletableGuidEntityRepository<VerdureUser>>();
            containerRegistry.Register<IIdRepository<EfcMeal>, IdEntityRepository<EfcMeal>>();
            containerRegistry.Register<IIdRepository<EfcFoodItem>, DeletableIdEntityRepository<EfcFoodItem>>();
            containerRegistry.Register<IIdRepository<EfcSnack>, IdEntityRepository<EfcSnack>>();
            containerRegistry.Register<ISettingService, SettingService>();

            containerRegistry.RegisterForNavigation<UserCreationPage, UserCreationPageViewModel>();
            containerRegistry.RegisterForNavigation<UserSelectionPage, UserSelectionPageViewModel>();

            var context = Container.Resolve<VerdureEfcSqliteContext> ();
            context.Database.EnsureCreated();
            context.Database.Migrate();

            _hasUsers = await context.Users.Where(x => x.Deleted == false).CountAsync() > 0;
        }
        
    }
}
