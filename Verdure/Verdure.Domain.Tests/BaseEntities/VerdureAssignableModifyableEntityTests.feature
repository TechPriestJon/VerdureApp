Feature: AssignableModifyableEntity
    As a user
	In order to know who created an object
	I need to see user id for an object

@baseentity
Scenario: Entity initialises successfully
	Given I have a assignable modifyable entity
	And I have a user to assign the entity to
	When create the assignablemodifyableentity
	Then assignablemodifyableentity is initialised with the created user id
	And assignablemodifyableentity is initialised with the creation date
	And assignablemodifyableentity is initialised with the modification date