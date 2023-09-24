using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baucenter.Pages
{
    public class ListOfProductsPage : BasePage
    {
        private readonly IWebDriver? _driver;

        public ListOfProductsPage(IWebDriver driver)
           : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How.CssSelector, ".catalog__entry.catalog__entry_thumb ")]
        public IList<IWebElement> productCards { get; set; }

        public By productPriceValue = By.ClassName("price__current");

        public By productNameValue = By.CssSelector(".catalog__entry >.entry__title");



        public ProductPage selectRandomProduct()
        {
            IWebElement randomProductCard = randomElement(productCards);

            string name = findChildElement(randomProductCard, productNameValue).Text;
            string price = findChildElement(randomProductCard, productPriceValue).Text;

            randomProductCard.Click();

            return new ProductPage(_driver, name, price);
        }
    }
}
