using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject
{
    public class Windows
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            string path = "C:\\Users\\user1\\Desktop\\אוטומציה\\SeleniumProject";

            driver = new ChromeDriver(path + @"\drivers\");
        }

        public void TestSwitchBetweenWindowsAndTabs()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
            var windowButton = driver.FindElement(By.Id("windowButton"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", windowButton);

            string originalWindow = driver.CurrentWindowHandle;

 
            WaitForNewWindow(driver, 2);

            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != originalWindow)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }

            var newTabHeading = driver.FindElement(By.Id("sampleHeading"));
            Assert.AreEqual("This is a sample page", newTabHeading.Text);

            driver.Close();
            driver.SwitchTo().Window(originalWindow);
        }

        private void WaitForNewWindow(IWebDriver driver, int expectedWindowCount)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count == expectedWindowCount);
        }



        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

    }
}
