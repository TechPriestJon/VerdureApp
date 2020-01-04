using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Verdure.Domain.Base;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Tests.BaseEntities
{
    [Binding]
    public class VerdureDeletableModifyableEntityTestsSteps
    {
        IVerdureDeletableEntity _invokableDeletableModifyableEntity;


        [Given(@"I have a deletable entity")]
        public void GivenIHaveADeletableEntity()
        {
            _invokableDeletableModifyableEntity = null;
        }
        
        [Given(@"it is created")]
        public void GivenItIsCreated()
        {
            _invokableDeletableModifyableEntity = new InvokableDeletableModifyableEntity();
        }
        
        [When(@"create the deletableentity")]
        public void WhenCreateTheDeletableentity()
        {
            _invokableDeletableModifyableEntity = new InvokableDeletableModifyableEntity();
        }
        
        [When(@"I when I delete it")]
        public void WhenIWhenIDeleteIt()
        {
            _invokableDeletableModifyableEntity.Delete();
        }
        
        [Then(@"deletableentity defaults to not being deleted")]
        public void ThenDeletableentityDefaultsToNotBeingDeleted()
        {
            Assert.IsNotNull(_invokableDeletableModifyableEntity);
            Assert.IsFalse(_invokableDeletableModifyableEntity.Deleted);
        }
        
        [Then(@"the deletableentity is deleted")]
        public void ThenTheDeletableentityIsDeleted()
        {
            Assert.IsTrue(_invokableDeletableModifyableEntity.Deleted);
        }
    }

    sealed class InvokableDeletableModifyableEntity : VerdureDeletableModifyableEntity
    {
        public InvokableDeletableModifyableEntity() : base()
        {

        }
    }
}
