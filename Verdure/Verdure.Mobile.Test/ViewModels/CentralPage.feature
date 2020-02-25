Feature: CentralPage
	As a user
	I need a page to navigate around the system
	So I can reach all the other pages

@CentralPage ViewModel
Scenario: Load CentralPage ViewModel
	Given I have the CentralPage ViewModel
	When CentralPage is loaded
	Then the CentralPage is loaded successfully

@CentralPage ViewModel
Scenario: Navigate from CentralPage to DiaryPage
	Given I have the CentralPage ViewModel and a function to navigate
	When I press the DiaryPage navigate button 
	Then I navigate from the CentralPage to the DiaryPage

@CentralPage ViewModel
Scenario: Navigate from CentralPage to FoodItemCreationPage
	Given I have the CentralPage ViewModel and a function to navigate
	When I press the FoodItemCreationPage navigate button 
	Then I navigate from the CentralPage to the FoodItemCreationPage

@CentralPage ViewModel
Scenario: Navigate from CentralPage to MealCreationPage
	Given I have the CentralPage ViewModel and a function to navigate
	When I press the MealCreationPage navigate button 
	Then I navigate from the CentralPage to the MealCreationPage

@CentralPage ViewModel
Scenario: Navigate from CentralPage to SettingsPage
	Given I have the CentralPage ViewModel and a function to navigate
	When I press the SettingsPage navigate button 
	Then I navigate from the CentralPage to the SettingsPage
	
@CentralPage ViewModel
Scenario: Navigate from CentralPage to SnackCreationPage
	Given I have the CentralPage ViewModel and a function to navigate
	When I press the SnackCreationPage navigate button 
	Then I navigate from the CentralPage to the SnackCreationPage
