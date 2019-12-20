using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Tests.Entities
{
    [Binding]
    public class MealSteps
    {
        IVerdureUser _user;

        IFoodItem _foodItemOneMealOne;
        IFoodItem _foodItemTwoMealOne;
        IFoodItem _foodItemOneMealTwo;

        IMeal _meal;
        IMeal _anotherMeal;

        [Given(@"I have eaten a meal")]
        public void GivenIHaveEatenAMeal()
        { }
        
        [Given(@"I create my user record for my meal")]
        public void GivenICreateMyUserRecordForMyMeal()
        {
            _user = new VerdureUser("Mike");
        }
        
        [Given(@"another meal")]
        public void GivenAnotherMeal()
        {
        }
            
        [Given(@"I have two food items for my meal")]
        public void GivenIHaveFoodItemsForMyMeal()
        {
            _foodItemOneMealOne = new FoodItem("Sandwich", 250, 1);
            _foodItemTwoMealOne = new FoodItem("Crisps", 100, 2);
        }
        
        [Given(@"I have another food item for my second meal")]
        public void GivenIHaveAnotherFoodItemForMySecondMeal()
        {
            _foodItemOneMealTwo = new FoodItem("Hotdog", 150, 3);
        }
        
        [When(@"I create a meal")]
        public void WhenICreateAMeal()
        {
            _meal = new Meal(_user, 1);
        }
        
        [When(@"create another meal")]
        public void WhenCreateAnotherMeal()
        {
            _anotherMeal = new Meal(_user, 2);
        }
        
        [When(@"I add the food items to my meal")]
        public void WhenIAddTheFoodItemsToMyMeal()
        {
            _meal.AddFoodItem(_foodItemOneMealOne);
            _meal.AddFoodItem(_foodItemTwoMealOne);
        }

        [When(@"I add the food items to my other meal")]
        public void WhenIAddTheFoodItemsTomyOtherMeal()
        {
            _anotherMeal.AddFoodItem(_foodItemOneMealTwo);
        }

        [Then(@"my meal is created")]
        public void ThenMyMealIsCreated()
        {
            Assert.IsNotNull(_meal.Id);
            Assert.Greater(_meal.Id, 0);
            Assert.AreEqual(_meal.CreatedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_meal.CreatedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_meal.CreatedDate.Year, DateTimeOffset.UtcNow.Year);
            Assert.AreEqual(_meal.ModifiedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_meal.ModifiedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_meal.ModifiedDate.Year, DateTimeOffset.UtcNow.Year);
        }
        
        [Then(@"my meal has my user attached")]
        public void ThenMyMealHasMyUserAttached()
        {
            Assert.AreEqual(_meal.UserId, _user.Id);
        }
        
        [Then(@"my meals are created")]
        public void ThenMyMealsAreCreated()
        {
            Assert.IsNotNull(_meal.Id);
            Assert.Greater(_meal.Id, 0);
            Assert.IsNotNull(_anotherMeal.Id);
            Assert.Greater(_anotherMeal.Id, 0);
        }
        
        [Then(@"the meals have different ids")]
        public void ThenTheMealsHaveDifferentIds()
        {
            Assert.Greater(_anotherMeal.Id, _meal.Id);
        }
        
        [Then(@"my meal has the food items attached")]
        public void ThenMyMealHasTheFoodItemsAttached()
        {
            Assert.AreEqual(_meal.Food.Count(), 2);

            Assert.IsNotNull(_meal.Food.First(x => x.Id == _foodItemOneMealOne.Id));
            Assert.IsNotNull(_meal.Food.First(x => x.Id == _foodItemTwoMealOne.Id));

            Assert.AreEqual(_meal.Food.First(x => x.Id == _foodItemOneMealOne.Id).Name, _foodItemOneMealOne.Name);
            Assert.AreEqual(_meal.Food.First(x => x.Id == _foodItemTwoMealOne.Id).Name, _foodItemTwoMealOne.Name);
        }
        
        [Then(@"my meals have the correct food items")]
        public void ThenMyMealsHaveTheCorrectFoodItems()
        {
            Assert.AreEqual(_meal.Food.Count(), 2);
            Assert.AreEqual(_anotherMeal.Food.Count(), 1);

            Assert.IsNotNull(_meal.Food.First(x => x.Id == _foodItemOneMealOne.Id));
            Assert.IsNotNull(_meal.Food.First(x => x.Id == _foodItemTwoMealOne.Id));
            Assert.IsNotNull(_anotherMeal.Food.First(x => x.Id == _foodItemOneMealTwo.Id));

            Assert.AreEqual(_meal.Food.First(x => x.Id == _foodItemOneMealOne.Id).Name, _foodItemOneMealOne.Name);
            Assert.AreEqual(_meal.Food.First(x => x.Id == _foodItemTwoMealOne.Id).Name, _foodItemTwoMealOne.Name);
            Assert.AreEqual(_anotherMeal.Food.First(x => x.Id == _foodItemOneMealTwo.Id).Name, _foodItemOneMealTwo.Name);
        }
    }
}
