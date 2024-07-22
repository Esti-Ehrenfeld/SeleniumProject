using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject
{
    public class Tests
    {
        [TestFixture]
        public class GoogleSearchTest
        {
            private IWebDriver driver;

            [OneTimeSetUp]
            public void SetUp()
            {
                string path = "C:\\Users\\user1\\Desktop\\אוטומציה\\SeleniumProject";

                driver = new ChromeDriver(path + @"\drivers\");
            }
            [Test]
            public void TestHandleAlert()
            {
                driver.Navigate().GoToUrl("https://demoqa.com/alerts");

                var alertButton = driver.FindElements(By.Id("promtButton"))[0];

                alertButton.Click();

                IAlert alert = WaitForAlert(driver, TimeSpan.FromSeconds(10));
                Assert.IsNotNull(alert, "Alert was not displayed.");

                alert.Accept();
            }
            private IAlert WaitForAlert(IWebDriver driver, TimeSpan timeout)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, timeout);
                    return wait.Until(ExpectedConditions.AlertIsPresent());
                }
                catch (WebDriverTimeoutException)
                {
                    return null;
                }
            }

            [OneTimeTearDown]
            public void TearDown()
            {
                driver.Dispose();
            }

        }
    }
}
