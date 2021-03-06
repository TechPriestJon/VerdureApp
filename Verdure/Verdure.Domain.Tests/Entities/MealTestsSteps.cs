﻿using NUnit.Framework;
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
            _foodItemOneMealOne = new FoodItem("Sandwich", 250);
            _foodItemTwoMealOne = new FoodItem("Crisps", 100);
        }
        
        [Given(@"I have another food item for my second meal")]
        public void GivenIHaveAnotherFoodItemForMySecondMeal()
        {
            _foodItemOneMealTwo = new FoodItem("Hotdog", 150);
        }
        
        [When(@"I create a meal")]
        public void WhenICreateAMeal()
        {
            _meal = new Meal(_user);
        }
        
        [When(@"create another meal")]
        public void WhenCreateAnotherMeal()
        {
            _anotherMeal = new Meal(_user);
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
            Assert.AreEqual(_meal.CreatedDate.Day, DateTime.UtcNow.Day);
            Assert.AreEqual(_meal.CreatedDate.Month, DateTime.UtcNow.Month);
            Assert.AreEqual(_meal.CreatedDate.Year, DateTime.UtcNow.Year);
            Assert.AreEqual(_meal.ModifiedDate.Day, DateTime.UtcNow.Day);
            Assert.AreEqual(_meal.ModifiedDate.Month, DateTime.UtcNow.Month);
            Assert.AreEqual(_meal.ModifiedDate.Year, DateTime.UtcNow.Year);
        }
        
        [Then(@"my meal has my user attached")]
        public void ThenMyMealHasMyUserAttached()
        {
            Assert.AreEqual(_meal.User.Id, _user.Id);
        }
        
        [Then(@"my meals are created")]
        public void ThenMyMealsAreCreated()
        {
            Assert.IsNotNull(_meal.Id);
            Assert.IsNotNull(_anotherMeal.Id);
        }
        
        [Then(@"my meal has the food items attached")]
        public void ThenMyMealHasTheFoodItemsAttached()
        {
            Assert.AreEqual(_meal.Food.Count(), 2);

            Assert.IsNotNull(_meal.Food.First());
            Assert.IsNotNull(_meal.Food.Last());

            Assert.AreEqual(_meal.Food.First().Name, _foodItemOneMealOne.Name);
            Assert.AreEqual(_meal.Food.Last().Name, _foodItemTwoMealOne.Name);
        }
        
        [Then(@"my meals have the correct food items")]
        public void ThenMyMealsHaveTheCorrectFoodItems()
        {
            Assert.AreEqual(_meal.Food.Count(), 2);
            Assert.AreEqual(_anotherMeal.Food.Count(), 1);

            Assert.IsNotNull(_meal.Food.First());
            Assert.IsNotNull(_meal.Food.Last());
            Assert.IsNotNull(_anotherMeal.Food.First());

            Assert.AreEqual(_meal.Food.First().Name, _foodItemOneMealOne.Name);
            Assert.AreEqual(_meal.Food.Last().Name, _foodItemTwoMealOne.Name);
            Assert.AreEqual(_anotherMeal.Food.First().Name, _foodItemOneMealTwo.Name);
        }
    }
}
