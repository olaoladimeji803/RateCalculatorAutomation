using NUnit.Framework;
using SpecflowTestAutomation.Pages;
using SpecflowTestAutomation.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

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
    }
}
