using Baucenter.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baucenter
{
    internal class Test : BaseTest
    {
        [Test]
        public void AddRandomProductToTheCart()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.goToRandomProgductSection()
                .selectRandomProduct()
                .addProductToCartAndGoToCart()
                .checkThatCorrectProductInCart();
        }

        [Test]
        public void CheckAction()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.GoToPromotionsPage()
                .goToRandomPromotionPage()
                .CheckThatThereAreProductsInPromotion();
        }

        [Test]
        public void Filters()
        {
            MainPage mainPage = new MainPage(_driver);
            mainPage.GoToAllProductsPage()
                .selectRandomFilterAndCheckAmountOfProducts();
        }
    }
}
