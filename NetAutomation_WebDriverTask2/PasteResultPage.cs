using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace NetAutomation_WebDriverTask2
{
    public class PastebinPasteResultPage :  PastebinBasePage
    {
        private readonly By errorSummaryLocator = By.CssSelector(".error-summary");
        private readonly Lazy<By> titleTextLocator = new(By.CssSelector("div[class='info-bar'] div[class='info-top'] h1"));
        private readonly string highlightedCodeLocatorTemplate = "a[href='/archive/{0}']";
        private readonly string bodyTextLocatorTemplate = "ol[class='{0}']";

        public PastebinPasteResultPage(IWebDriver driver, string url = "") : base(driver, url)
        {
            //
        }

        public void CheckHighlightedCode(string type)
        {
            driver.FindElement(By.CssSelector(String.Format(highlightedCodeLocatorTemplate, type.ToLower())));
        }

        public void CheckTitleText(string text)
        {
            var elem = driver.FindElement(titleTextLocator.Value);
            string cleanedText = Regex.Replace(elem.Text, @"^\s+", "", RegexOptions.Multiline);

            Assert.That(cleanedText, Is.EqualTo(text), $"Expected text:\n{text}\nGot instead:\n{cleanedText}");
        }

        public void CheckBodyText(string text, string type)
        {
            var elem = driver.FindElement(By.CssSelector(String.Format(bodyTextLocatorTemplate, type.ToLower())));
            string cleanedText = Regex.Replace(elem.Text, @"^\s+", "", RegexOptions.Multiline);

            Assert.That(cleanedText, Is.EqualTo(text), $"Expected text:\n{text}\nGot instead:\n{cleanedText}");
        }

        /// <summary>
        /// Running out of X free paste per 24 hours for example
        /// </summary>
        public void CheckForErrors()
        {
            var summary = driver.FindElement(errorSummaryLocator).Text;
            Assert.That(summary, Is.Empty, $"Error Message: {summary}");
        }
    }
}