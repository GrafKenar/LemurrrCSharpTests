using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Baucenter.Pages
{
    public class ProductPage : BasePage
    {
        private readonly IWebDriver? _driver;

        private readonly string _title;

        private readonly string _price;

        public ProductPage(IWebDriver driver, string title, string price)
           : base(driver)
        {
            _driver = driver;
            _title = title;
            _price = price;

            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How.Id, "addToCartButton")]
        IWebElement addProductToCartButton { get; set; }

        [FindsBy(How.CssSelector, ".basket__lnk")]
        IWebElement cartDropdownButton { get; set; }

        [FindsBy(How.CssSelector, ".basket__total .btn")]
        IWebElement cartButton { get; set; }

        public CartPage addProductToCartAndGoToCart()
        {
            _driver.ExecuteJavaScript("$('[class=\"city-confirmation__modal\"]').remove()");
            wait(addProductToCartButton).Click();
            cartDropdownButton.Click();
            cartButton.Click();

            return new CartPage(_driver, _title, _price);
        }
    }
}
