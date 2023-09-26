using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baucenter.Pages
{
    public class ListOfPromotionsPage : BasePage
    {
        private readonly IWebDriver? _driver;

        public ListOfPromotionsPage(IWebDriver driver)
           : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How.CssSelector, ".actions__entry")]
        public IList<IWebElement> promotionCards { get; set; }


        public ListOfProductsPage goToRandomPromotionPage()
        {
            randomElement(promotionCards).Click();

            return new ListOfProductsPage(_driver);
        }
    }
}
