Feature: BCTLVGeneration

@US2865735
@US2920102
Scenario: BCTLV Generation from Standard Search
	Given that I am Cirrus Configuration Analyst
	And I have successfully authenticated into CBB web app
	When I performed Plan Search
	And results are returned from search
	And I’ve checked the checkbox next to a Medical Plan
	And I’ve clicked the Generate BCTLV button
	Then the BCTLV Generation Service should transform the plans Standard Plan Data from DBS into the BCTLV Data Structure