using System;
using OpenQA.Selenium;
using BoDi;
using SpecflowTestAutomation.BrowserFactories;

namespace SpecflowTestAutomation.SetUp
{
    internal class Context
    {
        ChromeBrowser _chromeBrowser;
        FirefoxBrowser _firefoxBrowser;
        IEBrowser _iEBrowser;
        private readonly IObjectContainer objectContainer;
        private IWebDriver driver;
        string baseUrl = EnvironmentData.baseUrl;
        string browser = EnvironmentData.browser;

        public Context(IObjectContainer objectContainer
                      , ChromeBrowser chromeBrowser
                      , FirefoxBrowser firefoxBrowser
                      , IEBrowser iEBrowser)
        {
            this.objectContainer = objectContainer;
            _firefoxBrowser = firefoxBrowser;
            _chromeBrowser = chromeBrowser;
            _iEBrowser = iEBrowser;
        }

        public void LoadRateCalculatorApplication()
        {
            switch (browser.ToLower())
            {
                case "firefox":
                    driver = _firefoxBrowser.Create(objectContainer);
                    break;

                case "chrome":
                    driver = _chromeBrowser.Create(objectContainer);
                    break;

                case "ie":
                    driver = _iEBrowser.Create(objectContainer);
                    break;

                default:
                    driver = _chromeBrowser.Create(objectContainer);
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Navigate().GoToUrl(baseUrl);
        }

        public void ShutDownRateCalculatorApplication()
        {
            driver?.Quit();
        }

        public void TakeScreenshotAtThePointOfTestFailure(string directory, string scenarioName)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = directory + scenarioName + DateTime.Now.ToString("yyyy-MM-dd") + ".png";
            string Screenshot = screenshot.AsBase64EncodedString;
            byte[] screenshotAsByteArray = screenshot.AsByteArray;
            // screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            screenshot.SaveAsFile(string.Format(path + "{0}.png"));
        }
    }
}
