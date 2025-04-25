using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;


namespace CloudQA_Assignment
{
    public class Tests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");
            driver.Manage().Window.Maximize();
        }

        //[OneTimeTearDown]
        //public void OneTimeTearDown()
        //{
        //    driver.Quit();
        //}

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
            IWebElement openModalButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-target='#myModal']")));

            // Click the button to open the modal
            openModalButton.Click();
            Console.WriteLine("Modal opened successfully!");

            // Wait for the modal to become visible
            IWebElement modal = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#myModal")));

            // Perform actions inside the modal
            IWebElement modalCloseButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".modal-footer .btn-danger")));
            modalCloseButton.Click();
            Console.WriteLine("Modal closed successfully!");
        }

        [Test]
        public void TestIFrameWithoutId()
        {
            // Test IFrame without ID
            IWebElement iframeWithoutId = driver.FindElement(By.XPath("//iframe[not(@id)]"));
            driver.SwitchTo().Frame(iframeWithoutId);

            // Interact with elements inside the iframe
            IWebElement iframeContent = driver.FindElement(By.TagName("body"));
            Assert.IsNotNull(iframeContent, "IFrame content not found!");
            Console.WriteLine("IFrame without ID loaded successfully!");

            // Switch back to the main content
            driver.SwitchTo().DefaultContent();

        }

        [Test]
        public void TestIFrameWithID()
        {
            // Locate the iframe using its ID
            IWebElement iframe = driver.FindElement(By.Id("iframeId"));

            // Switch to the iframe
            driver.SwitchTo().Frame(iframe);

            // Interact with elements inside the iframe
            IWebElement iframeContent = driver.FindElement(By.TagName("body"));
            Assert.IsNotNull(iframeContent, "IFrame content not found!");
            Console.WriteLine("IFrame with ID content loaded successfully!");

            // Switch back to the main page
            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void TestShadowDOMWithJS()
        {
            // Locate the shadow host element
            IWebElement shadowHost = driver.FindElement(By.CssSelector("shadow-form"));

            // Access the shadow root using JavaScript
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var shadowRoot = js.ExecuteScript("return arguments[0].shadowRoot", shadowHost);

            // Find the inner element within the shadow root using JavaScript
            IWebElement innerField = (IWebElement)js.ExecuteScript("return arguments[0].querySelector('input')", shadowRoot);
            innerField.SendKeys("Shadow DOM test "); //NOT VISIBLE
            Console.WriteLine("Shadow DOM field interacted successfully!");
        }
    }
}
