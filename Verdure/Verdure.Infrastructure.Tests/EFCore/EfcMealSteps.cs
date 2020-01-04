using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Infrastructure.EFCore;
using Verdure.Infrastructure.Tests.Config;

namespace Verdure.Infrastructure.Tests
{
    [Binding]
    public class EfcMealSteps
    {
        EfcMeal _meal;
        VerdureUser _user;
        long _fooditemId;

        [Given(@"a user to create the Meal with")]
        public async void GivenAUserToCreateTheMealWith()
        {
            _user = new VerdureUser("Sally");
            using (var context = VerdureInMemoryContext.Context)
            {
                context.Users.Add(_user);
                await context.SaveChangesAsync();
            }
        }

        [Given(@"I have a Meal to create")]
        public void GivenIHaveAMealToCreate()
        {
           
        }


        [Given(@"I have a Meal persisted in the database")]
        public void GivenIHaveAMealPersistedInTheDatabase()
        {
            GivenAUserToCreateTheMealWith();
            GivenIHaveAMealToCreate();
            WhenISaveTheMeal();
        }

        [Given(@"I have a Meal with a FoodItem persisted in the database")]
        public async void GivenIHaveAMealWithAFoodItemPersistedInTheDatabase()
        {
            GivenAUserToCreateTheMealWith();
            GivenIHaveAMealToCreate();
            WhenISaveTheMeal();
            using (var context = VerdureInMemoryContext.Context)
            {
                var fooditem = context.FoodItems.First();
                _fooditemId = fooditem.Id;
                var meal = context.Meals.Find(_meal.Id);
                meal.AddFoodItem(fooditem);
                await context.SaveChangesAsync();
            }
        }
        
        [When(@"I Save the Meal")]
        public async void WhenISaveTheMeal()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var user = context.Users.Find(_user.Id);
                _meal = new EfcMeal(user);
                context.Meals.Add(_meal);
                await context.SaveChangesAsync();
            }
        }
        
        [When(@"I add the FoodItem to the Meal and Save")]
        public async void WhenIAddTheFoodItemToTheMealAndSave()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var fooditem = context.FoodItems.First();
                _fooditemId = fooditem.Id;
                var meal = context.Meals.Find(_meal.Id);
                meal.AddFoodItem(fooditem);
                await context.SaveChangesAsync();
            }
        }
        
        [When(@"I remove the FoodItem to the Meal and Save")]
        public async void WhenIRemoveTheFoodItemToTheMealAndSave()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var meal = context.Meals.Include(x => x.MealFoodItemIds)
                    .ThenInclude(y => y.FoodItem).First(x => x.Id == _meal.Id);
                meal.RemoveFoodItem(_fooditemId);
                await context.SaveChangesAsync();
            }
        }
        
        [When(@"I delete the Meal")]
        public async void WhenIDeleteTheMeal()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var meal = context.Meals.Find(_meal.Id);
                context.Meals.Remove(meal);
                await context.SaveChangesAsync();
            }
        }
        
        [Then(@"my Meal is persisted in the database")]
        public void ThenMyMealIsPersistedInTheDatabase()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var meal = context.Meals.Include(x => x.User).First(x => x.Id == _meal.Id);
                Assert.AreEqual(meal.Id, _meal.Id);
                Assert.AreEqual(meal.User.Id, _meal.User.Id);
                Assert.AreEqual(meal.CreatedDate, _meal.CreatedDate);
            }
        }
        
        [Then(@"my Meal is persisted in the database with the FoodItem")]
        public void ThenMyMealIsPersistedInTheDatabaseWithTheFoodItem()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var meal = context.Meals.Include(x => x.User)
                    .Include(x => x.MealFoodItemIds)
                    .ThenInclude(y => y.FoodItem).First(x => x.Id == _meal.Id);
                Assert.AreEqual(meal.Id, _meal.Id);
                Assert.AreEqual(meal.User.Id, _meal.User.Id);
                Assert.AreEqual(meal.CreatedDate, _meal.CreatedDate);
                Assert.AreEqual(meal.Food.Count(), 1);
                Assert.AreEqual(meal.Food.First().Id, _fooditemId);
            }
        }
        
        [Then(@"my Meal is persisted in the database without the FoodItem")]
        public void ThenMyMealIsPersistedInTheDatabaseWithoutTheFoodItem()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var meal = context.Meals.Include(x => x.User)
                    .Include(x => x.MealFoodItemIds)
                    .ThenInclude(y => y.FoodItem).First(x => x.Id == _meal.Id);
                Assert.AreEqual(meal.Id, _meal.Id);
                Assert.AreEqual(meal.User.Id, _meal.User.Id);
                Assert.AreEqual(meal.CreatedDate, _meal.CreatedDate);
                Assert.AreEqual(meal.Food.Count(), 0);
            }
        }

        [Then(@"my Meal is deleted")]
        public void ThenMyMealIsDeleted()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var meal = context.Meals.Find(_meal.Id);
                Assert.IsNull(meal);
            }
        }
        
        [Then(@"the FoodItem is still persisted without meal")]
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
