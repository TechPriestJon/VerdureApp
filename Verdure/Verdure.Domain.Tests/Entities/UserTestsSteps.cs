using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Tests.Entities
{
    [Binding]
    public class UserTestsSteps
    {
        string _username;
        string _anotherUsername;

        IVerdureUser _user;
        IVerdureUser _anotherUser;

        [Given(@"I have a name for my user")]
        public void GivenIHaveANameForMyUser()
        {
            _username = "Michael";
        }
        
        [Given(@"a name for another user")]
        public void GivenANameForAnotherUser()
        {
            _anotherUsername = "Sarah";
        }
        
        [When(@"I create my user record")]
        public void WhenICreateMyUserRecord()
        {
            _user = new VerdureUser(_username);
        }
        
        [When(@"I create another user")]
        public void WhenICreateAnotherUser()
        {
            _anotherUser = new VerdureUser(_anotherUsername);
        }
        
        [Then(@"my user has my name and an id")]
        public void ThenMyUserHasMyNameAndAnId()
        {
            Assert.AreEqual(_user.Name, _username);
            Assert.IsNotNull(_user.Id);
        }
        
        [Then(@"the user has a different name and id")]
        public void ThenTheUserHasADifferentNameAndId()
        {
            Assert.AreEqual(_user.Name, _username);
            Assert.IsNotNull(_user.Id);
            Assert.AreEqual(_anotherUser.Name, _anotherUsername);
            Assert.IsNotNull(_anotherUser.Id);
            Assert.AreNotEqual(_user.Name, _anotherUser.Name);
            Assert.AreNotEqual(_user.Id, _anotherUser.Id);
        }

        [Then(@"my user has a creation date of today")]
        public void ThenMyUserHasACreationDateOfToday()
        {
            Assert.AreEqual(_user.CreatedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_user.CreatedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_user.CreatedDate.Year, DateTimeOffset.UtcNow.Year);
        }

        [Then(@"my user and the other user have a creation date of today")]
        public void ThenMyUserAndTheOtherUserHaveACreationDateOfToday()
        {
            Assert.AreEqual(_anotherUser.CreatedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_anotherUser.CreatedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_anotherUser.CreatedDate.Year, DateTimeOffset.UtcNow.Year);
        }
    }
}
