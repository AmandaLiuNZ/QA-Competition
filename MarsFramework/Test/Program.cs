using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test,Order(1)]
            public void TestShareSkill()
            {
                ShareSkill shareSkill = new ShareSkill();
                ManageListings manageListings = new ManageListings();
                test = extent.StartTest("ShareSkillTest");
       
                shareSkill.EnterShareSkill();
                string assertType = "ShareSkill";
                manageListings.AssertSkill(assertType);
            }

            [Test,Order(2)]
            public void TestEditShareSkill()
            {
                ShareSkill shareSkill = new ShareSkill();
                ManageListings manageListings = new ManageListings();
                test = extent.StartTest("EditShareSkillTest");

                manageListings.Listings();
                shareSkill.EditShareSkill();
                string assertType = "EditShareSkill";
                manageListings.AssertSkill(assertType);
            }

            [Test,Order(3)]
            public void TestDeleteSkill()
            {
                ManageListings manageListings = new ManageListings();
                test = extent.StartTest("DeleteSkillTest");

                manageListings.DeleteSkill();
                manageListings.AssertDeleteMsg();
            }
        }
    }
}