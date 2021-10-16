using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        By _SignIn = By.LinkText("Sign In");
        By _email = By.Name("email");

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _SignIn, 10);
            SignIntab.Click();

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _email, 10);
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            LoginBtn.Click();
        }
    }
}