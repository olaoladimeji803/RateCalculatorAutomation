using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecflowTestAutomation.SetUp;
using TechTalk.SpecFlow;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;

namespace SpecflowTestAutomation.Pages
{
    internal class RateCalculator
    {
        IWebDriver _driver;
        public RateCalculator(IWebDriver driver)
        {
            _driver = driver;
        }

        // locators
        By gbpField = By.CssSelector(".from-currency.p-1");
        By ngnField = By.CssSelector(".to-currency.m-top-2.p-1");

        By sendNowBtn = By.CssSelector(".send-now.m-top-2");
        By bankNameField = By.CssSelector(".select-bank.p-1");
        By acctNoField = By.CssSelector(".account-number.p-1.m-top-2");
        By sendBtn = By.CssSelector(".send.m-top-2");
        By successMsgField = By.CssSelector(".success");

        By returnHomepageBtn = By.CssSelector(".home.m-top-2");


        //Methods and Function
        public void InputGBPCurrency(string GBPCurrency) 
        {
            Thread.Sleep(2000);
            _driver.ClearAndSendKeys(gbpField, GBPCurrency);
            _driver.SendKeys(gbpField, Keys.Tab);
        }

        public void InputNGNCurrency(string NGNCurrency)
        {
             Thread.Sleep(2000);
            _driver.ClearAndSendKeys(ngnField, NGNCurrency);
            _driver.SendKeys(ngnField, Keys.Tab);
        }

        public string ReturnNGNCurrency()
        {
            Thread.Sleep(1000);
            return _driver.FindElement(ngnField).GetAttribute("value");
        }

        public string ReturnGBPCurrency()
        {
            Thread.Sleep(1000);
            return _driver.FindElement(gbpField).GetAttribute("value");
        }

        public void ClicksOnSendNowButton()
        {
            Thread.Sleep(1000);
            _driver.FocusAndClick(sendNowBtn);
        }      

        public void SelectsBankOption(string bankName)
        {
            Thread.Sleep(1000);
            _driver.SelectOptionByText(bankNameField, bankName);
        }
        public void InputsAccountNumber(string accountNumber)
        {
            Thread.Sleep(1000);
            _driver.ClearAndSendKeys(acctNoField, accountNumber);
        }
        public void ClicksOnSendButton()
        {
            Thread.Sleep(1000);
            _driver.FocusAndClick(sendBtn);
        }
        public string TransactionSuccessfulMessage()
        {
            Thread.Sleep(1000);
            // return _driver.FindElement(sendBtn).GetAttribute("value");
            return _driver.FindElement(successMsgField).Text.Trim();
        }

        //option 3 of writing success message method (as above)
        public bool ReturnSuccessMessage(string expectedResult)
        {
            string actualResult = _driver.FindElement(successMsgField).Text.Trim();
            return actualResult.Equals(expectedResult);
        }

        public bool DoesThePopupAppear()
        {
            if (_driver.HandleAlert != null)
            {
                _driver.HandleAlert();
                return true;
            }
            return false;
        }
    }
}
