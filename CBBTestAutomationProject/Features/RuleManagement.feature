Feature: RuleManagement
	
@US2920429
Scenario: Create, and Edit Rules for Datapointers
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I Edit a Logic Management Record
	Then I can Add a Rule for an Existing Data Pointer
	And I can Edit an Existing Rule for Data Pointer