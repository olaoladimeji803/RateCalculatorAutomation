using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using SpecflowTestAutomation.Pages;
using SpecflowTestAutomation.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecflowTestAutomation.EndPoints;

namespace SpecflowTestAutomation.StepsDefinition
{
    [Binding]
    internal class RateCalculatorStepDefinitions
    {
        RateCalculator _rateCalculator;
        
        public RateCalculatorStepDefinitions(RateCalculator rateCalculator)
        {
            _rateCalculator = rateCalculator;
        }

        [When(@"a user input (.*) into GBP text field")]
        public void WhenAUserInputIntoGBPTextField(string GBPCurrency)
        {
            _rateCalculator.InputGBPCurrency(GBPCurrency);
        }

        [Then(@"a user sees (.*) value in NGN text field")]
        public void ThenAUserSeesValueInNGNTextField(Double expectedNGNCurrency)
        {
            var actualNGNCurrency = Double.Parse(_rateCalculator.ReturnNGNCurrency());
            Assert.That(expectedNGNCurrency, Is.EqualTo(actualNGNCurrency));
        }

        [When(@"a user input (.*) into NGN text field")]
        public void WhenAUserInputIntoNGNTextField(string NGNCurrency)
        {
            _rateCalculator.InputNGNCurrency(NGNCurrency);
        }

        [Then(@"a user sees (.*) value in GBP text field")]
        public void ThenAUserSeesValueInGBPTextField(Double expectedGBPCurrency)
        {
            var actualGBPCurrency = Double.Parse(_rateCalculator.ReturnGBPCurrency());
            Assert.That(expectedGBPCurrency, Is.EqualTo(actualGBPCurrency));
        }

        [When(@"a user clicks on Send Now button")]
        public void WhenAUserClicksOnSendNowButton()
        {
           _rateCalculator.ClicksOnSendNowButton();
        }

        [When(@"a user selects (.*) as the bank option")]
        public void WhenAUserSelectsUnionBankAsTheBankOption(string bankName)
        {
           _rateCalculator.SelectsBankOption(bankName);
        }

        [When(@"a user inputs (.*) as the account number")]
        public void WhenAUserInputsAsTheAccountNumber(string accountNumber)
        {
            _rateCalculator.InputsAccountNumber(accountNumber);
        }

        [When(@"a user clicks on Send button")]
        public void WhenAUserClicksOnSendButton()
        {
            _rateCalculator.ClicksOnSendButton();
        }

        [Then(@"the text (.*) message should appear")]
        public void ThenTheTextTransactionSuccessfulMessageShouldAppear(string expectedSuccessMessage)
        {
            Assert.That(expectedSuccessMessage.Equals(_rateCalculator.TransactionSuccessfulMessage()));
           
            // Option 1
            // string actualResult = _rateCalculator.ReturnSuccessMessage(expectedResult);
            // Assert.That(expectedSuccessMessage.Equals(actualResult), $"Expected message {expectedSuccessMessage} is not equal to actual message {actualResult}");
            ////Option 2
        }

        [Then(@"the error message contains enter a valid (.*) digit account number")]
        public void ThenTheErrorMessageContainsEnterAValidDigitAccountNumber(string errormessage )
        {
            Assert.That(_rateCalculator.DoesThePopupAppear());
        }

    }
}
