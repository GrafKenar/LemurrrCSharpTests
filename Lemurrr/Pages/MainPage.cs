using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baucenter;
using OpenQA.Selenium.Interactions;

namespace Baucenter.Pages
{
    public class MainPage : BasePage
    {
        private readonly IWebDriver? _driver;

        public MainPage(IWebDriver driver)
            : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How.Id, "topmenu-btn")]
        public IWebElement catalogButton { get; set; }

        //[FindsBy(How.Id, "anElementName", Priority = 0)]
        //[FindsBy(How.CssSelector, "ul > li", Priority = 1)]
        //public IList<IWebElement> sectionButtons { get; set; }

        [FindsBy(How.CssSelector, "#topmenu > ul > li")]
        public IList<IWebElement> sectionButtons { get; set; }

        [FindsBy(How.CssSelector, ".hover > div > ul > li > ul > li > a")]
        public IList<IWebElement?> subSectionButtons { get; set; }

        public ListOfProductsPage goToRandomProgductSection()
        {
            catalogButton.Click();
            Actions action = new Actions(_driver);
            List<IWebElement> elements = sectionButtons.ToList();
            IWebElement sectionsMenuItem = randomElement(elements.GetRange(0, 5));
            action.MoveToElement(sectionsMenuItem).Perform();
            randomElement(subSectionButtons).Click();

            return new ListOfProductsPage(_driver);
        }

        public ListOfPromotionsPage GoToPromotionsPage()
        {
            catalogButton.Click();
            sectionButtons.SelectElement("Акции").Click();

            return new ListOfPromotionsPage(_driver);
        }

        public ListOfProductsPage GoToAllProductsPage()
        {
            catalogButton.Click();
            sectionButtons.SelectElement("Все товары").Click();

            return new ListOfProductsPage(_driver);
        }
    }
}
