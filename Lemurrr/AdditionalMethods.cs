using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baucenter
{
    public static class AdditionalMethods
    {
        public static IWebElement randomElement(IList<IWebElement> elements)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(elements.Count);

            return elements[randomIndex];
        }

        public static Func<IWebDriver, IList<IWebElement>> VisibilityOfAllElementsLocated(IList<IWebElement> elements)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    IList<IWebElement> readOnlyCollection = elements;
                    if (readOnlyCollection.Any((IWebElement element) => !element.Displayed))
                    {
                        return null;
                    }

                    return readOnlyCollection.Any() ? readOnlyCollection : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }
    }
}

    
