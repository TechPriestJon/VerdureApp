Feature: SnackCreationPage
	As a user
	I need a page to create snacks
	So I can track my snacks in a diary

@SnackCreation ViewModel
Scenario: Load SnackCreation ViewModel
	Given I have the SnackCreation ViewModel
	When SnackCreation is loaded
	Then the SnackCreation is loaded successfully

@SnackCreationPage ViewModel
Scenario: Save Snack in SnackCreationPage ViewModel
	Given I have the SnackCreationPage ViewModel and details for a Snack
	When I input the Snack details
	And I save the Snack
	Then the Snack is saved to the database