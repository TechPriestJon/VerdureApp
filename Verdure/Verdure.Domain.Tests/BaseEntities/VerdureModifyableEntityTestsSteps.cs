﻿using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Verdure.Domain.Base;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Tests
{
    [Binding]
    public class VerdureModifyableEntityTestsSteps
    {
        IVerdureModifyableEntity _invokableModifyableEntity;

        [Given(@"I have a modifyable entity")]
        public void GivenIHaveAModifyableEntity()
        {
            _invokableModifyableEntity = null;
        }

        [When(@"create the modifyableentity")]
        public void WhenCreateTheModifyableEntity()
        {
            _invokableModifyableEntity = new InvokableModifyableEntity();
        }

        [When(@"modify the modifyableentity")]
        public void WhenModifyTheModifyableEntity()
        {
            _invokableModifyableEntity.Update();
        }
        
        [Then(@"modifyableentity is initialised with the modification date")]
        public void ThenObjectIsInitialisedWithTheModificationDate()
        {
            Assert.AreEqual(_invokableModifyableEntity.ModifiedDate.Day, DateTime.UtcNow.Day);
            Assert.AreEqual(_invokableModifyableEntity.ModifiedDate.Month, DateTime.UtcNow.Month);
            Assert.AreEqual(_invokableModifyableEntity.ModifiedDate.Year, DateTime.UtcNow.Year);
            Assert.AreEqual(_invokableModifyableEntity.CreatedDate.Ticks, _invokableModifyableEntity.ModifiedDate.Ticks);
        }
        
        [Then(@"modifyableentity is modified with the modification date")]
        public void ThenObjectIsModifiedWithTheModificationDate()
        {
            Assert.AreEqual(_invokableModifyableEntity.ModifiedDate.Day, DateTime.UtcNow.Day);
            Assert.AreEqual(_invokableModifyableEntity.ModifiedDate.Month, DateTime.UtcNow.Month);
            Assert.AreEqual(_invokableModifyableEntity.ModifiedDate.Year, DateTime.UtcNow.Year);
            Assert.AreNotEqual(_invokableModifyableEntity.CreatedDate.Ticks, _invokableModifyableEntity.ModifiedDate.Ticks);
        }

        [Then(@"modifyableentity is initialised with the creation date")]
        public void ThenObjectIsInitialisedWithTheCreationDate()
        {
            Assert.AreEqual(_invokableModifyableEntity.CreatedDate.Day, DateTime.UtcNow.Day);
            Assert.AreEqual(_invokableModifyableEntity.CreatedDate.Month, DateTime.UtcNow.Month);
            Assert.AreEqual(_invokableModifyableEntity.CreatedDate.Year, DateTime.UtcNow.Year);
        }

    }


    sealed class InvokableModifyableEntity : VerdureModifyableEntity
    {
        public InvokableModifyableEntity() : base()
        {

        }
    }
}
