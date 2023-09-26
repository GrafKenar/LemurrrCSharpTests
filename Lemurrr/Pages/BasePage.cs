using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baucenter.Pages
{
    public class BasePage
    {
        private readonly IWebDriver? _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement randomElement(IList<IWebElement> elements)
        {
            Random rnd = new();
            int randomIndex = rnd.Next(elements.Count);

            return elements[randomIndex];
        }

        public IWebElement randomElementList(List<IWebElement> elements)
        {
            Random rnd = new();
            int randomIndex = rnd.Next(elements.Count);

            return elements[randomIndex];
        }

        public IWebElement findChildElement(IWebElement parent, By childLocator)
        {
            IWebElement child = parent.FindElement(childLocator);

            return child;
        }

        public IWebElement wait(IWebElement element, int timeout = 5) {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));

            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public IList<IWebElement> wait(IList<IWebElement> element, int timeout = 15)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));

            return wait.Until(AdditionalMethods.VisibilityOfAllElementsLocated(element));
        }
    }
}
