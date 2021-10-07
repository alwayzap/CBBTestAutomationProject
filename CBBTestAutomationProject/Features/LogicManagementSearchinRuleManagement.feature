Feature: LogicManagementSearchinRuleManagement

@US2920424
Scenario: Logic Management Search for groups of Data Pointers
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I click on the Rule Management button in the Home page
	And I select one of the options from the displayed dropdowns
	Then Standard Logic Management page is displayed
	And Logic Management records are displayed based on the Selection
	And Option to Edit, Clone, View, and Deactivate are displayed for each record