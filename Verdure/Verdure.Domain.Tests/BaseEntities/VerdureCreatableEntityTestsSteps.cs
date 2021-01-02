using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Tests.BaseEntities
{
    [Binding]
    public class VerdureCreatableEntityTestsSteps
    {
        IVerdureCreatableEntity _invokableCreatableEntity;

        [Given(@"I have a creatable entity")]
        public void GivenIHaveACreatableEntity()
        {
            _invokableCreatableEntity = null;
        }
        
        [When(@"create the creatableentity")]
        public void WhenCreateTheCreatableEntity()
        {
            _invokableCreatableEntity = new InvokableCreatableEntity();
        }
        
        [Then(@"creatableentity is initialised with the creation date")]
        public void ThenObjectIsInitialisedWithTheCreationDate()
        {
            Assert.AreEqual(_invokableCreatableEntity.CreatedDate.Day, DateTime.UtcNow.Day);
            Assert.AreEqual(_invokableCreatableEntity.CreatedDate.Month, DateTime.UtcNow.Month);
            Assert.AreEqual(_invokableCreatableEntity.CreatedDate.Year, DateTime.UtcNow.Year);
        }
    }

    sealed class InvokableCreatableEntity : VerdureCreatableEntity
    {
        public InvokableCreatableEntity() : base()
        {

        }
    }
}
