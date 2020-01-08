using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;
using Verdure.Infrastructure.Mobile.DataAccess;
using Verdure.Infrastructure.Mobile.Tests.Config;

namespace Verdure.Infrastructure.Mobile.Tests.DataAccess
{
    [Binding]
    public class DeletableDeletableGuidEntityRepositorySteps
    {
        VerdureUser _guidEntity;
        List<VerdureUser> _entityList;
        VerdureUser _returnEntity;
        List<VerdureUser> _returnList;
        IGuidRepository<VerdureUser> _repository;
        VerdureInMemoryContext _context = VerdureInMemoryContext.Context;

        [Before]
        public void Setup()
        {
            _repository = new DeletableGuidEntityRepository<VerdureUser>(_context);
        }

        [Given(@"I have a DeletableGuidEntity")]
        public void GivenIHaveADeletableGuidEntity()
        {
            _guidEntity = new VerdureUser("Ben");
        }

        [Given(@"I have a DeletableGuidEntity persisted")]
        public void GivenIHaveADeletableGuidEntityPersisted()
        {
            _guidEntity = new VerdureUser("Mike");
            _repository.Create(_guidEntity);
        }

        [Given(@"I have two DeletableGuidEntity persisted")]
        public void GivenIHaveTwoDeletableGuidEntityPersisted()
        {
            _entityList = new List<VerdureUser>()
            {
                new VerdureUser("Ken"),
                new VerdureUser("Claire")
            };
            _repository.Create(_entityList.First());
            _repository.Create(_entityList.Last());
        }

        [When(@"I create the DeletableGuidEntity")]
        public void WhenICreateTheDeletableGuidEntity()
        {
            _repository.Create(_guidEntity);
        }

        [When(@"I get the DeletableGuidEntity based on id")]
        public async void WhenIGetTheDeletableGuidEntityBasedOnId()
        {
            _returnEntity = await _repository.Get(_guidEntity.Id);
        }

        [When(@"I get the DeletableGuidEntities")]
        public async void WhenIGetTheDeletableGuidEntities()
        {
            var returnValues = await _repository.Get();
            _returnList = returnValues.ToList();
        }

        [When(@"I update the DeletableGuidEntity")]
        public void WhenIUpdateTheDeletableGuidEntity()
        {
            throw new NotImplementedException();
        }

        [When(@"I delete the DeletableGuidEntity based on id")]
        public async void WhenIDeleteTheDeletableGuidEntityBasedOnId()
        {
            await _repository.Delete(_guidEntity.Id);
        }

        [Then(@"the DeletableGuidEntity is stored in the database")]
        public void ThenTheDeletableGuidEntityIsStoredInTheDatabase()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var savedUser = context.Users.Find(_guidEntity.Id);
                Assert.AreEqual(savedUser.Name, _guidEntity.Name);
                Assert.AreEqual(savedUser.Id, _guidEntity.Id);
                Assert.AreEqual(savedUser.CreatedDate, _guidEntity.CreatedDate);
                Assert.IsFalse(savedUser.Deleted);
            }
        }

        [Then(@"the DeletableGuidEntity is returned")]
        public void ThenTheDeletableGuidEntityIsReturned()
        {
            Assert.AreEqual(_returnEntity.Name, _guidEntity.Name);
            Assert.AreEqual(_returnEntity.Id, _guidEntity.Id);
            Assert.AreEqual(_returnEntity.CreatedDate, _guidEntity.CreatedDate);
        }

        [Then(@"both DeletableGuidEntities are returned")]
        public void ThenBothDeletableGuidEntitiesAreReturned()
        {
            Assert.AreEqual(_entityList.First().Name, _returnList.First(x => x.Id == _entityList.First().Id).Name);
            Assert.AreEqual(_entityList.First().CreatedDate, _returnList.First(x => x.Id == _entityList.First().Id).CreatedDate);


            Assert.AreEqual(_entityList.Last().Name, _returnList.First(x => x.Id == _entityList.Last().Id).Name);
            Assert.AreEqual(_entityList.Last().CreatedDate, _returnList.First(x => x.Id == _entityList.Last().Id).CreatedDate);
        }

        [Then(@"the DeletableGuidEntity is updated")]
        public void ThenTheDeletableGuidEntityIsUpdated()
        {
            throw new NotImplementedException();
        }

        [Then(@"the DeletableGuidEntity is deleted")]
        public void ThenTheDeletableGuidEntityIsDeleted()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var savedUser = context.Users.First(x => x.Id == _guidEntity.Id);
                Assert.IsTrue(savedUser.Deleted);
            }
        }

    }
}
