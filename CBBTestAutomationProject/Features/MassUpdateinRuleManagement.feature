Feature: MassUpdateinRuleManagement

@US2969011
Scenario: Mass Update Logic in Rules for Data Pointers
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I Edit an Existing Rule for Data Pointer and Change Logic
	And Mass Update by Selecting Multiple Rules
	Then Logic is Updated in Selected Rules