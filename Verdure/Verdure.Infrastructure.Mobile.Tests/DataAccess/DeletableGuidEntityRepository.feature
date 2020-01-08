Feature: DeletableGuidEntityRepository

@repos
Scenario: Create DeletableGuidEntity
	Given I have a DeletableGuidEntity
	When I create the DeletableGuidEntity
	Then the DeletableGuidEntity is stored in the database

@repos
Scenario: Get DeletableGuidEntity
	Given I have a DeletableGuidEntity persisted
	When I get the DeletableGuidEntity based on id
	Then the DeletableGuidEntity is returned

@repos
Scenario: Get List Of DeletableGuidEntity
	Given I have two DeletableGuidEntity persisted
	When I get the DeletableGuidEntities
	Then both DeletableGuidEntities are returned

#@repos
#Scenario: Update DeletableGuidEntity
#	Given I have a DeletableGuidEntity persisted
#	When I get the DeletableGuidEntity based on id
#	And I update the DeletableGuidEntity 
#	Then the DeletableGuidEntity is updated

@repos
Scenario: Delete DeletableGuidEntity
	Given I have a DeletableGuidEntity persisted
	When I delete the DeletableGuidEntity based on id
	Then the DeletableGuidEntity is deleted

