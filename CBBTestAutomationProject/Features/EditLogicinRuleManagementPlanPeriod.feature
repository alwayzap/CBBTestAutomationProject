Feature: EditLogicinRuleManagementPlanPeriod
	
@US3165109
Scenario: Change Logic in Rules for Data Pointers in Plan Period
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I Edit an Existing Rule for Data Pointer in the Plan Period tab
	Then I can be able to Change Logic in the modal
	And Save the Data Pointer Rule in Plan Period tab