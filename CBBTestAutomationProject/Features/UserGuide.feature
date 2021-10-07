Feature: UserGuide
	
@US2920468
Scenario: Get into UserGuide from CBB Home page
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	And I'm on the Home page
	When I click on the User Guide button within the Resources card
	Then a new Window should open with the User Guide page displayed
