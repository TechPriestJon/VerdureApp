Feature: EfcSnack
	As a user
	In order to group food into I Snack
	I need to store data about Snack

@snack
Scenario: Create Snack
	Given I have a Snack to create
	And a user to create the Snack with
	When I Save the Snack 
	Then my Snack is persisted in the database


@snack fooditem
Scenario: Add FoodItem to Snack
	Given I have a FoodItem persisted in the database
	And I have a Snack persisted in the database
	When I add the FoodItem to the Snack and Save
	Then my Snack is persisted in the database with the FoodItem


@snack fooditem
Scenario: Update FoodItem to Snack
	Given I have a FoodItem persisted in the database
	And I have a Snack with a FoodItem persisted in the database
	When I update the FoodItem to the Snack and Save
	Then my Snack is persisted in the database with the new FoodItem

@snack
Scenario: Delete Snack
	Given I have a FoodItem persisted in the database	
	And I have a Snack with a FoodItem persisted in the database
	When I delete the Snack
	Then my Snack is deleted
	And the FoodItem is still persisted without snack


