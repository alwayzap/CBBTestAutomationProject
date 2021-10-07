Feature: BCTLVExportandView
	
@US2865729
Scenario: View BCTLV Data for a Record
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I performed a Plan Search
	And results are returned from the search
	And I have clicked on View menu
	And I selected the BCTLV - Digital drop down
	Then a new window should open with the BCTLV Data for the given cirrusPlanID should be displayed in an Handsontable table


@US2866158
Scenario: Export BCTLV Data into Excel for a Record
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I performed a Plan Search
	And results are returned from the search
	And I have clicked on View menu
	And I selected the BCTLV Data - Excel drop down
	Then a new window should open with the BCTLV Data for the given cirrusPlanID should be displayed in an Excel document