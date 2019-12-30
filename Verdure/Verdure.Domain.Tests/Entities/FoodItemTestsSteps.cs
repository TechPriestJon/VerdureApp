using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Tests.Entities
{
    [Binding]
    public class FoodItemSteps
    {
        IFoodItem _foodItem;
        string _foodItemName;
        long _calories;

        [Given(@"I have eaten a food item with calories and name")]
        public void GivenIHaveEatenAFoodItemWithCaloriesAndName()
        {
            _foodItemName = "Hamburger";
            _calories = 420;
        }
        
        [When(@"I create a food item")]
        public void WhenICreateAFoodItem()
        {
            _foodItem = new FoodItem(_foodItemName, _calories);
        }
        
        [Then(@"my food item has the same calories and name")]
        public void ThenMyFoodItemHasTheSameCaloriesAndName()
        {
            Assert.AreEqual(_foodItem.Calories, _calories);
            Assert.AreEqual(_foodItem.Name, _foodItemName);
            Assert.IsNotNull(_foodItem.Id);
            Assert.AreEqual(_foodItem.CreatedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_foodItem.CreatedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_foodItem.CreatedDate.Year, DateTimeOffset.UtcNow.Year);
            Assert.AreEqual(_foodItem.ModifiedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_foodItem.ModifiedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_foodItem.ModifiedDate.Year, DateTimeOffset.UtcNow.Year);
        }
    }
}
