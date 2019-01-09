using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace DashboardProject
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static string BaseAddress
        {
            get
            {
                return "https://qa.app.qa.tsretail.co.za/betanalysis/";
            }
        }

        public static void Initialize()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            Instance.Close();
        }

        internal static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }
    }
}