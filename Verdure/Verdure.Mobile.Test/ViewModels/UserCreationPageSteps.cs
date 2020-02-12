using NSubstitute;
using NUnit.Framework;
using Prism.Navigation;
using System;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Infrastructure.Mobile.DataAccess;
using Verdure.Infrastructure.Mobile.Services;
using Verdure.Mobile.ViewModels;

namespace Verdure.Mobile.Test.ViewModels
{
    [Binding]
    public class UserCreationPageSteps
    {
        UserCreationPageViewModel _viewmodel;
        INavigationService navigationService;
        IGuidRepository<VerdureUser> userRepository;
        ISettingService settingService;

        [Before]
        public void Setup()
        {
            navigationService = Substitute.For<INavigationService>();
            settingService = Substitute.For<ISettingService>();
            userRepository = Substitute.For<IGuidRepository<VerdureUser>>();
        }

        [Given(@"I have the UserCreationPage ViewModel")]
        public void GivenIHaveTheUserCreationPageViewModel()
        {
            
        }
        
        [Given(@"I have the UserCreationPage ViewModel and details for a user")]
        public void GivenIHaveTheUserCreationPageViewModelAndDetailsForAUser()
        {
            _viewmodel = new UserCreationPageViewModel(navigationService, userRepository, settingService);
        }
        
        [When(@"UserCreationPag is loaded")]
        public void WhenItIsLoaded()
        {
            _viewmodel = new UserCreationPageViewModel(navigationService, userRepository, settingService);
        }
        
        [When(@"I input the user details")]
        public void WhenIInputTheUserDetails()
        {
            _viewmodel.Username = "Tom";
            _viewmodel.Password = "NoChance";
        }

        
        [When(@"I save the user")]
        public async void WhenISaveTheUser()
        {
            await _viewmodel.SubmitTask();
        }
        
        [Then(@"I user can input details")]
        public void ThenIUserCanInputDetails()
        {
            Assert.IsNotNull(_viewmodel);
        }
        
        [Then(@"the user is saved to the database")]
        public void ThenTheUserIsSavedToTheDatabase()
        {
            Received.InOrder(() =>
            {
                userRepository.Create(Arg.Is<VerdureUser>(x => x.Name == "Tom"));
                userRepository.SaveAsync();
                navigationService.NavigateAsync("/UserSelectionPage");
            });
        }
    }
}
