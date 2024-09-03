Feature: RateCalculator

@tag1
Scenario: 01_Verify Pounds To Naira Conversion is successful
	Given that a user load the rate calulation application 
	When a user input 44 into GBP text field
	Then a user sees 88000.00 value in NGN text field

Scenario: 02_Verify Naira To Pounds Conversion is successful
	Given that a user load the rate calulation application 
	When a user input 88000 into NGN text field
	Then a user sees 44.00 value in GBP text field

Scenario: 03_Verify Invalid Pounds To Naira Conversion is unsuccessful

Scenario: 04_Verify Invalid Naira To Pounds Conversion is unsuccessful
	
