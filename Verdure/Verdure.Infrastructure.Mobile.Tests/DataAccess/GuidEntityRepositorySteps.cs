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
    public class GuidEntityRepositorySteps
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
            _repository = new GuidEntityRepository<VerdureUser>(_context);
        }

        [Given(@"I have a GuidEntity")]
        public void GivenIHaveAGuidEntity()
        {
            _guidEntity = new VerdureUser("Carla");
            _repository.Create(_guidEntity);
        }

        [Given(@"I have a GuidEntity persisted")]
        public void GivenIHaveAGuidEntityPersisted()
        {
            _guidEntity = new VerdureUser("Mike");
            _repository.Create(_guidEntity);
        }
        
        [Given(@"I have two GuidEntity persisted")]
        public void GivenIHaveTwoGuidEntityPersisted()
        {
            _entityList = new List<VerdureUser>()
            {
                new VerdureUser("Ken"),
                new VerdureUser("Claire")
            };
            _repository.Create(_entityList.First());
            _repository.Create(_entityList.Last());
        }
        
        [When(@"I create the GuidEntity")]
        public void WhenICreateTheGuidEntity()
        {
            _repository.Create(_guidEntity);
        }
        
        [When(@"I get the GuidEntity based on id")]
        public async void WhenIGetTheGuidEntityBasedOnId()
        {
            _returnEntity = await _repository.Get(_guidEntity.Id);
        }
        
        [When(@"I get the GuidEntities")]
        public async void WhenIGetTheGuidEntities()
        {
            var returnValues = await _repository.Get();
            _returnList = returnValues.ToList();
        }
        
        [When(@"I update the GuidEntity")]
        public void WhenIUpdateTheGuidEntity()
        {
            throw new NotImplementedException();
        }
        
        [When(@"I delete the GuidEntity based on id")]
        public async void WhenIDeleteTheGuidEntityBasedOnId()
        {
            await _repository.Delete(_guidEntity.Id);
        }
        
        [Then(@"the GuidEntity is stored in the database")]
        public void ThenTheGuidEntityIsStoredInTheDatabase()
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
        
        [Then(@"the GuidEntity is returned")]
        public void ThenTheGuidEntityIsReturned()
        {
            Assert.AreEqual(_returnEntity.Name, _guidEntity.Name);
            Assert.AreEqual(_returnEntity.Id, _guidEntity.Id);
            Assert.AreEqual(_returnEntity.CreatedDate, _guidEntity.CreatedDate);
        }
        
        [Then(@"both GuidEntities are returned")]
        public void ThenBothGuidEntitiesAreReturned()
        {
            Assert.AreEqual(_entityList.First().Name, _returnList.First(x => x.Id == _entityList.First().Id).Name);
            Assert.AreEqual(_entityList.First().CreatedDate, _returnList.First(x => x.Id == _entityList.First().Id).CreatedDate);


            Assert.AreEqual(_entityList.Last().Name, _returnList.First(x => x.Id == _entityList.Last().Id).Name);
            Assert.AreEqual(_entityList.Last().CreatedDate, _returnList.First(x => x.Id == _entityList.Last().Id).CreatedDate);
        }
        
        [Then(@"the GuidEntity is updated")]
        public void ThenTheGuidEntityIsUpdated()
        {
            throw new NotImplementedException();
        }

        [Then(@"the GuidEntity is deleted")]
        public void ThenTheGuidEntityIsDeleted()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var savedUser = context.Users.First(x => x.Id == _guidEntity.Id);
                Assert.IsNull(savedUser);
            }
        }
    }
}
