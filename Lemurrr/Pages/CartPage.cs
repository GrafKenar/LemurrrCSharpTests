using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baucenter.Pages
{
    public class CartPage : BasePage
    {
        private readonly IWebDriver? _driver;

        private readonly string _title;

        private readonly string _price;

        public CartPage(IWebDriver driver, string title, string price)
             : base(driver)
        {
            _driver = driver;
            _title = title;
            _price = price;

            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How.CssSelector, ".result__price")]
        public IWebElement totalPriceValue { get; set; }

        [FindsBy(How.CssSelector, ".entry__info>.entry__title")]
        public IWebElement productTitleValue { get; set; }

        public void checkThatCorrectProductInCart()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(_price, wait(totalPriceValue).Text);
            Assert.AreEqual(_title, wait(productTitleValue).Text.ToUpper());
        }
    }
}
