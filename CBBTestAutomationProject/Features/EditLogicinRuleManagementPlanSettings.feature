Feature: EditLogicinRuleManagementPlanSettings
	
@US3165117
Scenario: Change Logic in Rules for Data Pointers in Plan Settings
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I Edit an Existing Rule for Data Pointer in the Plan Settings tab
	Then I can be able to Change Logic in the settings modal
	And Save the Data Pointer Rule in Plan Settings tab