using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;
using Verdure.Infrastructure.Tests.Config;

namespace Verdure.Infrastructure.Tests.EFCore
{
    [Binding]
    public class VerdureUserSteps
    {
        VerdureUser _user;


        [Given(@"I have a User to create")]
        public void GivenIHaveAUserToCreate()
        {
            _user = new VerdureUser("Frank");
        }
        
        [Given(@"I have a User persisted in the database")]
        public void GivenIHaveAUserPersistedInTheDatabase()
        {
            _user = new VerdureUser("Robert");
            WhenISaveTheUser();
        }
        
        [When(@"I Save the User")]
        public async void WhenISaveTheUser()
        {
            using(var context = VerdureInMemoryContext.Context)
            {
                context.Users.Add(_user);
                await context.SaveChangesAsync();
            }
        }
        
        [When(@"I delete the User")]
        public async  void WhenIDeleteTheUser()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var userslits = context.Users.ToList();
                var savedUser = context.Users.Find(_user.Id);
                savedUser.Delete();
                await context.SaveChangesAsync();
            }
        }
        
        [Then(@"my User is persisted in the database")]
        public void ThenMyUserIsPersistedInTheDatabase()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var savedUser = context.Users.Find(_user.Id);
                Assert.AreEqual(savedUser.Name, _user.Name);
                Assert.AreEqual(savedUser.Id, _user.Id);
                Assert.AreEqual(savedUser.CreatedDate, _user.CreatedDate);
                Assert.IsFalse(savedUser.Deleted);
            }
        }
        
        [Then(@"my User is deleted")]
        public void ThenMyUserIsDeleted()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var savedUser = context.Users.Find(_user.Id);
                Assert.IsTrue(savedUser.Deleted);
            }
        }
    }
}
