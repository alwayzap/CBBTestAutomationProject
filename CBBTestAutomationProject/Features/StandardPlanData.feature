Feature: Standard Plan Data

@US2865727
Scenario: View Standard Plan Data for a Record
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I have performed a Plan Search
	And results have returned from the search
	And I have clicked on the View menu
	And I selected the Standard Plan Data - Digital drop down
	Then a new window should open with the Standard Plan Data for the given digitalBenefitId should be displayed in an Handsontable table


@US2866145
Scenario: Export Standard Plan Data into Excel for a Record
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I have performed a Plan Search
	And results have returned from the search
	And I have clicked on the View menu
	And I selected the Standard Plan Data - Excel drop down
	Then a new window should open with the Standard Plan Data for the given planAssignmentID should be displayed in an Excel document