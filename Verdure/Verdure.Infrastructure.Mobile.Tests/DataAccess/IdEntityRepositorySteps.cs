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
    public class IdEntityRepositorySteps
    {
        EfcMeal _idEntity;
        List<EfcMeal> _entityList;
        EfcMeal _returnEntity;
        List<EfcMeal> _returnList;
        IIdRepository<EfcMeal> _repository;
        VerdureInMemoryContext _context = VerdureInMemoryContext.Context;

        [Before]
        public void Setup()
        {
            _context = VerdureInMemoryContext.Context;
            _repository = new IdEntityRepository<EfcMeal>(_context);
        }

        [Given(@"I have a IdEntity")]
        public async void GivenIHaveAIdEntity()
        {
            var user = new VerdureUser("Sally");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            _idEntity = new EfcMeal(user);
        }
        
        [Given(@"I have a IdEntity persisted")]
        public async void GivenIHaveAIdEntityPersisted()
        {
            var user = new VerdureUser("Sally");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            _idEntity = new EfcMeal(user);
            await _repository.Create(_idEntity);
        }
        
        [Given(@"I have two IdEntity persisted")]
        public async void GivenIHaveTwoIdEntityPersisted()
        {
            var user = new VerdureUser("Sally");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            _entityList = new List<EfcMeal>()
            {
                new EfcMeal(user),
                new EfcMeal(user)
            };
            await _repository.Create(_entityList.First());
            await _repository.Create(_entityList.Last());
        }
        
        [When(@"I create the IdEntity")]
        public async void WhenICreateTheIdEntity()
        {
            await _repository.Create(_idEntity);
        }

        [When(@"I get the IdEntity based on id")]
        public async void WhenIGetTheIdEntityBasedOnId()
        {
            _returnEntity = await _repository.Get(_idEntity.Id);
        }

        [When(@"I get the IdEntities")]
        public async void WhenIGetTheIdEntities()
        {
            var returnValues = await _repository.Get();
            _returnList = returnValues.ToList();
        }

        [When(@"I update the IdEntity")]
        public void WhenIUpdateTheIdEntity()
        {
            throw new NotImplementedException();
        }

        [When(@"I delete the IdEntity based on id")]
        public async void WhenIDeleteTheIdEntityBasedOnId()
        {
            await _repository.Delete(_idEntity.Id);
        }

        [Then(@"the IdEntity is stored in the database")]
        public void ThenTheIdEntityIsStoredInTheDatabase()
        {
            var meal = _context.Meals.Find(_idEntity.Id);
            Assert.AreEqual(meal.Id, _idEntity.Id);
            Assert.AreEqual(meal.CreatedDate, _idEntity.CreatedDate);
        }

        [Then(@"the IdEntity is returned")]
        public void ThenTheIdEntityIsReturned()
        {
            Assert.AreEqual(_returnEntity.Id, _idEntity.Id);
            Assert.AreEqual(_returnEntity.CreatedDate, _idEntity.CreatedDate);
        }

        [Then(@"both IdEntities are returned")]
        public void ThenBothIdEntitiesAreReturned()
        {
            Assert.AreEqual(_entityList.First().CreatedDate, _returnList.First(x => x.Id == _entityList.First().Id).CreatedDate);

            Assert.AreEqual(_entityList.Last().CreatedDate, _returnList.First(x => x.Id == _entityList.Last().Id).CreatedDate);
        }

        [Then(@"the IdEntity is updated")]
        public void ThenTheIdEntityIsUpdated()
        {
            throw new NotImplementedException();
        }

        [Then(@"the IdEntity is deleted")]
        public void ThenTheIdEntityIsDeleted()
        {
            var meal = _context.Meals.ToList().FirstOrDefault(x => x.Id == _idEntity.Id);
            Assert.IsNull(meal);

        }
    }
}
