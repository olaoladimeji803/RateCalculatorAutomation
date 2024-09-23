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

Scenario: 03_Verify Naira To Pounds Conversion is successful
    Given that exchange rate for rate calculator is set as shown below
	| rate | fromCurrency | toCurrency |
	| 2100 | gbp          | ngn        |
	And that a user load the rate calulation application 
	When a user input 5 into GBP text field
	Then a user sees 10500.00 value in NGN text field
	When a user clicks on Send Now button
	And a user selects Union Bank as the bank option
	 And a user inputs 1234567891 as the account number
	And a user clicks on Send button
	Then the text Transaction successful! message should appear

Scenario: 04_Verify Invalid Pounds To Naira Conversion is unsuccessful

Scenario: 05_Verify Invalid Naira To Pounds Conversion is unsuccessful

	

	
