using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        By _ShareSkill = By.LinkText("Share Skill");
        By _SaveButton = By.CssSelector("input[value='Save']");
        By _SubCategory = By.CssSelector("select[name='subcategoryId']");
        By _HourlyBasis = By.XPath("//input[@name='serviceType'][@value='0']");
        By _OneOff = By.XPath("//input[@name='serviceType'][@value='1']");
        By _Onsite = By.XPath("//input[@name='locationType'][@value='0']");
        By _Online = By.XPath("//input[@name='locationType'][@value='1']");
        By _SkillExchange = By.XPath("//input[@name='skillTrades'][@value='true']");
        By _Credit = By.XPath("//input[@name='skillTrades'][@value='false']");
        By _SkillExchangeTag = By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']");
        By _CreditAmount = By.XPath("//input[@name='charge']");
        By _WorkSamplesButton = By.XPath("//i[@class='huge plus circle icon padding-25']");
        By _WorkSamplesFile = By.XPath("//input[@id='selectFile']");
        By _Active = By.XPath("//input[@name='isActive'][@value='true']");
        By _Hidden = By.XPath("//input[@name='isActive'][@value='false']");

        string serviceType;
        string locationType;
        string selectDay;
        string skillTradeType;
        string activeType;
        int i;

        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        internal void EnterShareSkill()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _ShareSkill,10);
            ShareSkillButton.Click();

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _SaveButton, 10);

            //Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Category
            CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            CategoryDropDown.Click();

            //SubCategory
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _SubCategory,10);
            SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
            SubCategoryDropDown.Click();

            //Tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //ServiceType
            serviceType = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
            if (serviceType== "Hourly basis service")
            {
                GlobalDefinitions.driver.FindElement(_HourlyBasis).Click();
            } else 
            {
                GlobalDefinitions.driver.FindElement(_OneOff).Click();
            }

            //LocationTYpe
            locationType = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");
            if (locationType == "On-site") 
            {
                GlobalDefinitions.driver.FindElement(_Onsite).Click();
            }
            else
            {
                GlobalDefinitions.driver.FindElement(_Online).Click();
            }

            //Startdate
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            StartDateDropDown.Click();

            //Enddate
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
            EndDateDropDown.Click();

            //Days
            selectDay = GlobalDefinitions.ExcelLib.ReadData(2, "Selectday");
            switch (selectDay)
            {
                case "Sun":i = 1;
                    break;
                case "Mon":i = 2;
                    break;
                case "Tue":i = 3;
                    break;
                case "Wed":i = 4;
                    break;
                case "Thu":i = 5;
                    break;
                case "Fri":i = 6;
                    break;
                case "Sat":i = 7;
                    break;
            }
            By _Day = By.XPath($"(//input[@name='Available'])[{i}]");
            By _StartTime = By.XPath($"(//input[@placeholder='Start time'])[{i}]");
            By _EndTime = By.XPath($"(//input[@placeholder='End time'])[{i}]");
            GlobalDefinitions.driver.FindElement(_Day).Click();

            //StartTime & EndTime
            DateTime startTime = DateTime.Parse(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            DateTime endTime = DateTime.Parse(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            GlobalDefinitions.driver.FindElement(_StartTime).SendKeys(startTime.ToString("HH:mm"));
            GlobalDefinitions.driver.FindElement(_EndTime).SendKeys(endTime.ToString("HH:mm"));

            //Skill Trade
            skillTradeType = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
            if (skillTradeType == "Skill-Exchange")
            {
                GlobalDefinitions.driver.FindElement(_SkillExchange).Click();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _SkillExchangeTag, 10);
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                GlobalDefinitions.driver.FindElement(_Credit).Click();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _CreditAmount,10);
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }

            //WorkSamples
            //GlobalDefinitions.driver.FindElement(_WorkSamplesFile).SendKeys(@"D:\Work\QA-Competition\MarsFramework\ExcelData\test.jpg");

            //Active
            activeType = GlobalDefinitions.ExcelLib.ReadData(2, "Active");
            if (activeType == "Active")
            {
                GlobalDefinitions.driver.FindElement(_Active).Click();
            }
            else
            {
                GlobalDefinitions.driver.FindElement(_Hidden).Click();
            }

            //Save Skill Details
            Save.Click();

            //By _nsbox = By.CssSelector("body > div.ns-box");
            //GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _nsbox, 10);
            //Assert.AreEqual(GlobalDefinitions.driver.FindElement(_nsbox).Text, "Service Listing Added successfully");

        }

        internal void EditShareSkill()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditShareSkill");

            edit.Click();
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _SaveButton, 10);

            //ServiceType
            serviceType = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
            if (serviceType == "Hourly")
            {
                GlobalDefinitions.driver.FindElement(_HourlyBasis).Click();
            }
            else
            {
                GlobalDefinitions.driver.FindElement(_OneOff).Click();
            }

            //LocationTYpe
            locationType = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");
            if (locationType == "On-site")
            {
                GlobalDefinitions.driver.FindElement(_Onsite).Click();
            }
            else
            {
                GlobalDefinitions.driver.FindElement(_Online).Click();
            }

            //Skill Trade
            skillTradeType = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
            if (skillTradeType == "Skill-Exchange")
            {
                GlobalDefinitions.driver.FindElement(_SkillExchange).Click();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _SkillExchangeTag, 10);
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
            }
            else
            {
                GlobalDefinitions.driver.FindElement(_Credit).Click();
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, _CreditAmount, 10);
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }

            //Active
            activeType = GlobalDefinitions.ExcelLib.ReadData(2, "Active");
            if (activeType == "Active")
            {
                GlobalDefinitions.driver.FindElement(_Active).Click();
            }
            else
            {
                GlobalDefinitions.driver.FindElement(_Hidden).Click();
            }

            Save.Click();
        }
    }
}
