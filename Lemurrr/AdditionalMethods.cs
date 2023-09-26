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

        public static IWebElement SelectElement(this IList<IWebElement> elements, string elementText)
        {
            IWebElement element = elements.First(x => x.Text.Contains(elementText));
            return element;
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

        private static IWebElement ElementIfVisible(IWebElement element)
        {
            if (!element.Displayed)
            {
                return null;
            }

            return element;
        }

        public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    return ElementIfVisible(element);
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(IWebElement element)
        {
            return delegate (IWebDriver driver)
            {
                try
                {
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }
    }
}

    
