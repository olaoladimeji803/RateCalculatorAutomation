using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();
Double expectedRate = 10000.00;

// driver.Navigate().GoToUrl("http://127.0.0.1:5500/FrontEnd/index.html");
driver.Navigate().GoToUrl("https://main--exchange-rate-calculator-2024.netlify.app/");
driver.Manage().Window.Maximize();
Thread.Sleep(2000);

IWebElement gbpField = driver.FindElement(By.CssSelector(".from-currency.p-1"));
gbpField.Clear();
gbpField.SendKeys("5");
Thread.Sleep(2000);

IWebElement ngnField = driver.FindElement(By.CssSelector(".to-currency.m-top-2.p-1"));
Double ngnValue = Double.Parse(ngnField.GetAttribute("value"));
Thread.Sleep(8000);

// // assertion
Assert.Equals(expectedRate, ngnValue);


//driver.Quit();

