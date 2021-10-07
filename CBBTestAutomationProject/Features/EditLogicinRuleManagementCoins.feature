Feature: EditLogicinRuleManagementCoins
	
@US3653501
Scenario: Change Logic in Rules for Data Pointers in Coinsurance
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I Edit an Existing Rule for Data Pointer in the Coins tab
	Then I can be able to Change Logic for fields in the Coins modal
	And Save the Data Pointer Rule in Coins tab