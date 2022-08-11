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
    public class MainPage : BasePage
    {
        public MainPage(DriverProvider driverProvider, ConfigurationProvider configurationProvider) : base(driverProvider, configurationProvider) { }

        public IWebElement MainDisplay => Driver.FindElement(MobileBy.Id("com.google.android.calculator:id/display"));

        protected IWebElement Result => Driver.FindElement(MobileBy.Id("com.google.android.calculator:id/result_final"));

        public void SelectAdd() => Driver.FindElement(MobileBy.Id("com.google.android.calculator:id/op_add")).Click();
        public void Calculate() => Driver.FindElement(MobileBy.Id("com.google.android.calculator:id/eq")).Click();
        public void SelectNumber(int num) => Driver.FindElement(MobileBy.Id($"com.google.android.calculator:id/digit_{num}")).Click();

        public string GetResult() => Result.GetAttribute("text");




    }
}
