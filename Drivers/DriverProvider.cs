using AppiumSpecflow.Configuration;
using AppiumSpecflow.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace AppiumSpecflow.Drivers
{
    public class DriverProvider
    {
        private AppiumDriver<IWebElement> _driver;
        private readonly AppSettings _appSettings;


        private static Dictionary<string, Func<Uri, AppiumOptions, AppiumDriver<IWebElement>>> DriverCollection =
            new Dictionary<string, Func<Uri, AppiumOptions, AppiumDriver<IWebElement>>>()
            {
                { 
                    MobilePlatform.IOS, (remoteAddress, options) => 
                        new IOSDriver<IWebElement>(remoteAddress, options, TimeSpan.FromSeconds(90))
                },

                { 
                    MobilePlatform.Android, (remoteAddress, options) => 
                        new AndroidDriver<IWebElement>(remoteAddress, options, TimeSpan.FromSeconds(90))
                },
            };
        public DriverProvider(ConfigurationProvider configurationProvider)
        {
            _appSettings = configurationProvider.GetSettings();

        }

        private AppiumOptions GetOptions()
        {
            var options = new AppiumOptions();
          

            //options.AddAdditionalCapability(MobileCapabilityType.PlatformName, _appSettings.PlatformName);
            //options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, _appSettings.PlatformVersion);
            ////options.AddAdditionalCapability(MobileCapabilityType.DeviceName, _appSettings.DeviceName);
            ////options.AddAdditionalCapability(MobileCapabilityType.Udid, _appSettings.DeviceName);
            ////options.AddAdditionalCapability("appPackage", _appSettings.AppPackage); 
            ////options.AddAdditionalCapability("appActivity", _appSettings.AppActivity);
            //options.AddAdditionalCapability(MobileCapabilityType.AutomationName, _appSettings.AutomationName);

            options.AddAdditionalCapability("platformName", "Android");
            options.AddAdditionalCapability("appium:deviceName", "Android GoogleAPI Emulator");
            options.AddAdditionalCapability("appium:deviceOrientation", "portrait");
            options.AddAdditionalCapability("appium:platformVersion", "12.0");
            options.AddAdditionalCapability("appium:app", "storage:filename=GlobalTickets.apk");

            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("build", "1");
            sauceOptions.Add("name", "GlobalTickets.UITests");
            options.AddAdditionalCapability("sauce:options", sauceOptions);

            return options;
        }

        public AppiumDriver<IWebElement> GetDriver()
        {
            if(_driver != null)
                return _driver;

            var uri = new Uri($"https://{_appSettings.UserName}:{_appSettings.AccessKey}@ondemand.us-west-1.saucelabs.com:443/wd/hub");
            _driver = DriverCollection[_appSettings.PlatformName].Invoke(uri, GetOptions());
            return _driver;
        }
    }
}
