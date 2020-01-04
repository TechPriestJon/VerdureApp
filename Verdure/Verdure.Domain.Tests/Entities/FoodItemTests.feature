Feature: FoodItem
    As a user
	In order to know my calories in a food item
	I need to create a food item record

@fooditem
Scenario: Create Food Item
	Given I have eaten a food item with calories and name
	When I create a food item
	Then my food item has the same calories and name

@fooditem
Scenario: Delete Food Item
	Given I have a food item to be deleted
	When I delete the food item
	Then my food item is deleted