Feature: Manage Benefits page

@US2870908
Scenario: Mapping records in Manage Benefits page
	
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I’m on the CBBManageBenefits page
	Then I should be able to see a table with all the Benefit Categories for the COC Series, Organization, State and Segment selected
	And I should be able select one or more Benefit Codes to map back to the Benefit Categories displayed
	And once I click the save button the mapping should be saved to the database for future reference