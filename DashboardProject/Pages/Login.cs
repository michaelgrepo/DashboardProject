using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DashboardProject.Pages;
using System.Threading;

namespace DashboardProject.Pages
{
    public class Login
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs("michael").WithPassword("Password123!@#").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}