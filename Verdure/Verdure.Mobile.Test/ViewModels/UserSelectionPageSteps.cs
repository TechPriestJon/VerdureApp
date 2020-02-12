using NSubstitute;
using NUnit.Framework;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Infrastructure.Mobile.DataAccess;
using Verdure.Infrastructure.Mobile.Services;
using Verdure.Mobile.ViewModels;

namespace Verdure.Mobile.Test.ViewModels
{
    [Binding]
    public class UserSelectionPageSteps
    {
        UserSelectionPageViewModel _viewmodel;
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

        [Given(@"I have the UserSelectionPage ViewModel")]
        public void GivenIHaveTheUserSelectionPageViewModel()
        {
            userRepository.Get().Returns(new List<VerdureUser>()
            {
                new VerdureUser("Rob"),
                new VerdureUser("Keir")
            });
        }

        [When(@"UserSelectionPage is loaded")]
        public void WhenItIsLoaded()
        {
            _viewmodel = new UserSelectionPageViewModel(navigationService, userRepository, settingService);
            _viewmodel.OnNavigatedTo(null);
        }
        
        [Then(@"All users are avaliable")]
        public void ThenAllUsersAreAvaliable()
        {
            userRepository.Received().Get();
            Assert.AreEqual(_viewmodel.UserList.Count(), 2);
        }

        [Given(@"I have the UserSelectionPage ViewModel and a function to navigate")]
        public void GivenIHaveTheUserSelectionPageViewModelAndAFunctionToNavigate()
        {
            _viewmodel = new UserSelectionPageViewModel(navigationService, userRepository, settingService);
        }

        [When(@"I press the navigate button")]
        public async void WhenIPressTheNavigateButton()
        {
            await _viewmodel.AddNewUserNavigationTask();
        }

        [Then(@"I navigate from the UserSelectionPage to the UserCreationPage")]
        public void ThenINavigateFromTheUserSelectionPageToTheUserCreationPage()
        {
            navigationService.Received(1).NavigateAsync("UserCreationPage");
        }
    }
}
