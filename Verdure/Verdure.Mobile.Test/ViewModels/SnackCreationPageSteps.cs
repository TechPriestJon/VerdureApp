using System;
using TechTalk.SpecFlow;

namespace Verdure.Mobile.Test.ViewModels
{
    [Binding]
    public class SnackCreationPageSteps
    {
        [Given(@"I have the SnackCreation ViewModel")]
        public void GivenIHaveTheSnackCreationViewModel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have the SnackCreationPage ViewModel and details for a Snack")]
        public void GivenIHaveTheSnackCreationPageViewModelAndDetailsForASnack()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"SnackCreation is loaded")]
        public void WhenSnackCreationIsLoaded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I input the Snack details")]
        public void WhenIInputTheSnackDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I save the Snack")]
        public void WhenISaveTheSnack()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the SnackCreation is loaded successfully")]
        public void ThenTheSnackCreationIsLoadedSuccessfully()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Snack is saved to the database")]
        public void ThenTheSnackIsSavedToTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
