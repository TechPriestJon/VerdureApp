Feature: EfcFoodItem
	As a user
	In order to store data about food I eat
	I want to have a store of food data

@fooditem
Scenario: Create FoodItem
	Given I have a FoodItem to create
	When I Save the FoodItem
	Then my FoodItem is persisted in the database

@fooditem
Scenario: Delete FoodItem
	Given I have a FoodItem persisted in the database
	When I delete the FoodItem
	Then my FoodItem is deleted
	
@fooditem meal snack
Scenario: Delete affects Meal and Snack
	Given I have a FoodItem persisted in the database
	And the FoodItem is assigned to a Meal and a Snack
	When I delete the FoodItem
	Then the Snack and Meal still exist with a historic record depsite the FoodItem disappearing
