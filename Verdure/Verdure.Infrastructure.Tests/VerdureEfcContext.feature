Feature: VerdureEfcContext
	As a user
	To store data when my app is closed
	I need a persistant store of data

@mytag
Scenario: Test Context
	Given I have an inmemory database context
	When load it into memory
	Then the context generates the model correctly
