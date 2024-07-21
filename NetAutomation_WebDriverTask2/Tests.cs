using OpenQA.Selenium;

namespace NetAutomation_WebDriverTask2;

using BrowserType = BrowserFactory.BrowserType;

[Parallelizable(scope: ParallelScope.Fixtures)]
[TestFixture("Chrome")]
[TestFixture("Firefox")]
[TestFixture("Edge")]
public class CreatePasteTest(string browserTypeString)
{
    private IWebDriver? driver;
    private PastebinHomePage? pastebinHomePage;

    private readonly string browserTypeString = browserTypeString;

    [SetUp]
    public void SetUp()
    {
        var browserFactory = BrowserFactory.Instance;

        if (Enum.TryParse<BrowserType>(browserTypeString, true, out BrowserType browserType))
        {
            driver = browserFactory.GetDriver(browserType);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(browserTypeString), browserTypeString, null);
        }

        pastebinHomePage = new PastebinHomePage(driver);

        pastebinHomePage.NavigateToPage();
    }

    [Test]
    [TestCase
        (
            """
            git config --global user.name "New Sheriff in Town"
            git reset $(git commit-tree HEAD^{tree} -m "Legacy code")
            git push origin master --force
            """, 
            "Bash",
            "10 Minutes", 
            "how to gain dominance among developers"
        )
    ]
    public void CreateNewPaste(string pasteText, string syntaxHighlighting, string pasteExpiration, string pasteName)
    {
        pastebinHomePage!.ScrollDown();

        pastebinHomePage.EnterPasteText(pasteText);
        pastebinHomePage.SelectSyntaxHighlighting(syntaxHighlighting);
        pastebinHomePage.SelectPasteExpiration(pasteExpiration);
        pastebinHomePage.EnterPasteName(pasteName);
        pastebinHomePage.ClickCreateNewPaste();

        var pastebinPasteResultPage = new PastebinPasteResultPage(driver!);
        pastebinPasteResultPage.CheckForErrors();
        pastebinPasteResultPage.CheckHighlightedCode(syntaxHighlighting);
        pastebinPasteResultPage.CheckTitleText(pasteName);
        pastebinPasteResultPage.CheckBodyText(pasteText, syntaxHighlighting);
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Dispose();
    }
}