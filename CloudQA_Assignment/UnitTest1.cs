using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace CloudQA_Assignment
{
    public class Tests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestFillFirstNameAndGender()
        {
            // Test 1: Fill out First Name
            IWebElement firstNameField = driver.FindElement(By.Id("fname"));
            firstNameField.Clear();
            firstNameField.SendKeys("Zoya");
            Console.WriteLine("First Name field test passed!");

            // Test 2: Select Gender
            IWebElement femaleGenderRadio = driver.FindElement(By.Id("female"));
            if (!femaleGenderRadio.Selected)
            {
                femaleGenderRadio.Click();
            }
            Console.WriteLine("Gender field test passed!");

            // Verify values
            Assert.AreEqual("Zoya", firstNameField.GetAttribute("value"), "First name value does not match!");
            Assert.IsTrue(femaleGenderRadio.Selected, "Gender selection failed!");
        }

        [Test]
        public void TestModal()
        {
            // Test Modal: Open and interact with modal
            IWebElement openModalButton = driver.FindElement(By.CssSelector("button[data-target='#myModal']"));
            openModalButton.Click();
            Console.WriteLine("Modal opened successfully!");

            // Perform additional checks or interactions within the modal (if applicable)
            IWebElement modalCloseButton = driver.FindElement(By.CssSelector(".modal-footer .btn-primary"));
            modalCloseButton.Click();
            Console.WriteLine("Modal closed successfully!");
        }

        //[Test]
        //public void TestIFrameWithoutId()
        //{
        //    // Test IFrame without ID
        //    IWebElement iframeWithoutId = driver.FindElement(By.XPath("//iframe[not(@id)]"));
        //    driver.SwitchTo().Frame(iframeWithoutId);

        //    // Interact with elements inside the iframe
        //    IWebElement iframeContent = driver.FindElement(By.TagName("body"));
        //    Assert.IsNotNull(iframeContent, "IFrame content not found!");
        //    Console.WriteLine("IFrame without ID loaded successfully!");

        //    // Switch back to the main content
        //    driver.SwitchTo().DefaultContent();
        //}
    }
}
