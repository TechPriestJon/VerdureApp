Feature: FoodItemCreationPage
	As a user
	I need a page to create food items
	So I can use food items in meals and snacks

@FoodItemCreationPage ViewModel
Scenario: Load FoodItemCreationPage ViewModel
	Given I have the FoodItemCreationPage ViewModel
	When FoodItemCreationPage is loaded
	Then the FoodItemCreationPage is loaded successfully

@FoodItemCreationPage ViewModel
Scenario: Save FoodItem in FoodItemCreationPage ViewModel
	Given I have the FoodItemCreationPage ViewModel and details for a FoodItem
	When I input the FoodItem details
	And I save the FoodItem
	Then the FoodItem is saved to the database