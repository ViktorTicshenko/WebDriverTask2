using OpenQA.Selenium;

namespace NetAutomation_WebDriverTask2
{
    public class PastebinBasePage(IWebDriver driver, string url)
    {
        protected readonly IWebDriver driver = driver;
        protected readonly string url = url;

        public void NavigateToPage()
        {
            if(url.Length > 0)
                driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Dealing with potential ad banners :( that cover up the elements
        /// </summary>
        public void ScrollDown()
        {
            var windowSize = driver.Manage().Window.Size;
            (driver as IJavaScriptExecutor)?.ExecuteScript($"window.scrollBy(0, {windowSize.Height});");
        }
    }
}