Feature: EditLogicinRuleManagementPlanHeader
	
@US2920435
Scenario: Change Logic in Rules for Data Pointers in Plan Header
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I Edit an Existing Rule for Data Pointer
	Then I can be able to Change Logic
	And Save the Data Pointer Rule