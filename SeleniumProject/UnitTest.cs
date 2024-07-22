using NUnit.Framework.Interfaces;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumProject.PagesObjects;

namespace SeleniumProject
{

    [TestFixture]
    public class GoogleSearchTest
    {
        private IWebDriver driver;
        private GoogleHomePage googleHomePage;
        private GoogleResultsPage googleResultsPage;


        [OneTimeSetUp]
        public void SetUp()
        {
            string path = "C:\\Users\\user1\\Desktop\\‡ÂËÂÓˆÈ‰\\SeleniumProject";

††††††††††††driver = new ChromeDriver(path + @"\drivers\");
            googleHomePage = new GoogleHomePage(driver);
            googleResultsPage = new GoogleResultsPage(driver);
        }

        [Test]

        private void HideAds()
        {
            try
            {
                var iframes = driver.FindElements(By.TagName("iframe"));
                foreach (var iframe in iframes)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.display='none';", iframe);
                }
            }
            catch (NoSuchElementException)
            {
            }
        }
        [Test]
        public void TestChart()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com");
            string mainWindow = driver.CurrentWindowHandle;
            driver.ExecuteJavaScript("window.open();");
            var tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);
            driver.Navigate().GoToUrl("https://demo.opencart.com/index.php?route=product/category&path=20");
            driver.Navigate().Back();

        }



        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
