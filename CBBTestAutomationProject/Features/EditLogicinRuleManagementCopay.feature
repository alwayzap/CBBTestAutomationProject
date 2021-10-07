Feature: EditLogicinRuleManagementCopay
	
@US3630730
Scenario: Change Logic in Rules for Data Pointers in Copay
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I Edit an Existing Rule for Data Pointer in the Copay tab
	Then I can be able to Change Logic for fields in the Copay modal
	And Save the Data Pointer Rule in Copay tab