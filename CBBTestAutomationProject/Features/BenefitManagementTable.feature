Feature: Benefit Management Table

@US2865716
Scenario: Benefit Management Table

Given that I am Cirrus Configuration Analyst
And I have successfully authenticated into CBB web app
When I am on the CBBBenefitMgmt page
Then I should be able to see a table with all the groups of Benefit Categories by COC Series, Organization, State, and Segment pre-build in Plan Builder
And I should be able to filter the table by COC Series, Organization, State and Segment
And I should be able to click the edit button to open the CBBManageBenefit page for the selected COC Series, Organization, State, and Segment

@US2888121
Scenario: Deactivation checkbox

Given that I am Cirrus Configuration Analyst
And I have successfully authenticated into CBB web app
When I am on the CBBBenefitMgmt page
And I should be able to click the deactivate button for one of the records
And I should be able to select the Show Deactivated checkbox
Then I should see deactivated records
And I should be able to reactivate a deleted record
