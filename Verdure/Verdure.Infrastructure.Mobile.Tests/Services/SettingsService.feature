Feature: SettingsService

@service settings
Scenario: Set User
	Given I have a user
	When I set the user in the service
	Then the user is set in the service

@service settings
Scenario: Get User
	Given a user has been set
	When I get the user
	Then the user is returned