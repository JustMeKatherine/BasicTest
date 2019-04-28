using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BasicTest
{
    [TestClass]
    public class UnitTest1
    {


        static IWebDriver driver;
        private IWebElement element;
        private By locator;

        [TestInitialize]
        public void TestSetup()
        {
            // tutaj siedzi rozpakowany chromedriver.exe
            // najnowsza wersja chromedrivera rzuca mi błędem (stacktrace ponizej), dlatego uzywam starszej: 
            // System.InvalidOperationException: session not created: chromedriver=74.0.3729.6 Object reference not set to an instance of an object..
            var outPutDirectory = "C:\\libs";
            //var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(outPutDirectory);
        }

        [TestMethod]
        [TestCategory("Navigation")]
        public void SeleniumNavigation()
        {
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/automation");
            driver.Navigate().Forward();
            driver.Navigate().Back();
            driver.Navigate().Refresh();
        }

        [TestMethod]
        [TestCategory("Manipulation")]
        public void Manipulation()
        {
            driver.Navigate().GoToUrl("http://www.ultimateqa.com/filling-out-forms/");
            //find the name field

            var nameField = driver.FindElement(By.Id("et_pb_contact_name_1"));
            nameField.Clear();
            nameField.SendKeys("test");
            //clear the field
            //type into the field

            //find the text field
            var textBox = driver.FindElement(By.Id("et_pb_contact_message_1"));
            //clear the field
            textBox.Clear();
            //type into the field
            textBox.SendKeys("testing");
            //submit
            var submitButton = driver.FindElements(By.ClassName("et_contact_bottom_container"));
            submitButton[0].Submit();
        }


        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
