Feature: UserCreationPage
	As a user
	I want a screen to create my user
	So I can use the system as that user

@UserCreationPage ViewModel
Scenario: Load UserCreationPage ViewModel
	Given I have the UserCreationPage ViewModel
	When UserCreationPag is loaded
	Then I user can input details

@UserCreationPage ViewModel
Scenario: Save User in UserCreationPage ViewModel
	Given I have the UserCreationPage ViewModel and details for a user
	When I input the user details
	And I save the user
	Then the user is saved to the database