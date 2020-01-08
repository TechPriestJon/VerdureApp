using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;
using Verdure.Infrastructure.EFCore;
using Verdure.Infrastructure.Mobile.DataAccess;
using Verdure.Infrastructure.Mobile.Tests.Config;

namespace Verdure.Infrastructure.Mobile.Tests.DataAccess
{
    [Binding]
    public class DeletableDeletableIdEntityRepositorySteps
    {
        EfcFoodItem _deletableIdEntity;
        List<EfcFoodItem> _entityList;
        EfcFoodItem _returnEntity;
        List<EfcFoodItem> _returnList;
        IIdRepository<EfcFoodItem> _repository;
        VerdureInMemoryContext _context = VerdureInMemoryContext.Context;

        [Before]
        public void Setup()
        {
            _repository = new DeletableIdEntityRepository<EfcFoodItem>(_context);
        }

        [Given(@"I have a DeletableIdEntity")]
        public async void GivenIHaveADeletableIdEntity()
        {
            var user = new VerdureUser("Sally");
            using (var context = VerdureInMemoryContext.Context)
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
            _deletableIdEntity = new EfcFoodItem("Cow", 100);
        }

        [Given(@"I have a DeletableIdEntity persisted")]
        public async void GivenIHaveADeletableIdEntityPersisted()
        {
            var user = new VerdureUser("Sally");
            using (var context = VerdureInMemoryContext.Context)
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
            _deletableIdEntity = new EfcFoodItem("Sheep", 120);
            await _repository.Create(_deletableIdEntity);
        }

        [Given(@"I have two DeletableIdEntity persisted")]
        public async void GivenIHaveTwoDeletableIdEntityPersisted()
        {
            var user = new VerdureUser("Sally");
            using (var context = VerdureInMemoryContext.Context)
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
            _entityList = new List<EfcFoodItem>()
            {
                new EfcFoodItem("Pig", 134),
                new EfcFoodItem("Duck", 101)
            };
            await _repository.Create(_entityList.First());
            await _repository.Create(_entityList.Last());
        }

        [When(@"I create the DeletableIdEntity")]
        public async void WhenICreateTheDeletableIdEntity()
        {
            await _repository.Create(_deletableIdEntity);
        }

        [When(@"I get the DeletableIdEntity based on id")]
        public async void WhenIGetTheDeletableIdEntityBasedOnId()
        {
            _returnEntity = await _repository.Get(_deletableIdEntity.Id);
        }

        [When(@"I get the DeletableIdEntities")]
        public async void WhenIGetTheDeletableIdEntities()
        {
            var returnValues = await _repository.Get();
            _returnList = returnValues.ToList();
        }

        [When(@"I update the DeletableIdEntity")]
        public void WhenIUpdateTheDeletableIdEntity()
        {
            throw new NotImplementedException();
        }

        [When(@"I delete the DeletableIdEntity based on id")]
        public async void WhenIDeleteTheDeletableIdEntityBasedOnId()
        {
            await _repository.Delete(_deletableIdEntity.Id);
        }

        [Then(@"the DeletableIdEntity is stored in the database")]
        public void ThenTheDeletableIdEntityIsStoredInTheDatabase()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var fooditem = context.FoodItems.Find(_deletableIdEntity.Id);
                Assert.AreEqual(fooditem.Id, _deletableIdEntity.Id);
                Assert.AreEqual(fooditem.CreatedDate, _deletableIdEntity.CreatedDate);
            }
        }

        [Then(@"the DeletableIdEntity is returned")]
        public void ThenTheDeletableIdEntityIsReturned()
        {
            Assert.AreEqual(_returnEntity.Id, _deletableIdEntity.Id);
            Assert.AreEqual(_returnEntity.CreatedDate, _deletableIdEntity.CreatedDate);
        }

        [Then(@"both DeletableIdEntities are returned")]
        public void ThenBothDeletableIdEntitiesAreReturned()
        {
            Assert.AreEqual(_entityList.First().CreatedDate, _returnList.First(x => x.Id == _entityList.First().Id).CreatedDate);

            Assert.AreEqual(_entityList.Last().CreatedDate, _returnList.First(x => x.Id == _entityList.Last().Id).CreatedDate);
        }

        [Then(@"the DeletableIdEntity is updated")]
        public void ThenTheDeletableIdEntityIsUpdated()
        {
            throw new NotImplementedException();
        }

        [Then(@"the DeletableIdEntity is deleted")]
        public void ThenTheDeletableIdEntityIsDeleted()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var fooditem = context.FoodItems.First(x => x.Id == _deletableIdEntity.Id);
                Assert.IsTrue(fooditem.Deleted);
            }
        }
    }
}
