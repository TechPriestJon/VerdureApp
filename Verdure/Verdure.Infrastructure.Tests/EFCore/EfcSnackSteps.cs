using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Infrastructure.EFCore;
using Verdure.Infrastructure.Tests.Config;

namespace Verdure.Infrastructure.Tests.EFCore
{
    [Binding]
    public class EfcSnackSteps
    {
        EfcSnack _snack;
        VerdureUser _user;
        long _fooditemId;

        [Given(@"a user to create the Snack with")]
        public async void GivenAUserToCreateTheSnackWith()
        {
            _user = new VerdureUser("Lucy");
            using (var context = VerdureInMemoryContext.Context)
            {
                context.Users.Add(_user);
                await context.SaveChangesAsync();
            }
        }

        [Given(@"I have a Snack to create")]
        public void GivenIHaveASnackToCreate()
        {

        }


        [Given(@"I have a Snack persisted in the database")]
        public void GivenIHaveASnackPersistedInTheDatabase()
        {
            GivenAUserToCreateTheSnackWith();
            GivenIHaveASnackToCreate();
            WhenISaveTheSnack();
        }

        [Given(@"I have a Snack with a FoodItem persisted in the database")]
        public async void GivenIHaveASnackWithAFoodItemPersistedInTheDatabase()
        {
            GivenAUserToCreateTheSnackWith();
            GivenIHaveASnackToCreate();
            WhenISaveTheSnack();
            using (var context = VerdureInMemoryContext.Context)
            {
                var fooditem = context.FoodItems.First();
                _fooditemId = fooditem.Id;
                var snack = context.Snacks.Find(_snack.Id);
                snack.SetFoodItem(fooditem);
                await context.SaveChangesAsync();
            }
        }

        [When(@"I Save the Snack")]
        public async void WhenISaveTheSnack()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var user = context.Users.Find(_user.Id);
                _snack = new EfcSnack(user);
                context.Snacks.Add(_snack);
                await context.SaveChangesAsync();
            }
        }

        [When(@"I add the FoodItem to the Snack and Save")]
        public async void WhenIAddTheFoodItemToTheSnackAndSave()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var fooditem = context.FoodItems.First();
                _fooditemId = fooditem.Id;
                var snack = context.Snacks.Find(_snack.Id);
                snack.SetFoodItem(fooditem);
                await context.SaveChangesAsync();
            }
        }

        [When(@"I update the FoodItem to the Snack and Save")]
        public async void WhenIRemoveTheFoodItemToTheSnackAndSave()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var snack = context.Snacks.Include(x => x.Food).First(x => x.Id == _snack.Id);
                var fooditem = context.FoodItems.Last();
                Assert.AreNotEqual(snack.Food.Id, fooditem.Id);
                _fooditemId = fooditem.Id;
                snack.SetFoodItem(fooditem);
                await context.SaveChangesAsync();
            }
        }

        [When(@"I delete the Snack")]
        public async void WhenIDeleteTheSnack()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var snack = context.Snacks.Find(_snack.Id);
                context.Snacks.Remove(snack);
                await context.SaveChangesAsync();
            }
        }

        [Then(@"my Snack is persisted in the database")]
        public void ThenMySnackIsPersistedInTheDatabase()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var snack = context.Snacks.Include(x => x.User).First(x => x.Id == _snack.Id);
                Assert.AreEqual(snack.Id, _snack.Id);
                Assert.AreEqual(snack.User.Id, _snack.User.Id);
                Assert.AreEqual(snack.CreatedDate, _snack.CreatedDate);
            }
        }

        [Then(@"my Snack is persisted in the database with the FoodItem")]
        public void ThenMySnackIsPersistedInTheDatabaseWithTheFoodItem()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var snack = context.Snacks.Include(x => x.User)
                    .Include(x => x.Food).First(x => x.Id == _snack.Id);
                Assert.AreEqual(snack.Id, _snack.Id);
                Assert.AreEqual(snack.User.Id, _snack.User.Id);
                Assert.AreEqual(snack.CreatedDate, _snack.CreatedDate);
                Assert.AreEqual(snack.Food.Id, _fooditemId);
            }
        }

        [Then(@"my Snack is persisted in the database with the new FoodItem")]
        public void ThenMySnackIsPersistedInTheDatabaseWithoutTheFoodItem()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var snack = context.Snacks.Include(x => x.User)
                    .Include(x => x.Food).First(x => x.Id == _snack.Id);
                Assert.AreEqual(snack.Id, _snack.Id);
                Assert.AreEqual(snack.User.Id, _snack.User.Id);
                Assert.AreEqual(snack.CreatedDate, _snack.CreatedDate);
                Assert.AreEqual(snack.Food.Id, _fooditemId);
            }
        }

        [Then(@"my Snack is deleted")]
        public void ThenMySnackIsDeleted()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var snack = context.Snacks.Find(_snack.Id);
                Assert.IsNull(snack);
            }
        }

        [Then(@"the FoodItem is still persisted without snack")]
        public void ThenTheFoodItemIsStillPersisted()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var fooditem = context.FoodItems.First();
                Assert.AreEqual(_fooditemId, fooditem.Id);
            }
        }
    }
}
