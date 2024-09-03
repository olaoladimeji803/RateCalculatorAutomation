using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecflowTestAutomation.SetUp;

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


        //Methods and Function
        public void InputGBPCurrency(string GBPCurrency) 
        {
            Thread.Sleep(2000);
            _driver.ClearAndSendKeys(gbpField, GBPCurrency);
            _driver.SendKeys(gbpField, Keys.Tab);
        }

        public void InputNGNCurrency(string NGNCurrency)
        {
            _driver.ClearAndSendKeys(ngnField, NGNCurrency);
            _driver.SendKeys(ngnField, Keys.Tab);
        }

        public string ReturnNGNCurrency()
        {
            return _driver.FindElement(ngnField).GetAttribute("value");
        }

        public string ReturnGBPCurrency()
        {
            return _driver.FindElement(gbpField).GetAttribute("value");
        }
    }   
}
