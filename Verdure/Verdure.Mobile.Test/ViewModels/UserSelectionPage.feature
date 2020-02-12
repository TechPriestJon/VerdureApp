Feature: UserSelectionPage
	As a user
	I want a screen to select my user
	So I can use the system as that user

@UserSelectionPage ViewModel
Scenario: Load UserSelectionPage ViewModel
	Given I have the UserSelectionPage ViewModel
	When UserSelectionPage is loaded
	Then All users are avaliable

@UserSelectionPage ViewModel
Scenario: Navigate from UserSelectionPage to UserCreationPage
	Given I have the UserSelectionPage ViewModel and a function to navigate
	When I press the navigate button
	Then I navigate from the UserSelectionPage to the UserCreationPage