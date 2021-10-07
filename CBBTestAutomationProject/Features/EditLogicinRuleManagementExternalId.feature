Feature: EditLogicinRuleManagementExternalId
	
@US3329631
Scenario: Change Logic in Rules for Data Pointers in External Id
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I Edit an Existing Rule for Data Pointer in the External Id tab
	Then I can be able to Change Logic for fields in the External Id modal
	And Save the Data Pointer Rule in External Id tab