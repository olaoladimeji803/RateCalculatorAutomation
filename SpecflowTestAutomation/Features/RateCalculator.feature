Feature: RateCalculator

@tag1
Scenario: Verify Pounds To Naira Conversion is successful
	Given that a user load the rate calulation application 
	When a user input 44 into GBP text field
	Then a user sees 88000.00 value in NGN text field
	
