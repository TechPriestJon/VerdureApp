using System;
using TechTalk.SpecFlow;

namespace Verdure.Mobile.Test.ViewModels
{
    [Binding]
    public class FoodItemCreationPageSteps
    {
        [Given(@"I have the FoodItemCreationPage ViewModel")]
        public void GivenIHaveTheFoodItemCreationPageViewModel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have the FoodItemCreationPage ViewModel and details for a FoodItem")]
        public void GivenIHaveTheFoodItemCreationPageViewModelAndDetailsForAFoodItem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"FoodItemCreationPage is loaded")]
        public void WhenFoodItemCreationPageIsLoaded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I input the FoodItem details")]
        public void WhenIInputTheFoodItemDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I save the FoodItem")]
        public void WhenISaveTheFoodItem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the FoodItemCreationPage is loaded successfully")]
        public void ThenTheFoodItemCreationPageIsLoadedSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the FoodItem is saved to the database")]
        public void ThenTheFoodItemIsSavedToTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
