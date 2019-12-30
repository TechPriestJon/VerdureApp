using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Verdure.Domain.Entities;
using Verdure.Domain.Interfaces;

namespace Verdure.Domain.Tests.Entities
{
    [Binding]
    public class SnackTestsSteps
    {
        IVerdureUser _user;

        IFoodItem _foodItemOneSnackOne;
        IFoodItem _foodItemOneSnackTwo;

        ISnack _snack;
        ISnack _anotherSnack;

        [Given(@"I have eaten a snack")]
        public void GivenIHaveEatenASnack()
        {  }
        
        [Given(@"I create my user record for my snack")]
        public void GivenICreateMyUserRecordForMySnack()
        {
            _user = new VerdureUser("Pete");
        }
        
        [Given(@"another snack")]
        public void GivenAnotherSnack()
        {   }
        
        [Given(@"I have a food item for my snack")]
        public void GivenIHaveFoodItemsForMySnack()
        {
            _foodItemOneSnackOne = new FoodItem("Apple", 80);
        }
        
        [Given(@"I have another food item for my second snack")]
        public void GivenIHaveAnotherFoodItemForMySecondSnack()
        {
            _foodItemOneSnackTwo = new FoodItem("Cookie", 100);
        }
        
        [When(@"I create a snack")]
        public void WhenICreateASnack()
        {
            _snack = new Snack(_user);
        }
        
        [When(@"create another snack")]
        public void WhenCreateAnotherSnack()
        {
            _anotherSnack = new Snack(_user);
        }
        
        [When(@"I add the food item to my snack")]
        public void WhenIAddTheFoodItemsToMySnack()
        {
            _snack.SetFoodItem(_foodItemOneSnackOne);
        }

        [When(@"I add the food item to my other snack")]
        public void WhenIAddTheFoodItemToMyOtherSnack()
        {
            _anotherSnack.SetFoodItem(_foodItemOneSnackTwo);
        }

        [Then(@"my snack is created")]
        public void ThenMySnackIsCreated()
        {
            Assert.IsNotNull(_snack.Id);
            Assert.AreEqual(_snack.CreatedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_snack.CreatedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_snack.CreatedDate.Year, DateTimeOffset.UtcNow.Year);
            Assert.AreEqual(_snack.ModifiedDate.Day, DateTimeOffset.UtcNow.Day);
            Assert.AreEqual(_snack.ModifiedDate.Month, DateTimeOffset.UtcNow.Month);
            Assert.AreEqual(_snack.ModifiedDate.Year, DateTimeOffset.UtcNow.Year);
        }
        
        [Then(@"my snack has my user attached")]
        public void ThenMySnackHasMyUserAttached()
        {
            Assert.AreEqual(_snack.User.Id, _user.Id);
        }
        
        [Then(@"my snacks are created")]
        public void ThenMySnacksAreCreated()
        {
            Assert.IsNotNull(_snack.Id);
            Assert.IsNotNull(_anotherSnack.Id);
        }
        
        [Then(@"my snack has the food items attached")]
        public void ThenMySnackHasTheFoodItemsAttached()
        {
            Assert.IsNotNull(_snack.Food);

            Assert.AreEqual(_snack.Food.Name, _foodItemOneSnackOne.Name);
        }
        
        [Then(@"my snacks have the correct food items")]
        public void ThenMySnacksHaveTheCorrectFoodItems()
        {
            Assert.IsNotNull(_snack.Food);
            Assert.IsNotNull(_anotherSnack.Food);

            Assert.AreEqual(_snack.Food.Name, _foodItemOneSnackOne.Name);
            Assert.AreEqual(_anotherSnack.Food.Name, _foodItemOneSnackTwo.Name);
        }
    }
}
