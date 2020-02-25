Feature: SettingsPage
	As a user
	I need a page to edit settings
	So I can edit my settings within the app

@SettingsPage ViewModel
Scenario: Load SettingsPage ViewModel
	Given I have the SettingsPage ViewModel
	When SettingsPage is loaded
	Then the SettingsPage is loaded successfully

@SettingsPage ViewModel
Scenario: Navigate from SettingsPage to UserSelectionPage
	Given I have the SettingsPage ViewModel and a function to navigate
	When I press the UserSelectionPage navigate button 
	Then I navigate from the SettingsPage to the UserSelectionPage

@SettingsPage ViewModel
Scenario: Navigate from SettingsPage to UserCreationPage
	Given I have the SettingsPage ViewModel and details for a user
	When I update the user details
	And press save on the SettingsPage
	Then user details are updated