using AppiumSpecflow.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TechTalk.SpecFlow;

namespace AppiumSpecflow.Hooks
{
    [Binding]
    public sealed class Hooks1
    {

        private readonly AppiumDriver<IWebElement> _driver;

        public Hooks1(DriverProvider driver)
        {
            _driver = driver.GetDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}