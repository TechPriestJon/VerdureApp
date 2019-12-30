Feature: Meal
    As a user
	In order to record what I have eaten in a meal
	I need to have a record of my meal

@meal
Scenario: Create Meal
	Given I have eaten a meal
	And I create my user record for my meal
	When I create a meal
	Then my meal is created
	And my meal has my user attached

@meal
Scenario: Create 2 Meals
	Given I have eaten a meal
	And another meal
	And I create my user record for my meal
	When I create a meal
	And create another meal
	Then my meals are created
	And my meal has my user attached

@fooditem meal
Scenario: Attach Food Item to Meal
	Given I have eaten a meal
	And I create my user record for my meal
	And I have two food items for my meal
	When I create a meal
	And I add the food items to my meal
	Then my meal is created
	And my meal has my user attached
	And my meal has the food items attached

@fooditem meal
Scenario: Attach 2 Food Items to Meal and 1 other Food Items to another Meal
	Given I have eaten a meal
	And I create my user record for my meal
	And I have two food items for my meal
	And another meal
	And I have another food item for my second meal
	When I create a meal
	And create another meal	
	And I add the food items to my meal
	And I add the food items to my other meal
	Then my meals are created
	And my meal has my user attached
	And my meals have the correct food items