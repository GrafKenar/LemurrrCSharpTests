using Baucenter.Infrastructure;
using Baucenter.Infrastructure.Wrappers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq.Expressions;

namespace Baucenter
{
    public class BaseTest
    {
        public IWebDriver _driver;
        public IAppSettings _appSettings;


        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache"); // to disable cache
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            _appSettings = new AppSettings();
            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl(_appSettings.GetBaseUri());
            _driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void QuitBrowser()
        {
            _driver.Quit();
        }
    }
}