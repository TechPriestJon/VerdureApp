Feature: MealCreationPage
	As a user
	I need a page to create meals
	So I can track my meals in a diary

@MealCreationPage ViewModel
Scenario: Load MealCreationPage ViewModel
	Given I have the MealCreationPage ViewModel
	When MealCreationPage is loaded
	Then the MealCreationPage is loaded successfully

@MealCreationPage ViewModel
Scenario: Save Meal in MealCreationPage ViewModel
	Given I have the MealCreationPage ViewModel and details for a Meal
	When I input the Meal details
	And I save the Meal
	Then the Meal is saved to the database