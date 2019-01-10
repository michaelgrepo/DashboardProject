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
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "log-in?redirect_to=https%3A%2F%2Fwordpress.com%2F");

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
            Thread.Sleep(3000);
            var loginInput = Browser.FindElement(By.Id("usernameOrEmail"));
            loginInput.SendKeys(userName);

            var continueButton = Driver.Instance.FindElement(By.CssSelector(".form-button"));
            continueButton.Click();

            Thread.Sleep(3000);
            var passwordInput = Driver.Instance.FindElement(By.CssSelector("#password"));
            passwordInput.SendKeys(passWord);

            Thread.Sleep(30);
            var loginButton = Driver.Instance.FindElement(By.CssSelector(".form-button"));
            loginButton.Click();

            Thread.Sleep(3000);
        }
    }
}
