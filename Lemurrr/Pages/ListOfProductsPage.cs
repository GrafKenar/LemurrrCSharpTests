using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

        [FindsBy(How.CssSelector, ".info .total")]
        public IWebElement totalAmountOfProducts { get; set; }


        [FindsBy(How.CssSelector, ".css-loader")]
        public IWebElement loader { get; set; }


        [FindsBy(How.CssSelector, ".catalog__entry.catalog__entry_thumb")]
        public IList<IWebElement> productCards { get; set; }


        [FindsBy(How.CssSelector, "[data-type=\"ProductCategory\"] .menu__entry ")]
        public IList<IWebElement> filterCheckboxes { get; set; }


        [FindsBy(How.ClassName, "actions__subtitle")]
        public IWebElement promotionPageTitle { get; set; }


        public By productPriceValue = By.ClassName("price__current");

        public By productNameValue = By.CssSelector(".catalog__entry >.entry__title");


        public ListOfProductsPage selectRandomFilterAndCheckAmountOfProducts()
        {
            IWebElement randomFilter = randomElement(filterCheckboxes);
            string amountOfProducts = randomFilter.GetAttribute("data-items");
            randomFilter.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            WebDriverWait wait2 = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(AdditionalMethods.ElementIsVisible(loader));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            wait2.Until(AdditionalMethods.InvisibilityOfElementLocated(loader));

            Assert.AreEqual(amountOfProducts, totalAmountOfProducts.Text);

            return this;
        }

        public ProductPage selectRandomProduct()
        {
            IWebElement randomProductCard = randomElement(productCards);

            string name = findChildElement(randomProductCard, productNameValue).Text;
            string price = findChildElement(randomProductCard, productPriceValue).Text;

            randomProductCard.Click();

            return new ProductPage(_driver, name, price);
        }

        public ListOfProductsPage CheckThatThereAreProductsInPromotion()
        {
            Assert.IsNotNull(productCards);
            Assert.AreEqual("ТОВАРЫ, КОТОРЫЕ УЧАСТВУЮТ В АКЦИИ", promotionPageTitle.Text);

            return this;
        }



    }
}
