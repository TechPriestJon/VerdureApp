Feature: IdEntityRepository

@repos
Scenario: Create IdEntity
	Given I have a IdEntity
	When I create the IdEntity
	Then the IdEntity is stored in the database

@repos
Scenario: Get IdEntity
	Given I have a IdEntity persisted
	When I get the IdEntity based on id
	Then the IdEntity is returned

@repos
Scenario: Get List Of IdEntity
	Given I have two IdEntity persisted
	When I get the IdEntities
	Then both IdEntities are returned

#@repos
#Scenario: Update IdEntity
#	Given I have a IdEntity persisted
#	When I get the IdEntity based on id
#	And I update the IdEntity 
#	Then the IdEntity is updated

@repos
Scenario: Delete IdEntity
	Given I have a IdEntity persisted
	When I delete the IdEntity based on id
	Then the IdEntity is deleted


