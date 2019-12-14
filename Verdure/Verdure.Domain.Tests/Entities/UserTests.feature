Feature: User
    As a user
	In order to find my previous data
	I need to have a record

@user
Scenario: Create User
	Given I have a name for my user
	When I create my user record
	Then my user has my name and an id
	And my user has a creation date of today

@user
Scenario: Create Another User
	Given I have a name for my user
	And a name for another user
	When I create my user record
	And I create another user
	Then the user has a different name and id
	And my user and the other user have a creation date of today
