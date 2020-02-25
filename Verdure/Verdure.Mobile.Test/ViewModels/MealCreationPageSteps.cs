using System;
using TechTalk.SpecFlow;

namespace Verdure.Mobile.Test.ViewModels
{
    [Binding]
    public class MealCreationPageSteps
    {
        [Given(@"I have the MealCreationPage ViewModel")]
        public void GivenIHaveTheMealCreationPageViewModel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have the MealCreationPage ViewModel and details for a Meal")]
        public void GivenIHaveTheMealCreationPageViewModelAndDetailsForAMeal()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"MealCreationPage is loaded")]
        public void WhenMealCreationPageIsLoaded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I input the Meal details")]
        public void WhenIInputTheMealDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I save the Meal")]
        public void WhenISaveTheMeal()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the MealCreationPage is loaded successfully")]
        public void ThenTheMealCreationPageIsLoadedSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Meal is saved to the database")]
        public void ThenTheMealIsSavedToTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
