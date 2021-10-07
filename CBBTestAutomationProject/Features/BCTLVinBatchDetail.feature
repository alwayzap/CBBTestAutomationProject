Feature: BCTLVinBatchDetail
	
@US2920323
@US2920328
Scenario: Generate BCTLV and See the BCTLV details in Batch Detail page
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I performed Plan Search
	And results are returned from search
	And I’ve checked the checkbox next to a Medical Plan
	And I’ve clicked the Generate BCTLV button
	Then the BCTLV Generation Service should transform the plans Standard Plan Data from DBS into the BCTLV Data Structure
	And the plan(s) should be added to the batch processing queue
	And I should see the corresponding batch on the Batch Detail page
	And I when I click on the View button I should see the digital version of the BCTLV