using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NonSpecflowWithNunitTemplate
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();
        Double expectedRate = 20000.00;
        Double expectedNaira2Pounds = 10.00;


        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://main--exchange-rate-calculator-2024.netlify.app/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void VerifyNairaToPoundsConversion()
        {
            IWebElement ngnField = driver.FindElement(By.CssSelector(".to-currency.m-top-2.p-1"));
            ngnField.Clear();
            ngnField.SendKeys("20000");
            Thread.Sleep(2000);

            IWebElement gbpField = driver.FindElement(By.CssSelector(".from-currency.p-1"));

            Double gbpValue = Double.Parse(gbpField.GetAttribute("value"));
            Thread.Sleep(8000);

            // // assertion
           // Assert.That(gbpValue, Is.EqualTo(expectedNaira2Pounds));
            Assert.That(gbpValue.Equals(expectedNaira2Pounds));
        }

        [Test]
        public void VerifyInvalidNairaToPoundsConversion()
        {
            IWebElement gbpField = driver.FindElement(By.CssSelector(".from-currency.p-1"));
            gbpField.Clear();
            gbpField.SendKeys("10");
            Thread.Sleep(2000);

            IWebElement ngnField = driver.FindElement(By.CssSelector(".to-currency.m-top-2.p-1"));
            Double ngnValue = Double.Parse(ngnField.GetAttribute("value"));
            Thread.Sleep(8000);

            // // assertion
            Assert.That(expectedRate, Is.EqualTo(ngnValue));
        }

        [Test]
        public void VerifyPoundsToNairaConversion()
        {
            IWebElement gbpField = driver.FindElement(By.CssSelector(".from-currency.p-1"));
            gbpField.Clear();
            gbpField.SendKeys("10");
            Thread.Sleep(4000);

            IWebElement ngnField = driver.FindElement(By.CssSelector(".to-currency.m-top-2.p-1"));
            Double ngnValue = Double.Parse(ngnField.GetAttribute("value"));
            Thread.Sleep(4000);

            // // assertion
           // Assert.That(expectedRate, Is.EqualTo(ngnValue));
            Assert.That(ngnValue.Equals(expectedRate));
        }

        [Test]
        public void VerifyInvalidPoundsToNairaConversion()
        {
            IWebElement gbpField = driver.FindElement(By.CssSelector(".from-currency.p-1"));
            gbpField.Clear();
            gbpField.SendKeys("10");
            Thread.Sleep(2000);

            IWebElement ngnField = driver.FindElement(By.CssSelector(".to-currency.m-top-2.p-1"));
            Double ngnValue = Double.Parse(ngnField.GetAttribute("value"));
            Thread.Sleep(8000);

            // // assertion
            Assert.That(expectedRate, Is.EqualTo(ngnValue));
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }

    }
}