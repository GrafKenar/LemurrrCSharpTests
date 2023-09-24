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
        public void Test1()
        {
            MainPage mainPage = new MainPage(base._driver);
            mainPage.goToRandomProgductSection()
                .selectRandomProduct()
                .addProductToCartAndGoToCart()
                .checkThatCorrectProductInCart();
        }
    }
}
