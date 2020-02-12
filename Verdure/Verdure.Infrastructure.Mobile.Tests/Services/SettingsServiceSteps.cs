using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;
using Verdure.Infrastructure.Mobile.Services;

namespace Verdure.Infrastructure.Mobile.Tests.Services
{
    [Binding]
    public class SettingsServiceSteps
    {
        ISettingService _service;
        IVerdureUser _user;
        IVerdureUser _returnedUser;

        [Before]
        public void Setup()
        {
            _service = new SettingService();
        }


        [Given(@"I have a user")]
        public void GivenIHaveAUser()
        {
            _user = new VerdureUser("Frankie");
        }
        
        [Given(@"a user has been set")]
        public void GivenAUserHasBeenSet()
        {
            _user = new VerdureUser("Frankie");
            _service.SetUser(_user);
        }
        
        [When(@"I set the user in the service")]
        public void WhenISetTheUserInTheService()
        {
            _service.SetUser(_user);
        }
        
        [When(@"I get the user")]
        public void WhenIGetTheUser()
        {
            _returnedUser = _service.CurrentUser;
        }
        
        [Then(@"the user is set in the service")]
        public void ThenTheUserIsSetInTheService()
        {
            Assert.IsNotNull(_service.CurrentUser);
            Assert.AreEqual(_service.CurrentUser.Id, _user.Id);
            Assert.AreEqual(_service.CurrentUser.Name, _user.Name);
            Assert.AreEqual(_service.CurrentUser.CreatedDate, _user.CreatedDate);
        }
        
        [Then(@"the user is returned")]
        public void ThenTheUserIsReturned()
        {

            Assert.IsNotNull(_returnedUser);
            Assert.AreEqual(_returnedUser.Id, _user.Id);
            Assert.AreEqual(_returnedUser.Name, _user.Name);
            Assert.AreEqual(_returnedUser.CreatedDate, _user.CreatedDate);
        }
    }
}
