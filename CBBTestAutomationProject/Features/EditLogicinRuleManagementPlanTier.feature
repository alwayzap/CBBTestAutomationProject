Feature: EditLogicinRuleManagementPlanTier
	
@US3165125
Scenario: Change Logic in Rules for Data Pointers in Plan Tier
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I Edit an Existing Rule for Data Pointer in the Plan Tier tab
	Then I can be able to Change Logic for fields in the Tier modal
	And Save the Data Pointer Rule in Plan Tier tab