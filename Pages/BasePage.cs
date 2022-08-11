using AppiumSpecflow.Configuration;
using AppiumSpecflow.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSpecflow.Pages
{
    public class BasePage
    {

        protected readonly AppiumDriver<IWebElement> Driver;
        protected readonly string PlatformName;

        public BasePage(DriverProvider driverProvider, ConfigurationProvider configurationProvider)
        {
            Driver = driverProvider.GetDriver();
            PlatformName = configurationProvider.GetSettings().PlatformName;
        }
        
    }
}
