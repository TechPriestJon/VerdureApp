Feature: EfcMeal
	As a user
	In order to group food into I meal
	I need to store data about meal

@meal
Scenario: Create Meal
	Given a user to create the Meal with
	And I have a Meal to create
	When I Save the Meal 
	Then my Meal is persisted in the database


@meal fooditem
Scenario: Add FoodItems to Meal
	Given I have a FoodItem persisted in the database
	And I have a Meal persisted in the database
	When I add the FoodItem to the Meal and Save
	Then my Meal is persisted in the database with the FoodItem


@meal fooditem
Scenario: Remove FoodItems from Meal
	Given I have a FoodItem persisted in the database
	And I have a Meal with a FoodItem persisted in the database
	When I remove the FoodItem to the Meal and Save
	Then my Meal is persisted in the database without the FoodItem

@meal
Scenario: Delete Meal
	Given I have a FoodItem persisted in the database	
	And I have a Meal with a FoodItem persisted in the database
	When I delete the Meal
	Then my Meal is deleted
	And the FoodItem is still persisted without meal
