Feature: DiaryPage
	As a user
	I need a page to show a diary
	So I can see all of the events of the day

@DiaryPage ViewModel
Scenario: Load DiaryPage ViewModel
	Given I have the DiaryPage ViewModel
	When DiaryPage is loaded
	Then the DiaryPage is loaded successfully with the current days data

@DiaryPage ViewModel
Scenario: Load past day
	Given I have the DiaryPage ViewModel with data across 2 days
	When I press the DiaryPage load past day button
	Then the past days data is loaded

@DiaryPage ViewModel
Scenario: Load future day
	Given I have the CentralPage ViewModel and I am a day in the past with data across 2 days
	When I press the DiaryPage load future day button
	Then the future days data is loaded

@DiaryPage ViewModel
Scenario: Navigate from DiaryPage to FoodItemCreationPage
	Given I have the DiaryPage ViewModel and a function to navigate
	When I press the DiaryPage navigate button 
	Then I navigate from the DiaryPage to the FoodItemCreationPage

@DiaryPage ViewModel
Scenario: Navigate from CentralPage to MealCreationPage
	Given I have the DiaryPage ViewModel and a function to navigate
	When I press the DiaryPage navigate button 
	Then I navigate from the DiaryPage to the MealCreationPage