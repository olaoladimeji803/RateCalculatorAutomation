using BoDi;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowTestAutomation.BrowserFactories
{
    public class IEBrowser
    {
        private readonly IObjectContainer objectContainer;
        public string IEDriverPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        public IEBrowser(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        public IWebDriver Create(IObjectContainer objectContainer)
        {
            IWebDriver driver;
            var options = new InternetExplorerOptions { IgnoreZoomLevel = true };
            driver = new InternetExplorerDriver(IEDriverPath, options, TimeSpan.FromSeconds(60));
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
            return driver;
        }
    }
}
