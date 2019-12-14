using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Verdure.Domain.Base;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Tests.BaseEntities
{
    [Binding]
    public class VerdureAssignableModifyableEntitySteps
    {
        IVerdureAssignableModifyableEntity _invokableAssignableModifyableEntity;
        IVerdureUser _user;

        [Given(@"I have a assignable modifyable entity")]
        public void GivenIHaveAAssignableModifyableEntity()
        {
            _invokableAssignableModifyableEntity = null;
        }
        
        [Given(@"I have a user to assign the entity to")]
        public void GivenIHaveAUserToAssignTheEntityTo()
        {
            _user = new VerdureUser("Mary");
        }
        
        [When(@"create the assignablemodifyableentity")]
        public void WhenCreateTheAssignablemodifyableentity()
        {
            _invokableAssignableModifyableEntity = new InvokableAssignableModifyableEntity(_user);
        }
        
        [Then(@"assignablemodifyableentity is initialised with the created user id")]
        public void ThenAssignablemodifyableentityIsInitialisedWithTheCreatedUserId()
        {
            Assert.AreEqual(_user.Id, _invokableAssignableModifyableEntity.UserId);
        }
        
        [Then(@"assignablemodifyableentity is initialised with the creation date")]
        public void ThenAssignablemodifyableentityIsInitialisedWithTheCreationDate()
        {
            Assert.AreEqual(_invokableAssignableModifyableEntity.CreatedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_invokableAssignableModifyableEntity.CreatedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_invokableAssignableModifyableEntity.CreatedDate.Year, DateTimeOffset.UtcNow.Year);
        }
        
        [Then(@"assignablemodifyableentity is initialised with the modification date")]
        public void ThenAssignablemodifyableentityIsInitialisedWithTheModificationDate()
        {
            Assert.AreEqual(_invokableAssignableModifyableEntity.ModifiedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_invokableAssignableModifyableEntity.ModifiedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_invokableAssignableModifyableEntity.ModifiedDate.Year, DateTimeOffset.UtcNow.Year);
        }

        sealed class InvokableAssignableModifyableEntity : VerdureAssignableModifyableEntity
        {
            public InvokableAssignableModifyableEntity(IVerdureUser _user) : base(_user)
            {

            }
        }
    }
}
