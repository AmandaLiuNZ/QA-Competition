using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        By _EyeIcon = By.XPath("(//i[@class='eye icon'])[1]");
        By _Category = By.XPath("//table/tbody/tr[1]/td[2]");
        By _Title = By.XPath("//table/tbody/tr[1]/td[3]");
        By _Description = By.XPath("//table/tbody/tr[1]/td[4]");
        By _ServiceType = By.XPath("//table/tbody/tr[1]/td[5]");
        By _SkillTrade = By.XPath("//table/tbody/tr[1]/td[6]/i");
        By _Active = By.XPath("(//input[@type='checkbox'])[1]");
        By _ManageListing = By.LinkText("Manage Listings");
        By _YesButton = By.XPath("//button[@class='ui icon positive right labeled button']");

        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _ManageListing,10);
            manageListingsLink.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _EyeIcon, 10);

        }
        internal void AssertSkill(string assertType)
        {
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _EyeIcon,10);

            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, assertType);

            //Category
            string expectedString = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
            string actualString = GlobalDefinitions.driver.FindElement(_Category).Text;
            Assert.AreEqual(expectedString, actualString);
            TestContext.WriteLine("Category passed");

            //Title
            expectedString = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            actualString = GlobalDefinitions.driver.FindElement(_Title).Text;
            Assert.AreEqual(expectedString, actualString);
            TestContext.WriteLine("Title passed");

            //Description
            expectedString = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
            actualString = GlobalDefinitions.driver.FindElement(_Description).Text;
            Assert.AreEqual(expectedString, actualString);
            TestContext.WriteLine("Description passed");

            //ServiceType
            expectedString = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
            actualString = GlobalDefinitions.driver.FindElement(_ServiceType).Text;
            Assert.AreEqual(expectedString, actualString);
            TestContext.WriteLine("ServiceType passed");

            //SkillTrade
            expectedString = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
            actualString = GlobalDefinitions.driver.FindElement(_SkillTrade).GetAttribute("class");
            if (expectedString == "Skill-Exchange")
            {
                Assert.AreEqual("blue check circle outline large icon",actualString);
            }
            else
            {
                Assert.AreEqual("grey remove circle large icon", actualString);
            }
            TestContext.WriteLine("SkillTrade passed");

            //Active
            expectedString = GlobalDefinitions.ExcelLib.ReadData(2, "Active");
            IWebElement activeCheckbox = GlobalDefinitions.driver.FindElement(_Active);
            if (expectedString == "Active")
            {
                Assert.IsTrue(activeCheckbox.Selected);
            }
            else
            {
                Assert.IsFalse(activeCheckbox.Selected);
            }
            TestContext.WriteLine("Active passed");
        }
        internal void DeleteSkill()
        {
            Listings();
            delete.Click();

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _YesButton,10);
            GlobalDefinitions.driver.FindElement(_YesButton).Click();

        }
        internal void AssertDeleteMsg()
        {
            By _nsbox = By.CssSelector("body > div.ns-box");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _nsbox, 10);
            Assert.AreEqual(GlobalDefinitions.driver.FindElement(_nsbox).Text, "Selenium has been deleted");

        }

    }
}
