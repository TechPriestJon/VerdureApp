Feature: GuidEntityRepository

@repos
Scenario: Create GuidEntity
	Given I have a GuidEntity
	When I create the GuidEntity
	Then the GuidEntity is stored in the database

@repos
Scenario: Get GuidEntity
	Given I have a GuidEntity persisted
	When I get the GuidEntity based on id
	Then the GuidEntity is returned

@repos
Scenario: Get List Of GuidEntity
	Given I have two GuidEntity persisted
	When I get the GuidEntities
	Then both GuidEntities are returned

#@repos
#Scenario: Update GuidEntity
#	Given I have a GuidEntity persisted
#	When I get the GuidEntity based on id
#	And I update the GuidEntity 
#	Then the GuidEntity is updated

#@repos
#Scenario: Delete GuidEntity
#	Given I have a GuidEntity persisted
#	When I delete the GuidEntity based on id
#	Then the GuidEntity is deleted

