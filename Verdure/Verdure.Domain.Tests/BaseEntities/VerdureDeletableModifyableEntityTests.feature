Feature: VerdureDeletableAssignModEntityTests
    As a user
	In order to know who created an object
	I need to see user id for an object

@baseentity
Scenario: Entity initialises successfully
	Given I have a deletable entity
	When create the deletableentity
	Then deletableentity defaults to not being deleted

@baseentity
Scenario: Entity deletes successfully
	Given I have a deletable entity
	And it is created
	When I when I delete it
	Then the deletableentity is deleted
