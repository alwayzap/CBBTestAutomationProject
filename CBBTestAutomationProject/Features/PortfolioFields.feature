Feature: PortfolioFields

@US2865724
Scenario: View Portfolio Fields for a Record
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I’ve performed a Plan Search
	And results returned from the search
	And I’ve clicked on the View menu
	And I selected the Portfolio Fields - Digital drop down
	Then a new window should open with the Portfolio Fields for the given planAssignmentID should be displayed in a Handsontable table


@US2866114
Scenario: Export Portfolio Fields into Excel for a Record
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I’ve performed a Plan Search
	And results returned from the search
	And I’ve clicked on the View menu
	And I selected the Portfolio Fields - Excel drop down
	Then a new window should open with the Portfolio Fields for the given planAssignmentID should be displayed in an Excel document