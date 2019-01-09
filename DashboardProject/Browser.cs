using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Turfsport.QA.Framework.Core
{
    public static class Browser
    {
        private static IWebDriver _webDriver;

        private const int TIMEOUT = 15;

        public static void Initialize(IWebDriver driver, string url)
        {
            _webDriver = driver;
            _webDriver.Manage().Window.Maximize();
            Goto(url);
        }

        public static string Title => _webDriver.Title;

        public static string UrlContains => _webDriver.Url;

        public static ISearchContext Driver => _webDriver;

        public static void Goto(string url)
        {
            _webDriver.Url = url;
            _webDriver.Navigate().GoToUrl(url);
        }

        public static void Close()
        {
            var webDriver = _webDriver as ChromeDriver;
            webDriver?.Close();
            webDriver?.Quit();
            webDriver?.Dispose();
        }

        public static void SetWindowSize(int width, int height)
        {
            _webDriver.Manage().Window.Size = new Size(width, height);
        }

        public static IWebElement FindElement(By by, int timeoutInSeconds = TIMEOUT, bool clickable = false)
        {


            var waitClickable = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(TIMEOUT));
            waitClickable.Until(clickable
                ? ExpectedConditions.ElementToBeClickable(@by)
                : ExpectedConditions.ElementIsVisible(by));
            return waitClickable.Until(drv => drv.FindElement(@by));

        }

        public static ReadOnlyCollection<IWebElement> FindElements(By by, int timeoutInSeconds = TIMEOUT,
            bool clickable = false)
        {

            var waitClickable = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(TIMEOUT));
            waitClickable.Until(clickable
                ? ExpectedConditions.ElementToBeClickable(@by)
                : ExpectedConditions.ElementIsVisible(by));
            return waitClickable.Until(drv => drv.FindElements(@by));

        }

        public static Func<IWebDriver, IEnumerable<IWebElement>> FindElements(By by, Func<IWebElement, bool> predicate)
        {
            return driver =>
            {
                try
                {
                    return driver.FindElements(by).Where(predicate);
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        public static IWebElement GetElement(this IWebElement element, By by, int timeoutInSeconds = TIMEOUT,
            bool clickable = false)
        {

            var waitClickable = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(TIMEOUT));
            waitClickable.Until(clickable
                ? ExpectedConditions.ElementToBeClickable(@by)
                : ExpectedConditions.ElementIsVisible(by));
            return waitClickable.Until(drv => element.FindElement(@by));
        }

        public static IList<IWebElement> GetElements(this IWebElement element, By by, int timeoutInSeconds = TIMEOUT,
            bool clickable = false)
        {
            var waitClickable = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(TIMEOUT));
            waitClickable.Until(clickable
                ? ExpectedConditions.ElementToBeClickable(@by)
                : ExpectedConditions.ElementIsVisible(by));
            return waitClickable.Until(drv => element.FindElements(@by));
        }
    }
}