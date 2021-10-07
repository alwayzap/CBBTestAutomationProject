Feature: Basic and Advanced Search in BCTLV Generation Page

@US2865717
Scenario: Basic Search
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I enter a Valid Plan Code on the Standard Search tab
	And I click Search
	And a result is found in the DBS database
	Then a table should display with the plans that match the DBS ID entered
@US2865717
Scenario: Advanced Search
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I enter a Valid DBS ID, Group Number, or Created By on the Advanced Search tab
	And I click Search
	And a result is found in the DBS database
	Then a table should display with the plans that match the DBS ID entered
@US2865717
Scenario: No Results found in Basic Search
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I enter an Invalid Plan Code on the Standard Search tab
	And I click Search
	And a result is NOT found in the DBS database
	Then a table should display with a message stating “No Results Returned.”
@US2865717
Scenario: No Results found in Advanced Search
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I enter an Invalid DBS ID, Group Number, or Created By on the Advanced Search tab
	And I click Search
	And a result is NOT found in the DBS database
	Then a table should display with a message stating “No Results Returned.”
