using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;


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
            // Wait for the modal button to be clickable
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement openModalButton = driver.FindElement(By.CssSelector("button[data-target='#myModal']"));
            openModalButton.Click();
            Console.WriteLine("Modal opened successfully!");

            // Wait for the modal to become visible
            IWebElement modal = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#myModal")));

            // Perform actions inside the modal
            IWebElement modalCloseButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".modal-footer .btn-danger")));
            modalCloseButton.Click();
            Console.WriteLine("Modal closed successfully!");
        }
    }
}
