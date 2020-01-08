Feature: DeletableIdEntityRepository

@repos
Scenario: Create DeletableIdEntity
	Given I have a DeletableIdEntity
	When I create the DeletableIdEntity
	Then the DeletableIdEntity is stored in the database

@repos
Scenario: Get DeletableIdEntity
	Given I have a DeletableIdEntity persisted
	When I get the DeletableIdEntity based on id
	Then the DeletableIdEntity is returned

@repos
Scenario: Get List Of DeletableIdEntity
	Given I have two DeletableIdEntity persisted
	When I get the DeletableIdEntities
	Then both DeletableIdEntities are returned

#@repos
#Scenario: Update DeletableIdEntity
#	Given I have a DeletableIdEntity persisted
#	When I get the DeletableIdEntity based on id
#	And I update the DeletableIdEntity 
#	Then the DeletableIdEntity is updated

@repos
Scenario: Delete DeletableIdEntity
	Given I have a DeletableIdEntity persisted
	When I delete the DeletableIdEntity based on id
	Then the DeletableIdEntity is deleted


