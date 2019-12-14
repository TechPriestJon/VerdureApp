Feature: VerdureModifyableEntityTests
	As a user
	In order to know when an object is modified
	I need to see a modified date

@baseentity
Scenario: Entity initialises successfully
	Given I have a modifyable entity
	When create the modifyableentity
	Then modifyableentity is initialised with the creation date
	Then modifyableentity is initialised with the modification date

@baseentity
Scenario: Entity modifies successfully
	Given I have a modifyable entity
	When create the modifyableentity
	And modify the modifyableentity
	Then modifyableentity is modified with the modification date