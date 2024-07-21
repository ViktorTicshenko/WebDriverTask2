using OpenQA.Selenium;

namespace NetAutomation_WebDriverTask2
{
    public class PastebinHomePage : PastebinBasePage
    {
        private readonly By newPasteTextBoxLocator = By.Id("postform-text");
        private readonly By pasteExpirationDropdownLocator = By.Id("select2-postform-expiration-container");
        private readonly Lazy<By> pasteExpirationOptionLocator = new(By.Id("select2-postform-expiration-results"));
        private readonly By pasteNameTextBoxLocator = By.Id("postform-name");
        private readonly By createNewPasteButtonLocator = By.XPath("//button[text()='Create New Paste']");
        private readonly By highlightingTypeDropdownLocator = By.Id("select2-postform-format-container");
        private readonly Lazy<By> highlightingTypeOptionLocator = new(By.Id("select2-postform-format-results"));
        private readonly Lazy<By> syntaxHighlightingLocator = new(By.CssSelector("li[role='option']"));
        private readonly Lazy<By> pasteExpirationElementLocator = new(By.TagName("li"));

        public PastebinHomePage(IWebDriver driver, string url = "https://pastebin.com/") : base(driver, url)
        {
            //
        }

        public void EnterPasteText(string pasteText)
        {
            driver.FindElement(newPasteTextBoxLocator).SendKeys(pasteText);
        }

        public void SelectSyntaxHighlighting(string type)
        {
            driver.FindElement(highlightingTypeDropdownLocator).Click();
            var elements = driver.FindElement(highlightingTypeOptionLocator.Value);

            foreach(var child in elements.FindElements(syntaxHighlightingLocator.Value))
            {
                if(child.Text.Contains(type, StringComparison.CurrentCultureIgnoreCase))
                {
                    child.Click();
                    break;
                }
            }
        }

        public void SelectPasteExpiration(string expiration)
        {
            driver.FindElement(pasteExpirationDropdownLocator).Click();
            var elements = driver.FindElement(pasteExpirationOptionLocator.Value);

            foreach(var child in elements.FindElements(pasteExpirationElementLocator.Value))
            {
                //TestContext.Out.WriteLine($"Child Text: {child.Text}");
                if(child.Text.Contains(expiration, StringComparison.CurrentCultureIgnoreCase))
                {
                    child.Click();
                    break;
                }
            }
        }

        public void EnterPasteName(string pasteName)
        {
            driver.FindElement(pasteNameTextBoxLocator).SendKeys(pasteName);
        }

        public void ClickCreateNewPaste()
        {
            driver.FindElement(createNewPasteButtonLocator).Click();
        }
    }
}