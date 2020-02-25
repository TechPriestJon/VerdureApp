using System;
using TechTalk.SpecFlow;

namespace Verdure.Mobile.Test.ViewModels
{
    [Binding]
    public class DiaryPageSteps
    {
        [Given(@"I have the DiaryPage ViewModel")]
        public void GivenIHaveTheDiaryPageViewModel()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have the DiaryPage ViewModel with data across (.*) days")]
        public void GivenIHaveTheDiaryPageViewModelWithDataAcrossDays(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have the CentralPage ViewModel and I am a day in the past with data across (.*) days")]
        public void GivenIHaveTheCentralPageViewModelAndIAmADayInThePastWithDataAcrossDays(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have the DiaryPage ViewModel and a function to navigate")]
        public void GivenIHaveTheDiaryPageViewModelAndAFunctionToNavigate()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"DiaryPage is loaded")]
        public void WhenDiaryPageIsLoaded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press the DiaryPage load past day button")]
        public void WhenIPressTheDiaryPageLoadPastDayButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press the DiaryPage load future day button")]
        public void WhenIPressTheDiaryPageLoadFutureDayButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press the DiaryPage navigate button")]
        public void WhenIPressTheDiaryPageNavigateButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the DiaryPage is loaded successfully with the current days data")]
        public void ThenTheDiaryPageIsLoadedSuccessfullyWithTheCurrentDaysData()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the past days data is loaded")]
        public void ThenThePastDaysDataIsLoaded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the future days data is loaded")]
        public void ThenTheFutureDaysDataIsLoaded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I navigate from the DiaryPage to the FoodItemCreationPage")]
        public void ThenINavigateFromTheDiaryPageToTheFoodItemCreationPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I navigate from the DiaryPage to the MealCreationPage")]
        public void ThenINavigateFromTheDiaryPageToTheMealCreationPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
