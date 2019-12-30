Feature: SnackTests
    As a user
	In order to find my previous data
	I need to have a record

@snack
Scenario: Create Snack
	Given I have eaten a snack
	And I create my user record for my snack
	When I create a snack
	Then my snack is created
	And my snack has my user attached

@snack
Scenario: Create 2 Snacks
	Given I have eaten a snack
	And another snack
	And I create my user record for my snack
	When I create a snack
	And create another snack
	Then my snacks are created
	And my snack has my user attached

@fooditem snack
Scenario: Attach Food Item to Snack
	Given I have eaten a snack
	And I create my user record for my snack
	And I have a food item for my snack
	When I create a snack
	And I add the food item to my snack
	Then my snack is created
	And my snack has my user attached
	And my snack has the food items attached

@fooditem snack
Scenario: Attach 1 Food Items to Snack and 1 other Food Items to another Snack
	Given I have eaten a snack
	And I create my user record for my snack
	And I have a food item for my snack
	And another snack
	And I have another food item for my second snack
	When I create a snack
	And create another snack	
	And I add the food item to my snack
	And I add the food item to my other snack
	Then my snacks are created
	And my snack has my user attached
	And my snacks have the correct food items