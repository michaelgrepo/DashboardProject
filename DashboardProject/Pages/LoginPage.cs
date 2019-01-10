using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Turfsport.QA.Framework.Core;

namespace DashboardProject.Pages
{
    class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "https://qa.app.qa.tsretail.co.za/betanalysis/");

            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "usernameOrEmail");
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
    }

    public class LoginCommand
    {
        private readonly string userName;
        private string passWord;

        public LoginCommand(string userName)
        {
            this.userName = userName;
        }

        public LoginCommand WithPassword(string passWord)
        {
            this.passWord = passWord;
            return this;
        }

        public void Login()
        {
            var loginInput = Browser.FindElement(By.Id("#username"));
            loginInput.SendKeys(userName);
       
            var passwordInput = Browser.FindElement(By.Id("#password"));
            passwordInput.SendKeys(passWord);

            var loginButton = Browser.FindElement(By.CssSelector("#kc-login"));
            loginButton.Click();
        }
    }
}
