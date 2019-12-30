
using Prism;
using Prism.Ioc;
using System;
using Verdure.Infrastructure;
using Verdure.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Verdure.Mobile
{

    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<Views.MainPage, MainPageViewModel>();
        }

    }


    //public partial class App : Application
    //{
    //    public App()
    //    {
    //        InitializeComponent();

    //        MainPage = new MainPage();
    //    }

    //    protected override void OnStart()
    //    {
    //    }

    //    protected override void OnSleep()
    //    {
    //    }

    //    protected override void OnResume()
    //    {
    //    }
    //}
}
