Feature: VerdureCreatableEntityTests
    As a user
	In order to know when an object is created
	I need to see a creation date

@baseentity
Scenario: Entity initialises successfully
	Given I have a creatable entity
	When create the creatableentity
	Then creatableentity is initialised with the creation date
