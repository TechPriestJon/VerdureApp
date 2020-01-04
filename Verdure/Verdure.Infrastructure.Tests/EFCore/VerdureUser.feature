Feature: VerdureUser
	As a user
	In order to store data about food I eat
	I want to have a store of the user

@User
Scenario: Create User
	Given I have a User to create
	When I Save the User
	Then my User is persisted in the database

@User
Scenario: Delete User
	Given I have a User persisted in the database
	When I delete the User
	Then my User is deleted