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
    public class EfcFoodItemSteps
    {

        EfcFoodItem _fooditem;
        EfcFoodItem _alternatefooditem;
        EfcMeal _meal;
        EfcSnack _snack;

        [Given(@"I have a FoodItem to create")]
        public void GivenIHaveAFoodItemToCreate()
        {
            _fooditem = new EfcFoodItem("Hot Dog", 200);
        }
        
        [Given(@"I have a FoodItem persisted in the database")]
        public async void GivenIHaveAFoodItemPersistedInTheDatabase()
        {
            _alternatefooditem = new EfcFoodItem("Fries", 250);
            _fooditem = new EfcFoodItem("Burger", 300);
            using (var context = VerdureInMemoryContext.Context)
            {
                context.FoodItems.Add(_fooditem);
                context.FoodItems.Add(_alternatefooditem);
                await context.SaveChangesAsync();
            }
        }
        
        [Given(@"the FoodItem is assigned to a Meal and a Snack")]
        public async void GivenTheFoodItemIsAssignedToAMealAndASnack()
        {
            var user = new VerdureUser("Sally");
            using (var context = VerdureInMemoryContext.Context)
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
                user = context.Users.Find(user.Id);
                _meal = new EfcMeal(user);
                context.Meals.Add(_meal);
                _snack = new EfcSnack(user);
                context.Snacks.Add(_snack);

                var fooditem = context.FoodItems.Find(_fooditem.Id);
                var secondfooditem = context.FoodItems.Find(_alternatefooditem.Id);

                _snack.SetFoodItem(fooditem);
                _meal.AddFoodItem(fooditem);
                _meal.AddFoodItem(secondfooditem);

                await context.SaveChangesAsync();
            }
        }
        
        [When(@"I Save the FoodItem")]
        public async void WhenISaveTheFoodItem()
        {
            using(var context = VerdureInMemoryContext.Context)
            {
                context.FoodItems.Add(_fooditem);
                await context.SaveChangesAsync();
            }
        }
        
        [When(@"I delete the FoodItem")]
        public async void WhenIDeleteTheFoodItem()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var fooditem = context.FoodItems.Find(_fooditem.Id);
                fooditem.Delete();
                await context.SaveChangesAsync();
            }
        }
        
        [Then(@"my FoodItem is persisted in the database")]
        public void ThenMyFoodItemIsPersistedInTheDatabase()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var savedFoodItem = context.FoodItems.Find(_fooditem.Id);
                Assert.AreEqual(savedFoodItem.Name, _fooditem.Name);
                Assert.AreEqual(savedFoodItem.Id, _fooditem.Id);
                Assert.AreEqual(savedFoodItem.Calories, _fooditem.Calories);
                Assert.AreEqual(savedFoodItem.CreatedDate, _fooditem.CreatedDate);
            }
        }
        
        [Then(@"my FoodItem is deleted")]
        public void ThenMyFoodItemIsDeleted()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var fooditem = context.FoodItems.Find(_fooditem.Id);
                Assert.IsTrue(fooditem.Deleted);
            }
        }
        
        [Then(@"the Snack and Meal still exist with a historic record depsite the FoodItem disappearing")]
        public void ThenTheSnackAndMealStillExistWithAHistoricRecordDepsiteTheFoodItemDisappearing()
        {
            using (var context = VerdureInMemoryContext.Context)
            {
                var meal = context.Meals.Include(x => x.MealFoodItemIds).ThenInclude(x => x.FoodItem).First(x => x.Id == _meal.Id);
                var snack = context.Snacks.Include(x => x.Food).First(x => x.Id == _snack.Id);

                Assert.IsNotNull(snack);
                Assert.IsNotNull(meal);

                Assert.AreEqual(meal.Food.Count(), 2);
                Assert.IsTrue(meal.Food.First(x => x.Id == _fooditem.Id).Deleted);
                Assert.IsFalse(meal.Food.First(x => x.Id == _alternatefooditem.Id).Deleted);
                Assert.IsNotNull(snack.Food);
                Assert.IsTrue(snack.Food.Deleted);

            }
        }
    }
}
