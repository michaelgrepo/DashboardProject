using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DashboardProject.Pages;
using System.Threading;
using Turfsport.QA.Framework.Core;

namespace DashboardProject.Pages
{
    public class BetAnalysisPage
    {
        public static void BetAnalysis()
        {
            var clickonbetanalysis = Browser.FindElement(By.CssSelector(""));
            clickonbetanalysis.Click();
        }
    }
}