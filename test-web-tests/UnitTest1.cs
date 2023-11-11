using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace test_web_tests;

[TestClass]
public class UnitTest1
{
    private readonly string testSite = "http://localhost:5280/";
    private WebDriver? _driver = null;

    [TestInitialize]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();
    }

    [TestMethod]
    public void TestMethod1()
    {
        _driver?.Navigate().GoToUrl(testSite);
        Assert.IsTrue(_driver?.PageSource.Contains("Welcome"));
        var screenshot = _driver?.GetScreenshot();
        screenshot?.SaveAsFile(@"C:\temp\screen1.png");
    }

    [TestMethod]
    public void TestMethod2()
    {
        _driver?.Navigate().GoToUrl(String.Concat(testSite, "/Privacy"));
        // Console.WriteLine(_driver?.PageSource);
        Assert.IsTrue(_driver?.PageSource.Contains("Policy"));
        var screenshot = _driver?.GetScreenshot();
        screenshot?.SaveAsFile(@"C:\temp\screen2.png");
    }

    [TestMethod]
    public void TestMethod3()
    {
        string expect = "alsfdglhasdgha";
        _driver?.Navigate().GoToUrl(testSite);
        var input = _driver?.FindElement(By.CssSelector("input[name=prompt]"));
        var submit = _driver?.FindElement(By.CssSelector("input[type=submit]"));
        input?.SendKeys(expect);
        submit?.Click();
        Assert.IsTrue(_driver?.PageSource.Contains(expect));
        var screenshot = _driver?.GetScreenshot();
        screenshot?.SaveAsFile(@"C:\temp\screen3.png");
    }

    [TestCleanup]
    public void Teardown()
    {
        _driver?.Quit();
    }
}